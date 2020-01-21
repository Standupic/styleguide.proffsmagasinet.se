module PM.StyleGuide.Verktygsproffsen.Home.MarketingBanner

open PM.StyleGuide

open Fable.React
open Fable.React.Props
open Storybook
open CommonTypes

type BannerType =
    | Verktyg_Premium_2x2
    | Verktyg_Premium_1x2
    | Verktyg_Premium_1x1

type MarketingBanner =
    {
        BannerType : BannerType
        Link : string
        Image : string
    }

type MarketingBannersProps =
    {
        AccountType: AccountType
        Blocks : Map<AccountType, MarketingBanner list>
    }

let blockList =
    [
        (B2C,
            [
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x1
                    Link = "#"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x1
                    Link = "#"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x1
                    Link = "#"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x2
                    Link = "#"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner2_772x860.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_2x2
                    Link = "#"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner1_1600x860.png"
                }
            ]
        )
        (B2B,
            [
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x1
                    Link = "https://www.verktygsproffsen.se/black-friday?keyword=festool"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x1
                    Link = "https://www.verktygsproffsen.se/black-friday?keyword=festool"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x1
                    Link = "https://www.verktygsproffsen.se/black-friday?keyword=festool"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x2
                    Link = "https://www.verktygsproffsen.se/best-offers-black-friday"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner2_772x860.png"
                }
                {
                    MarketingBanner.BannerType = Verktyg_Premium_2x2
                    Link = "https://www.verktygsproffsen.se/black-friday"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner1_1600x860.png"
                }
            ]
        )
    ]

let bannerLinkElement banner =
    a [ classList [ ("banner", true)
                    ("banner-main", banner.BannerType = Verktyg_Premium_2x2)
                  ]
        Href banner.Link
      ]
      [ img [ Src banner.Image ] ]

let bannerElement banners =
    div [ Class "banner-list" ] (banners |> List.map bannerLinkElement)

let blocks allBlocks accountType =
    allBlocks |> Map.find accountType

let banners blocks bannerType =
    blocks |> List.filter (fun a -> a.BannerType = bannerType)

let props =
    {
        MarketingBannersProps.Blocks = blockList |> Map.ofList
        AccountType = B2C
    }

let MarketingBanners =
    FunctionComponent.Of(fun (props : MarketingBannersProps) ->

        let bannerList = blocks props.Blocks props.AccountType
        let mainBanner = banners bannerList Verktyg_Premium_2x2
        let UpperRowBanners = mainBanner @ banners bannerList Verktyg_Premium_1x2
        let LowerRowBanners = banners bannerList Verktyg_Premium_1x1

        div [ Class "marketing-banners" ]
            [
                bannerElement UpperRowBanners
                bannerElement LowerRowBanners
            ]
    )

storiesOf("Verktygsproffsen|Home")
    .add("Marketing Banner", fun _ -> MarketingBanners props)
    |> ignore

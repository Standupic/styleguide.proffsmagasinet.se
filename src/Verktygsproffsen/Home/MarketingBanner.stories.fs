module PM.StyleGuide.Verktygsproffsen.Home.MarketingBanner

open PM.StyleGuide

open Fable.React
open Fable.React.Props
open Storybook

type BannerType =
    | Verktyg_Premium_2x2
    | Verktyg_Premium_1x2
    | Verktyg_Premium_1x1

type BannerBlockType =
    | Verktyg_Premium_Organization_2x2
    | Verktyg_Premium_Organization_1x2
    | Verktyg_Premium_Organization_1x1
    | Verktyg_Premium_Customer_2x2
    | Verktyg_Premium_Customer_1x2
    | Verktyg_Premium_Customer_1x1

type MarketingBanner =
    {
        BannerType : BannerType
        Link : string
        Image : string
    }

type AccessType =
    | Customer
    | Organization

type MarketingBannersProps =
    {
        AccessType: AccessType
        Blocks : Map<BannerBlockType, MarketingBanner list>
    }

let blockList =
    [
        (Verktyg_Premium_Customer_1x1,
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
            ]
        )
        (Verktyg_Premium_Customer_1x2,
            [
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x2
                    Link = "#"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner2_772x860.png"
                }
            ]
        )
        (Verktyg_Premium_Customer_2x2,
            [
                {
                    MarketingBanner.BannerType = Verktyg_Premium_2x2
                    Link = "#"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner1_1600x860.png"
                }
            ]
        )
        (Verktyg_Premium_Organization_1x1,
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
            ]
        )
        (Verktyg_Premium_Organization_1x2,
            [
                {
                    MarketingBanner.BannerType = Verktyg_Premium_1x2
                    Link = "https://www.verktygsproffsen.se/best-offers-black-friday"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner2_772x860.png"
                }
            ]
        )
        (Verktyg_Premium_Organization_2x2,
            [
                {
                    MarketingBanner.BannerType = Verktyg_Premium_2x2
                    Link = "https://www.verktygsproffsen.se/black-friday"
                    Image = "https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner1_1600x860.png"
                }
            ]
        )
    ]

let bannerLink banner =
    a [ classList [ ("banner", true)
                    ("banner-main", banner.BannerType = Verktyg_Premium_2x2)
                  ]
        Href banner.Link
      ]
      [ img [ Src banner.Image ] ]

let banners banners =
    div [ Class "banner-list" ] (banners |> List.map bannerLink)

let premiumBlockTypes =
    (Verktyg_Premium_Customer_2x2, Verktyg_Premium_Organization_2x2)

let secondPremiumBlockTypes =
    (Verktyg_Premium_Customer_1x2, Verktyg_Premium_Organization_1x2)

let normalBlockTypes =
    (Verktyg_Premium_Customer_1x1, Verktyg_Premium_Organization_1x1)

let blockType accessType (customerBlock, organizationBlock) =
    match accessType, (customerBlock, organizationBlock) with
    | Customer, (a,_) -> a
    | _, (_,b) -> b

let blocks allBlocks accessType (customerBlock, organizationBlock) =
    allBlocks |> Map.find (blockType accessType (customerBlock,organizationBlock))

let props =
    {
        MarketingBannersProps.Blocks = blockList |> Map.ofList
        AccessType = Customer
    }

let MarketingBanners =
    FunctionComponent.Of(fun (props : MarketingBannersProps) ->

        let mainBanner = blocks props.Blocks props.AccessType premiumBlockTypes
        let UpperRowBanners = mainBanner @ (blocks props.Blocks props.AccessType secondPremiumBlockTypes)
        let LowerRowBanners = blocks props.Blocks props.AccessType normalBlockTypes

        div [ Class "marketing-banners" ]
            [
                banners UpperRowBanners
                banners LowerRowBanners
            ]
    )

storiesOf("Verktygsproffsen|Home")
    .add("Marketing Banner", fun _ -> MarketingBanners props)
    |> ignore

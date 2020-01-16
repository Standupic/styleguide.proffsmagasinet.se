module PM.StyleGuide.Verktygsproffsen.Home.MarketingBanner

open PM.StyleGuide

open Fable.React
open Fable.React.Props
open Storybook

type MarketingBanner = {
    Title : string
    Link : string
    Image : string
}

let BannerList = [
    { Title="Verktyg_Premium_2x2"; Link="https://www.verktygsproffsen.se/black-friday"; Image="https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner1_1600x860.png"; };
    { Title="Verktyg_Premium_2x1"; Link="https://www.verktygsproffsen.se/best-offers-black-friday"; Image="https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_banner2_772x860.png"; };
    { Title="Verktyg_Premium_1x1"; Link="https://www.verktygsproffsen.se/black-friday?keyword=festool"; Image="https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"; };
    { Title="Verktyg_Premium_1x1"; Link="https://www.verktygsproffsen.se/black-friday?keyword=festool"; Image="https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"; };
    { Title="Verktyg_Premium_1x1"; Link="https://www.verktygsproffsen.se/black-friday?keyword=festool"; Image="https://pm-image.azureedge.net/dynamic-content/2019_bf/VP_festool_772x460.png"; };
]

let MainBanner = BannerList |> List.find(fun i-> i.Title = "Verktyg_Premium_2x2")
let UpperRowBanners = MainBanner :: (BannerList |> List.filter(fun i-> i.Title = "Verktyg_Premium_2x1"))
let LowerRowBanners = BannerList |> List.filter(fun i-> i.Title = "Verktyg_Premium_1x1")

let BannerClass banner =
    match banner.Title with
    | "Verktyg_Premium_2x2" -> "banner banner-main"
    | _ -> "banner"

let BannerLink banner =
    a [
        Class (banner |> BannerClass)
        Href banner.Link ][
        img [ Src banner.Image ]
    ]

let Banners banners =
    div [ Class "banner-list" ] (banners |> List.map BannerLink)

let MarketingBanners=
    FunctionComponent.Of(fun () ->
        div [ Class "marketing-banners" ] [
            Banners UpperRowBanners
            Banners LowerRowBanners
        ]
    )

storiesOf("Verktygsproffsen|Home")
    .add("Marketing Banner", MarketingBanners)
    |> ignore

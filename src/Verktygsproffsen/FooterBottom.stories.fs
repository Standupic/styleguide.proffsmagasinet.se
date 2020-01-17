module PM.StyleGuide.Verktygsproffsen.FooterBottom

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

let logoSp: string = importDefault "../svg/logo-sp.svg"
let logoKlarna: string = importDefault "../jpg/logo-klarna.jpg"
let logoSvea: string = importDefault "../png/svea_white_small.png"
let logoVisa: string = importDefault "../jpg/logo-visa.jpg"
let logoMC: string = importDefault "../png/logo-mastercard-white.png"
let logoAE: string = importDefault "../jpg/logo-amex.jpg"

let payOptions : string List = [ logoKlarna
                                 logoSvea
                                 logoVisa
                                 logoMC
                                 logoAE ]

let FooterBottomElement =
    FunctionComponent.Of(fun () ->

        let listItem image =
            li [ Class "list-item" ]
                [ img [ Src image ] ]

        div [ Class "footer-row footer-bottom" ]
            [ div [ Class "footer-col" ]
                [ img [ Class "logo"
                        Src logoSp ]
                  div [ Class "copy" ] [ "@ 2018 Verktygsproffsen.se" |> str ] ]

              div [ Class "footer-col" ]
                [ div [ Class "footer-text" ] [ "Här handlar du tryggt med:" |> str ]
                  ul [ Class "list" ] [ payOptions |> List.map listItem ] ] ]
    )

storiesOf("Verktygsproffsen|Footer").add("Bottom", fun _ -> FooterBottomElement()) |> ignore

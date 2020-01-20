module PM.StyleGuide.Verktygsproffsen.FooterBottom

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

let optionSp = importDefault "../svg/logo-sp.svg"
let optionKlarna = importDefault "../jpg/logo-klarna.jpg"
let optionSvea = importDefault "../png/svea_white_small.png"
let optionVisa = importDefault "../jpg/logo-visa.jpg"
let optionMC = importDefault "../png/logo-mastercard-white.png"
let optionAE = importDefault "../jpg/logo-amex.jpg"

let listItem logo  =
    li [ Class "list-item" ]
        [ img [ Src logo ] ]

let FooterBottomElement =
    FunctionComponent.Of(fun () ->
        div [ Class "footer-row footer-bottom" ]
            [ div [ Class "footer-col" ]
                [ img [ Class "logo"
                        Src optionSp ]
                  div [ Class "copy" ] [ "@ 2018 Verktygsproffsen.se" |> str ] ]

              div [ Class "footer-col" ]
                [ div [ Class "footer-text" ] [ "Här handlar du tryggt med:" |> str ]
                  ul [ Class "list" ]
                    [ optionKlarna |> listItem
                      optionSvea |> listItem
                      optionVisa |> listItem
                      optionMC |> listItem
                      optionAE |> listItem ] ] ]
    )

storiesOf("Verktygsproffsen|Footer").add("Bottom", fun _ -> FooterBottomElement()) |> ignore

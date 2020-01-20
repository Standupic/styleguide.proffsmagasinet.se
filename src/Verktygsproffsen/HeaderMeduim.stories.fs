module PM.StyleGuide.Verktygsproffsen.HeaderMeduim

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open PM.StyleGuide.Verktygsproffsen.HeaderCart
open PM.StyleGuide.Verktygsproffsen.HeaderSearch
open CommonTypes
open Fable.Core.JsInterop


let logo: string = importDefault "../images/svg/logo-sp.svg"

let HeaderMeduim =
    FunctionComponent.Of(fun () ->
      div [ Class "container" ]
        [ div [ Class "header-meduim" ]
            [ div [ Class "header-columns" ]
                [ div [ Class "column" ]
                   [ a [ ]
                       [ img [ Src logo ] ]
                     HeaderSearch { Search = "" }
                    ]
                  div [ Class "column" ] [
                      HeaderCart {
                        AccountType = B2B
                        Quantity = 3
                        Total = "0 kr"
                        TotalWithTax = "10100 kr"
                        }
                  ]
                ]
            ]
        ]
    )

storiesOf("Verktygsproffsen|Header").add("HeaderMeduim", HeaderMeduim) |> ignore
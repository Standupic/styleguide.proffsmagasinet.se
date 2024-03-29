module PM.StyleGuide.Verktygsproffsen.Popup


open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

let closeImg: string = importDefault "../images/svg/close.svg"

type PopUpProps = { Text: string }

let getText text =
     div [ Class "popup-text" ] [str text]

let Popup =
    FunctionComponent.Of(fun (props : PopUpProps) ->

      div [ Class "popup" ]

        [ div [ Class "popup-close" ]
            [ img [ Src closeImg ] ]

          div [ Class "popup-inner" ]
            [ getText (sprintf "%s;" props.Text)

              div [ Class "popup-actions" ]
                [ a [ Class "btn __black" ]
                    [ str "Företag"
                      span [ Class "small" ] [ str "EX. MOMS" ]]
                  a [ Class "btn __orange" ]
                    [ str "Privatperson"
                      span [ Class "small" ] [ str "INK. MOMS" ]
                    ]
                ]
            ]

        ]
    )



storiesOf("Verktygsproffsen|Popup").add("popup", fun _ -> Popup {Text = "Vänligen välj företag eller privat"}) |> ignore

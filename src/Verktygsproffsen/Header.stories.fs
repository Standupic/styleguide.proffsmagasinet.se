module PM.StyleGuide.Verktygsproffsen.Header

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

let iconTrack : string = importDefault "../svg/icon-truk.svg"

type AccountType =
    | B2B
    | B2C

type AccountTypeProps =
    { AccountType : AccountType }


let Top =
    FunctionComponent.Of(fun ( props : AccountTypeProps ) ->

        let textValue =  [ "Privatperson"; "Företag"; ]

        let organizationFor account =
            match account with
            | B2C ->
                "499"

            | B2B ->
                "625"

        let getAdress account =
            sprintf "FRI FRAKT ÖVER %s KR EXKL. MOMS" account

        let templateLabel s  =
             label [ Class "form-control" ]
                [ input [ Name "accessType"; Type "radio"]
                  span [ Class "switch" ] [ ]
                  span [ Class "name" ] [ str (sprintf "%s" s)]
                ]

        div [ Class "container" ]

            [ div [ Class "top" ]

                [ div [ Class "top-inner __responsive" ]

                    [ div [ Class "columns" ]
                        [ div [ Class "top-column" ]

                            [ div [ Class "top-text" ]
                                [ span [] [ str "Kontakta oss " ]
                                  span [ Class "bold" ]
                                    [ str  "018 444 45 25" ] ] ]

                          div [ Class "top-column" ]

                            [
                              span [ ]
                                [ str (organizationFor props.AccountType |> getAdress) ]
                            ]

                          div [ Class "top-column" ]
                            [ form [ Class "top-form" ]
                                (textValue |> List.map templateLabel)
                            ]
                        ]
                    ]
                ]
            ]
    )
storiesOf("Header").add("top", fun _ -> Top {AccountType = B2C} ) |> ignore
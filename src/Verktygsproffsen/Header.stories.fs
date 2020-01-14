module PM.StyleGuide.Verktygsproffsen.Header

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

type AccountType =
    | B2B
    | B2C

type AccountTypeProps =
    { AccountType : AccountType }

let freeDeliveryText = function
    | B2C -> "FRI FRAKT ÖVER 625 KR INCL. MOMS"
    | B2B -> "FRI FRAKT ÖVER 499 KR EXKL. MOMS"
let getAccountLabel = function
    | B2C -> "Privatperson"
    | B2B -> "Företag"

let Top =
    FunctionComponent.Of(fun ( props : AccountTypeProps ) ->

        let accountTypeSwitchOption accountType =
            label [ Class "form-control" ]
                [ input [ Name "accessType"
                          Type "radio"
                          OnChange ignore
                          Checked (accountType = props.AccountType)
                         ]
                  span [ Class "switch" ] [ ]
                  span [ Class "name" ] [ str (accountType |> getAccountLabel)]
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
                            [ span [ ] [ str (freeDeliveryText props.AccountType) ] ]

                          div [ Class "top-column" ]
                            [ form [ Class "top-form" ]
                                [ accountTypeSwitchOption B2C
                                  accountTypeSwitchOption B2B
                                ]
                            ]
                        ]
                    ]
                ]
            ]
    )
storiesOf("Verktygsproffsen|Header").add("Top", fun _ -> Top {AccountType = B2B} ) |> ignore
module PM.StyleGuide.Verktygsproffsen.HeaderTop

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open CommonTypes


type HeaderTopProps =
    {
        AccountType : AccountType
        PhoneNumber : string
    }

let freeDeliveryText = function
    | B2C -> "FRI FRAKT ÖVER 625 KR INCL. MOMS"
    | B2B -> "FRI FRAKT ÖVER 499 KR EXKL. MOMS"

let getAccountLabel = function
    | B2C -> "Privatperson"
    | B2B -> "Företag"

let HeaderTop =
    FunctionComponent.Of(fun ( props : HeaderTopProps ) ->


        let accountTypeSwitchOption accountType =
            label [ Class "form-control" ]
                [ input [ Name "accessType"
                          Type "radio"
                          OnChange ignore
                          Checked (accountType = props.AccountType)
                         ]
                  span [ Class "switch" ] [ ]
                  span [ Class "name" ] [ accountType |> getAccountLabel |> str ]
                ]

        div [ Class "container" ]

            [ div [ Class "top" ]

                [ div [ Class "top-inner __responsive" ]

                    [ div [ Class "columns" ]
                        [ div [ Class "top-column" ]

                            [ div [ Class "top-text" ]
                                [ span [] [ str "Kontakta oss " ]
                                  span [ Class "bold" ]
                                    [ str  (props.PhoneNumber)] ] ]

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

storiesOf("Verktygsproffsen|HeaderTop").add("HeaderTop", fun _ ->
        HeaderTop {
                    AccountType = B2B
                    PhoneNumber = "018 444 45 25"
                 }) |> ignore
module PM.StyleGuide.Verktygsproffsen.Header

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

let iconTrack : string = importDefault "../svg/icon-truk.svg"

type FormOrganization =
    | Physical
    | Legal

type Face =
    {
      Face : FormOrganization
    }

let Top =
    FunctionComponent.Of(fun ( props : Face ) ->

        let organizationFor face =
            match face with
            | Physical ->
                "499"

            | Legal ->
                "625"

        let getAdress face =
            sprintf "FRI FRAKT ÖVER %s KR EXKL. MOMS" face

        let getStr param =
            param |> organizationFor |> getAdress

        div [ Class "container" ]

            [ div [ Class "top" ]

                [ div [ Class "top-inner __responsive" ]

                    [ div [ Class "columns" ]
                        [ div [ Class "top-column" ]

                            [ div [ Class "top-text" ]
                                [ span [] [ str "Kontakta oss " ]
                                  span [ Class "bold" ]
                                    [ str  "018 444 45 25" ] ] ]

                          div [ Class "top-column" ] // adress

                            [ img [ Src iconTrack
                                    Alt "" ]
                              span [ ]
                                [ str (organizationFor props.Face |> getAdress) ]
                            ]

                          div [ Class "top-column" ] // face

                            [ form [ Class "top-form" ]
                                [ label [ Class "form-control"
                                          HTMLAttr.Custom ("htmlFor", "privat")
                                          Id "privatLabel" ]
                                    [ input [ Name "accessType"
                                              Id "privat"
                                              Type "radio"
                                              Value "customer" ]
                                      span [ Class "switch" ]
                                        [ ]
                                      span [ Class "name" ]
                                        [ str "Privatperson" ] ]
                                  label [ Class "form-control"
                                          HTMLAttr.Custom ("htmlFor", "foretag")
                                          Id "foretagLabel" ]
                                    [ input [ Name "accessType"
                                              Id "foretag"
                                              Type "radio"
                                              Value "organization" ]
                                      span [ Class "switch" ]
                                        [ ]
                                      span [ Class "name" ]
                                        [ str "Företag" ] ] ]
                                    ]
                            ]
                        ]
                    ]
                ]
    )
storiesOf("Header").add("top", fun _ -> Top {Face = Physical} ) |> ignore
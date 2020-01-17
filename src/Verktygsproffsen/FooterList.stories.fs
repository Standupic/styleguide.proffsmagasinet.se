module PM.StyleGuide.Verktygsproffsen.FooterList

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let listItems : string List = [ "Vanliga frågor" ; "Kontakta oss" ; "Försäljning- och leveransvilkor" ; "Retur" ; "Reklamation & Garanti" ;
                                "Lediga tjänster" ; "Vår webb" ; "Personuppgifter" ; "Cookies och GDPR" ]

let FooterListElement =
    FunctionComponent.Of(fun () ->

        let listItem childElement =
            li [ ] [ childElement ]

        let anchorTag url text =
            a [ Href url ] [ text |> str ]

        div [ Class "footer-row" ]
            [ div [ Class "footer-col" ]
                [ div [ Class "list" ]
                    [ div [ Class "list-t" ] [ "Kontakta" |> str ]
                      "info@verktygsproffsen.se" |> anchorTag "mailto:info@verktygsproffsen.se"
                      div [ Class "list-t" ] [ "018 444 45 25" |> str ]
                      "Telefon Må-Fr: 07-16" |> str |> listItem ]

                  ul [ Class "list" ]
                    [ li [ Class "list-t" ] [ "Kundtjänst" |> str ]
                      (listItems |> List.map anchorTag "#" >> listItem) ] ] ]
    )

storiesOf("Verktygsproffsen|Footer").add("List", fun _ -> FooterListElement()) |> ignore

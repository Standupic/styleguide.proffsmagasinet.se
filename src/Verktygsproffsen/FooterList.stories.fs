module PM.StyleGuide.Verktygsproffsen.FooterList

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let anchorTag url text =
    a [ Href url ] [ text |> str ]

let FooterListElement =
    FunctionComponent.Of(fun () ->
        div [ Class "footer-row" ]
            [ div [ Class "footer-col" ]
                [ div [ Class "list" ]
                    [ div [ Class "list-t" ] [ "Kontakta" |> str ]
                      anchorTag "mailto:info@verktygsproffsen.se" "info@verktygsproffsen.se"
                      div [ Class "list-t" ] [ "018 444 45 25" |> str ]
                      span [ ] [ "Telefon Må-Fr: 07-16" |> str ] ]

                  ul [ Class "list" ]
                    [ li [ Class "list-t" ] [ "Kundtjänst" |> str ]
                      li [ ] [ anchorTag "#" "Vanliga frågor" ]
                      li [ ] [ anchorTag "#" "Kontakta oss" ]
                      li [ ] [ anchorTag "#" "Försäljning- och leveransvilkor" ]
                      li [ ] [ anchorTag "#" "Retur" ]
                      li [ ] [ anchorTag "#" "Reklamation & Garanti" ]
                      li [ ] [ anchorTag "#" "Lediga tjänster" ]
                      li [ ] [ anchorTag "#" "Vår webb" ]
                      li [ ] [ anchorTag "#" "Personuppgifter" ]
                      li [ ] [ anchorTag "#" "Cookies och GDPR" ] ] ] ]
    )

storiesOf("Verktygsproffsen|Footer").add("List", fun _ -> FooterListElement()) |> ignore

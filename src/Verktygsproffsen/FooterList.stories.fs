module PM.StyleGuide.Verktygsproffsen.FooterList

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let FooterListElement =
    FunctionComponent.Of(fun () ->

        div [ Class "footer-bot" ] 

            [ div [ Class "footer-row" ] 

                [ div [ Class "footer-col" ] 

                    [ ul [ Class "list" ]                     
                        [ li [ Class "list-t" ] [ str "Kontakta" ] 
                          li [ ] [ a [ Href "mailto:info@verktygsproffsen.se" ] [ str "info@verktygsproffsen.se" ] ] 
                          li [ Class "list-t" ] [ str "018 444 45 25" ] 
                          li [ ] [ str "Telefon Må-Fr: 07-16" ] ]

                      ul [ Class "list" ]                       
                        [ li [ Class "list-t" ] [ str "Kundtjänst" ] 
                          li [ ] [ a [ Href "#" ] [ str "Vanliga frågor" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Kontakta oss" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Försäljning- och leveransvilkor" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Retur" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Reklamation & Garanti" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Lediga tjänster" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Vår webb" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Personuppgifter" ] ] 
                          li [ ] [ a [ Href "#" ] [ str "Cookies och GDPR" ] ] 
                        ]
                    ]
                ]
            ]
    )

storiesOf("Verktygsproffsen|Footer").add("List", fun _ -> FooterListElement()) |> ignore

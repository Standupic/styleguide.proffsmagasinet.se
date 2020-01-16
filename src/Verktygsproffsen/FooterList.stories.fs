module PM.StyleGuide.Verktygsproffsen.FooterList

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let listItems = [ "Vanliga frågor"; "Kontakta oss"; "Försäljning- och leveransvilkor"; "Retur"; "Reklamation & Garanti"; 
                  "Lediga tjänster"; "Vår webb"; "Personuppgifter"; "Cookies och GDPR" ]

let FooterListElement =
    FunctionComponent.Of(fun () ->

        let ListItem childElement = 
            li [ ] [ childElement ]

        let AnchorTag url text = 
            a [ Href url ] [ text |> str ]

        div [ Class "footer-row" ] 
            [ div [ Class "footer-col" ] 
                [ div [ Class "list" ]                     
                    [ div [ Class "list-t" ] [ "Kontakta" |> str ]
                      "info@verktygsproffsen.se" |> AnchorTag "mailto:info@verktygsproffsen.se"
                      div [ Class "list-t" ] [ "018 444 45 25" |> str ]
                      "Telefon Må-Fr: 07-16" |> str |> ListItem ]

                  ul [ Class "list" ]                       
                    [ li [ Class "list-t" ] [ "Kundtjänst" |> str ]
                      listItems |> List.map (fun text ->  text |> AnchorTag "#" |> ListItem) ] ] ]
    )

storiesOf("Verktygsproffsen|Footer").add("List", fun _ -> FooterListElement()) |> ignore

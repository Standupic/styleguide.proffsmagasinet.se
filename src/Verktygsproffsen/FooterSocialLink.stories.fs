module PM.StyleGuide.Verktygsproffsen.FooterSocialLink

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let FooterListElement =
    FunctionComponent.Of(fun () ->

        div [ Class "footer-bot" ] 

            [ div [ Class "footer-row" ] 

                [ div [ Class "footer-col" ] 

                    [ div [ Class "footer-t" ] [ str "Följ oss för idéer, erbjudanden, och mer!" ]
                    
                      ul [ Class "list list-socials" ]        
                      
                        [ li [ Class "list-item" ] 
                            [ a [ Href "#" ] 
                                [ img [ Src "https://www.verktygsproffsen.se/vid.png" ]
                                  str "Videos" ] ]
                                  
                          li [ Class "list-item" ] 
                            [ a [ Href "#" ] 
                                [ img [ Src "https://www.verktygsproffsen.se/icon-facebook.svg" ]
                                  str "Facebook" ] ] 
                        ]
                    ]
                ]
            ]
    )

storiesOf("Verktygsproffsen|Footer").add("SocialLinks", fun _ -> FooterListElement()) |> ignore

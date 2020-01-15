module PM.StyleGuide.Verktygsproffsen.FooterTop

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

type AccountType =
    | B2B
    | B2C

type AccountTypeProps =
    { AccountType : AccountType }

let freeDeliveryDescription = function
    | B2C -> "På beställningar över 625 kr inkl. moms"
    | B2B -> "På beställningar över 499 kr inkl. moms"

let openPurchaseDescription = "Gäller för obrukad maskin i hela 30 dagar"
let secureEcomerceDescription = "Vi använder säkra och tillförlitliga betalsystem"

let freeDeliveryFigure = "https://www.verktygsproffsen.se/themes/assets/static/icon-truck-2.svg"
let openPurchaseFigure = "https://www.verktygsproffsen.se/themes/assets/static/icon-box.svg"
let secureEcomerceFigure = "https://www.verktygsproffsen.se/themes/assets/static/icon-lock.svg"

// Footer Top Elements
  
let FooterTopElement =
    FunctionComponent.Of(fun ( props : AccountTypeProps ) ->

        div [ Class "footer-top" ] 

            [ div [ Class "footer-adv responsive" ] 

                [ div [ Class "footer-col" ]        
                
                    [ figure [] [ img [ Src freeDeliveryFigure ] ]
                                                
                      div [ Class "footer-other" ]     
                        [ 
                            div [ Class "footer-t" ] [ str "Fri Frakt" ]
                    
                            div [ Class "footer-descr" ] [ props.AccountType |> freeDeliveryDescription |> str ] 
                        ] 
                    ] 

                  div [ Class "footer-col" ]        
                  
                    [ figure [] [ img [ Src openPurchaseFigure ] ]
                                                  
                      div [ Class "footer-other" ]     
                        [ 
                            div [ Class "footer-t" ] [ str "Öppet köp" ]
                      
                            div [ Class "footer-descr" ] [ str openPurchaseDescription ] 
                        ] 
                    ]

                  div [ Class "footer-col" ]        
                  
                    [ figure [] [ img [ Src secureEcomerceFigure ] ]
                                                  
                      div [ Class "footer-other" ]     
                        [ 
                            div [ Class "footer-t" ] [ str "Trygg e-handel" ]
                      
                            div [ Class "footer-descr" ] [ str secureEcomerceDescription ] 
                        ] 
                    ] 
                ] 
            ]
    )

storiesOf("Verktygsproffsen|Footer").add("Top", fun _ -> FooterTopElement{AccountType = B2C}) |> ignore

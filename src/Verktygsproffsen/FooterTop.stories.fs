module PM.StyleGuide.Verktygsproffsen.FooterTop

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

type AccountType =
    | B2B
    | B2C

type AccountTypeProps =
    { AccountType : AccountType }

type ColumnProps = {
    ImageUrl : string
    Title : string
    Description : string
}

let openPurchaseDescription = "Gäller för obrukad maskin i hela 30 dagar"
let secureEcomerceDescription = "Vi använder säkra och tillförlitliga betalsystem"

let freeDeliveryImg: string = importDefault "../svg/icon-truck-gray.svg"
let openPurchaseImg: string = importDefault "../svg/icon-box.svg"
let secureEcomerceImg: string = importDefault "../svg/icon-lock.svg"

// Footer Top Elements

let FooterTopElement =
    FunctionComponent.Of(fun ( props : AccountTypeProps ) ->

        let freeDeliveryDescription = function
            | B2C -> "På beställningar över 625 kr inkl. moms"
            | B2B -> "På beställningar över 499 kr inkl. moms"

        let columns : ColumnProps List = [ { ImageUrl = freeDeliveryImg
                                             Title = "Fri Frakt"
                                             Description = props.AccountType |> freeDeliveryDescription }
                                           { ImageUrl = openPurchaseImg
                                             Title = "Öppet köp"
                                             Description = openPurchaseDescription }
                                           { ImageUrl = secureEcomerceImg
                                             Title = "Trygg e-handel"
                                             Description = secureEcomerceDescription } ]

        let footerColumn columnProps =
            div [ Class "footer-col" ]
              [ figure [] [ img [ Src columnProps.ImageUrl ] ]
                div [ Class "footer-other" ]
                  [ div [ Class "footer-t" ] [ columnProps.Title |> str ]
                    div [ Class "footer-descr" ] [ columnProps.Description |> str ] ] ]

        div [ Class "footer-top" ]
            [ div [ Class "footer-adv responsive" ] (columns |> List.map footerColumn) ]
    )

storiesOf("Verktygsproffsen|Footer").add("Top", fun _ -> FooterTopElement{AccountType = B2C}) |> ignore

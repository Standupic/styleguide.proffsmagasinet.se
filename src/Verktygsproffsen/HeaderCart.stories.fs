module PM.StyleGuide.Verktygsproffsen.HeaderCart


open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open CommonTypes


type HeaderCartProps =
    {
        AccountType : AccountType
        Quantity : int
        Total : string
        TotalWithTax : string
    }


let HeaderCart =
    FunctionComponent.Of(fun (props : HeaderCartProps) ->

    let accountTypeSwitchTax = function
    | B2B -> props.Total
    | B2C -> props.TotalWithTax

    div [ Class "header-cart" ]

        [ div [ Class "count" ]
              [ ofInt props.Quantity ]
          div [ Class "count" ]
              [ str (accountTypeSwitchTax props.AccountType) ]
          div [ Class "cart-ico" ]
              [ ]
        ]

    )

storiesOf("Verktygsproffsen|Header").add("HeaderCart", fun _ ->
    HeaderCart {
                 AccountType = B2B
                 Quantity = 3
                 Total = "100 kr"
                 TotalWithTax = "10100 kr"
               }) |> ignore
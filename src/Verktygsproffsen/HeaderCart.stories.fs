module PM.StyleGuide.Verktygsproffsen.HeaderCart

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

type AccountType =
    | B2B
    | B2C

type TypeProps = {
    AccountType : AccountType
    quantity : int
    total: int
}

let accountTypeSwitchTax = function
    | B2B -> 100
    | B2C -> 0

let HeaderCart =
    FunctionComponent.Of(fun (props : TypeProps) ->

    let getInvoice tax total =
        (tax + total).ToString() + " Kr"

    div [ Class "header-cart" ]

        [ div [ Class "count" ]
              [ str ((sprintf "%d" props.quantity)) ]
          div [ Class "count" ]
              [ str ((accountTypeSwitchTax props.AccountType) |> getInvoice props.total) ]
          div [ Class "cart-ico" ]
              [ ]
        ]
    )

storiesOf("Verktygsproffsen|Header").add("HeaderCart", fun _ ->
    HeaderCart {
                 AccountType = B2B
                 quantity = 3
                 total = 1000
               }) |> ignore
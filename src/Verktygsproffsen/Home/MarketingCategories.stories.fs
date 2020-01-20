module PM.StyleGuide.Verktygsproffsen.MarketingCategories

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let marketingCategories = [
    "Arbetsplats & förvaring"
    "El & VVS"
    "Handverktyg & verkstad"
    "Maskiner & Elverktyg"
    "Maskintillbehör & förbrukning"
    "Mäta, sök & märk"
    "Skog, trädgård & rengöring"
    "Skydd & arbetskläder"
]

let listItem text =
    li [ Class "list-item" ]
        [ a [ Href "#"
              Class "list-link" ]
            [ str text ] ]

let Categories =
    FunctionComponent.Of(fun () ->
        ul [ Class "marketing-categories" ]
            (marketingCategories |> List.map listItem)
    )

storiesOf("Verktygsproffsen|Home").add("Marketing Categories", fun _ -> Categories() ) |> ignore

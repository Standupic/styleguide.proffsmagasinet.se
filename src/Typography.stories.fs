module PM.StyleGuide.TypographyStories

open Fable.Core
open Fable.Core
open Fable.React
open Fable.Core.JsInterop
open Fable.React.Props
open PM.StyleGuide.Storybook

let heading = "Hamburgefonstiv"
let lorem = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim."


type TypographyProps = {
    Name : string
    Font : string
    Color : string
    FontSize : string
    LineHeight : string
    Weight : string
    Element : string
    FontStyle : string
    Text : string
}

let Typography =
    FunctionComponent.Of (fun (props : TypographyProps) ->
        let lbl text =
            div [ Style [ Opacity 0.4; Color "rgb(17, 38, 63)" ] ] [ str text ]
        let styles =
            [
                FontSize props.FontSize
                LineHeight props.LineHeight
                Color props.Color
                FontStyle props.FontStyle
                FontWeight props.Weight
                FontFamily props.Font
            ] |> keyValueList CaseRules.LowerFirst
        let p = [!!("style", styles)] |> keyValueList CaseRules.LowerFirst

        div [
            Style [
                Width 1024
                Margin 30
            ]
        ] [
            div [
                    Style [
                        FontWeight 700
                        MarginTop 5
                        MarginBottom 5
                    ]
                ] [ str props.Name ]
            div [
                    Style [
                        MarginTop 5
                        MarginBottom 5
                    ]
                ] [ str props.Font ]
            div [
                    Style [
                        BackgroundColor "white"
                        Padding 20
                    ]
                ] [
                    lbl (sprintf "%s (%s/%s)" props.Element props.FontSize props.LineHeight)
                    ReactElementType.create (ReactElementType.ofHtmlElement props.Element) p [ str props.Text ]
                    lbl (sprintf "color: %s;" props.Color)
                    lbl (sprintf "font-weight: %s;" props.Weight)
                    lbl (sprintf "font-style: %s;" props.FontStyle)
                ]
        ]
        )

let Typographies =
    FunctionComponent.Of (fun () ->
        div []
            ([
                {
                    Name = "Headings"
                    Element = "h1"
                    FontSize = "98px"
                    LineHeight = "98px"
                    Color = "#11263F"
                    FontStyle = "normal"
                    Weight = "100"
                    Font = "Kelp A3 Black Italic"
                    Text = heading
                }
                {
                    Name = "Ingress"
                    Element = "p"
                    FontSize = "16px"
                    LineHeight = "24px"
                    Color = "#11263F"
                    FontStyle = "bold"
                    Weight = "700"
                    Font = "DM Sans"
                    Text = lorem
                }
                {
                    Name = "Normal Paragraph"
                    Element = "p"
                    FontSize = "16px"
                    LineHeight = "24px"
                    Color = "#11263F"
                    FontStyle = "normal"
                    Weight = "100"
                    Font = "DM Sans"
                    Text = lorem
                }
             ]
             |> List.map Typography)
        )

storiesOf("Typography")
    .add("Typography", Typographies)
    |> ignore
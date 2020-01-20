module PM.StyleGuide.ColorsStories

open PM.StyleGuide

open System
open Fable.React
open Fable.React.Props
open Storybook

type ColorProps = {
   Name : string
   HexColor : string
   RgbaColor : string
}


let ColorRect =
    FunctionComponent.Of (fun (props : ColorProps) ->
        let colorLabel color =
            div [
                Style [
                    Color "rgb(51, 51, 51)"
                    FontSize "1rem"
                    LineHeight 1.4
                    MarginTop 5
                    MarginBottom 5
                ]
            ] [ str color ]

        div [
            Style [
                Margin 10
                Width 160
                Display DisplayOptions.InlineBlock
            ]
        ] [
            div [
                Style [
                    Width 160
                    Height 120
                    BackgroundColor props.RgbaColor
                ]
            ] []
            colorLabel props.HexColor
            colorLabel props.RgbaColor
        ]
    )
let MainColors =
    FunctionComponent.Of(fun () ->
        let colors = [
            { Name = "Main"
              HexColor = "#11263F"
              RgbaColor = "rgba(17, 38, 63, 1)" }
            { Name = ""
              HexColor = "#53687F"
              RgbaColor = "rgba(83, 104, 127, 1)" }
            { Name = ""
              HexColor = "#266867"
              RgbaColor = "rgba(38, 104, 103, 1)" }
            { Name = ""
              HexColor = "#00E79F"
              RgbaColor = "rgba(0, 231, 159, 1)" }
            { Name = ""
              HexColor = "White"
              RgbaColor = "rgba(255, 255, 255, 1)" }
            { Name = ""
              HexColor = "#EFF0F1"
              RgbaColor = "rgba(239, 240, 241, 1)" }
            { Name = ""
              HexColor = "#FF5C69"
              RgbaColor = "rgba(255, 92, 105, 1)" }
            { Name = ""
              HexColor = "#3380FF"
              RgbaColor = "rgba(51, 128, 255, 1)" }
            { Name = ""
              HexColor = "#508FFF"
              RgbaColor = "rgba(80, 143, 255, 1)" }
        ]
        div [] (colors |> List.map (fun c -> ColorRect c))
    )

type PaletteProps = {
    Colors : string list
}

let paletteRect color =
    div [
        Style [
            BackgroundColor color
            Width 150
            Height 60
            Display DisplayOptions.InlineBlock
            LineHeight "60px"
            MixBlendMode "difference"
            Color "white"
            PaddingLeft 10
        ]
    ] [ str color ]


let PaletteSeq =
    FunctionComponent.Of (fun (props : PaletteProps) ->
        div [
            Style [
                Margin 10
            ]
        ] (props.Colors |> List.map paletteRect)
    )

let Palette =
    FunctionComponent.Of (fun () ->
        let palettes =
            [
                [ "#4D4D8D"; "#5858A0"; "#8080BF"; "#928FCC"; "#B8B6E2"; "#C5C5EA" ]
                [ "#3A5177"; "#45608C"; "#6183AA"; "#7899BF"; "#9ABBDA"; "#A7C7E2" ]
                [ "#195B70"; "#257284"; "#3C959E"; "#6EB0B7"; "#8FCCD1"; "#9ED6D8" ]
                [ "#2E5945"; "#376B53"; "#56967A"; "#61A883"; "#84C6A2"; "#9DCEB1" ]
                [ "#985603"; "#B46604"; "#DBA145"; "#F0B658"; "#FFDB7F"; "#FFE19F" ]
                [ "#A52B00"; "#B24722"; "#E2765D"; "#E88E78"; "#F9B5A0"; "#FFC4B0" ]
                [ "#AD0015"; "#B2261F"; "#DD6464"; "#E58585"; "#FCA9A9"; "#FFB6B6" ]
                [ "#B01261"; "#BC1B6C"; "#D65F8D"; "#E48CAC"; "#F3B3CB"; "#FFC2DB" ]
                [ "#56646A"; "#5F6E75"; "#868D98"; "#A1A9AF"; "#BFC7CD"; "#DADEE0" ]
            ]
        div [] (palettes |> List.map (fun p -> PaletteSeq { Colors = p })))

storiesOf("Styles|Colors")
    .add("Main Colors", MainColors)
    .add("Palette", Palette)
    |> ignore

module PM.StyleGuide.Logos

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let ProffsmagasinetLogo =
    FunctionComponent.Of (fun () ->
        span [ ClassName "logo_proffsmagasinet" ] [] )

let StayProLogo =
    FunctionComponent.Of (fun () ->
        span [ ClassName "logo_staypro" ] [] )

let ProLogo =
    FunctionComponent.Of (fun () ->
        span [ ClassName "logo_pro" ] [] )

let ProShapeLogo =
    FunctionComponent.Of (fun () ->
        span [ ClassName "logo_proshape" ] [] )

storiesOf("Logos")
    .add("Proffsmagasinet", ProffsmagasinetLogo)
    .add("StayPro", StayProLogo)
    .add("Pro", ProLogo)
    .add("Pro shape", ProShapeLogo)
    |> ignore

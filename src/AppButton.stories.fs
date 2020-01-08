module AppButton

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

let MyButton =
    FunctionComponent.Of (fun () -> div [ Class "display-flex" ] [ str "Hi!" ])
    
storiesOf("MyButton").add("MyButton", fun _ -> MyButton()) |> ignore


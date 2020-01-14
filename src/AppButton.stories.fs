module AppButton

open Fable.React
open PM.StyleGuide.Storybook



let MyButton =
    FunctionComponent.Of (fun () -> div [] [ str "HellO!!" ])

storiesOf("MyButton").add("MyButton", fun _ -> MyButton()) |> ignore

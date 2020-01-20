module PM.StyleGuide.Verktygsproffsen.DropDownMenu

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

type Category =
    {
        Name : string
        Url : string
        Children : Category list
    }


let getString = function
    | false ->
        "Close"
    | true ->
        "Open"

let SubMenu =
    FunctionComponent.Of(fun (props: {|initOpen : bool; name : string; url : string|}) ->

        let state = Hooks.useState(props.initOpen)

        li [ classList ["open", true;  "close", false]
             OnMouseEnter (fun _ -> state.update(fun s -> true))
             OnMouseLeave (fun _ -> state.update(fun s -> false))]
             [ str (getString state.current)
               a [ Href props.url ] [ str props.name ]
             ]

    )


let rec toCategoriesHtml (categories : Category list, submenu : ReactElementType) =
    categories |> List.map (fun c ->
        let catLi = li [ Class "cat "]
        let catA = a [ Href c.Url ] [ str c.Name ]
        match c.Children with
        | [] -> catLi [ catA ]
        | children -> submenu {|initOpen = false; name = c.name; url = c.url|} [ul [][toCategoriesHtml(children)]]

storiesOf("Verktygsproffsen|Header").add("DropDownMenu", fun _ ->
        SubMenu {|initOpen = false|} )|> ignore
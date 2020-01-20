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

type ListItemProps =
    {
        name : string
        url : string
        children : ReactElement list
    }

let ListItems =
    FunctionComponent.Of(fun (props: ListItemProps ) ->

        let state = Hooks.useState(false)

        li [   OnMouseEnter (fun _ -> state.update(fun s -> true))
               OnMouseLeave (fun _ -> state.update(fun s -> false))]
             [
               a [ Href props.url ] [ str props.name ]
               if not props.children.IsEmpty && state.current then ul [ Class "open"] props.children
             ]
    )



let rec toCategoriesHtml (categories : Category list) =
    categories
    |> List.map (fun c ->
        let listItemProps = {name = c.Name; url = c.Url; children = []}
        match c.Children with
        | [] -> ListItems listItemProps
        | children ->
             let childrenLI = toCategoriesHtml(children)
             ListItems { listItemProps with children = childrenLI }
    )


let DropDownMenu =
    FunctionComponent.Of(fun (props: Category list) ->
        ul [] (props |> toCategoriesHtml)
    )


let categories = [
     {Name = "Car"; Url = "www"; Children = [{ Name = "Audi"; Url = "www";
                                              Children = [
                                                          { Name = "A1"; Url = "www"; Children = []}
                                                          { Name = "A4"; Url = "www"; Children = []}
                                                          { Name = "A6"; Url = "www"; Children = []}
                                                          { Name = "A8"; Url = "www"; Children = []}
                                                         ]
                                             }
                                             { Name = "BMW"; Url = "www";
                                              Children = [
                                                         { Name = "X1"; Url = "www";
                                                         Children = [
                                                                      { Name = "2001"; Url = "www"; Children = []}
                                                                      { Name = "2002"; Url = "www"; Children = []}
                                                                      { Name = "2003"; Url = "www"; Children = []}
                                                                      { Name = "2005"; Url = "www"; Children = []}
                                                         ]}
                                                         { Name = "X3"; Url = "www"; Children = []}
                                                         { Name = "X5"; Url = "www"; Children = []}
                                                         { Name = "X6"; Url = "www"; Children = []}
                                                        ]
                                             }
                                             ]}
     {Name = "Moto"; Url = "www"; Children = [{ Name = "Honda"; Url = "www";
                                                Children = [
                                                           { Name = "XR"; Url = "www"; Children = []}
                                                           { Name = "R"; Url = "www"; Children = []}
                                                           { Name = "Ninja"; Url = "www"; Children = []}
                                                           { Name = "RS"; Url = "www"; Children = []}
                                                         ]
                                             };
                                             { Name = "BMW"; Url = "www";
                                              Children = [
                                                         { Name = "X1"; Url = "www"; Children = []}
                                                         { Name = "X3"; Url = "www"; Children = []}
                                                         { Name = "X5"; Url = "www"; Children = []}
                                                         { Name = "X6"; Url = "www"; Children = []}
                                                        ]
                                             }
                                             ]}
]

storiesOf("Verktygsproffsen|Header").add("DropDownMenu", fun _ ->
        DropDownMenu categories )|> ignore
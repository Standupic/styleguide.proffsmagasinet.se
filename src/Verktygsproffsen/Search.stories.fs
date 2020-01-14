module PM.StyleGuide.Verktygsproffsen.Search

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

type SearchInputType = {Search: string}

let SearchInput =
    FunctionComponent.Of(fun (props : SearchInputType) ->

        form [ Id "searchForm"
               Class "header-search" ]
         [ input [ Id "searchInput"
                   Class "form-input"
                   Placeholder "What are you looking for?"
                   Type "text" ]
           button [ Class "form-btn"
                    Type "submit" ]
             [ ]
        ]
    )

storiesOf("Header").add("SearchInput", fun _ -> SearchInput {Search = ""}) |> ignore
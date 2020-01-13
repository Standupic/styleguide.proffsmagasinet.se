module PM.StyleGuide.Verktygsproffsen.Search

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

// Should i use <option> type?
// It will get rid of it will get rid of checking on an empty string in future?
// also, allow us to manage behaviour when values no.

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
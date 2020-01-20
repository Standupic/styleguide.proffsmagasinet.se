module PM.StyleGuide.Verktygsproffsen.HeaderSearch

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook

type SearchInputProps = { Keyword: string }

let HeaderSearch =
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

storiesOf("Verktygsproffsen|Header").add("HeaderSearch", fun _ -> HeaderSearch { Keyword = "" }) |> ignore
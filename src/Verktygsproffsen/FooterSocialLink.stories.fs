module PM.StyleGuide.Verktygsproffsen.FooterSocialLink

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

let videoImg: string = importDefault "../png/vid.png"
let facebookImg: string = importDefault "../svg/icon-facebook.svg"

let listItem imageSource text =
    li [ Class "list-item" ]
        [ a [ Href "#" ]
            [ img [ Src imageSource ]
              str text ] ]

let FooterListElement =
    FunctionComponent.Of(fun () ->
        div [ Class "footer-row" ]
            [ div [ Class "footer-col" ]
                [ div [ Class "footer-t" ] [ str "Följ oss för idéer, erbjudanden, och mer!" ]
                  ul [ Class "list list-socials" ]
                    [ listItem facebookImg "Facebook"
                      listItem videoImg "Videos" ] ] ]
    )

storiesOf("Verktygsproffsen|Footer").add("SocialLinks", fun _ -> FooterListElement()) |> ignore

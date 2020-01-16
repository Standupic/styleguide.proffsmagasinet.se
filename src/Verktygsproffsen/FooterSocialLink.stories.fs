module PM.StyleGuide.Verktygsproffsen.FooterSocialLink

open Fable.React
open Fable.React.Props
open PM.StyleGuide.Storybook
open Fable.Core.JsInterop

type SocialLink = {
    ImageSource : string
    Text : string
}

let videoImg: string = importDefault "../png/vid.png"
let facebookImg: string = importDefault "../svg/icon-facebook.svg"

let socialLinks = [ { ImageSource = facebookImg ; Text = "Facebook" }
                    { ImageSource = videoImg ; Text = "Videos" } ]

let FooterListElement =
    FunctionComponent.Of(fun () ->

        let ListItem socialLink = 
            li [ Class "list-item" ] 
                [ a [ Href "#" ] 
                    [ img [ Src socialLink.ImageSource ]
                      str socialLink.Text ] ]

        div [ Class "footer-row" ] 
            [ div [ Class "footer-col" ] 
                [ div [ Class "footer-t" ] [ str "Följ oss för idéer, erbjudanden, och mer!" ]
                  ul [ Class "list list-socials" ] (socialLinks |> List.map (fun socialLink ->  socialLink |> ListItem)) ] ]
    )

storiesOf("Verktygsproffsen|Footer").add("SocialLinks", fun _ -> FooterListElement()) |> ignore

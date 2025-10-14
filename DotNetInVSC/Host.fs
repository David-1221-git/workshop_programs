namespace DotNetInVSC

open Microsoft.AspNetCore.Components
open Microsoft.AspNetCore.Http
open FSharp.Blazor
open FSharp.Blazor.Html
open FSharp.Blazor.App
open DotNetInVSC.Pages

type Host() =
    inherit Component()

    [<Inject>]
    member val HttpContextAccessor : IHttpContextAccessor = null with get, set

    override this.Render () = [
        html [ attr.lang "en" ] [
            head [] [
                meta [ attr.charset "utf-8" ]
                meta [ attr.name "viewport"; attr.content "width=device-width, initial-scale=1.0" ]
                title [] [ text "DotNetInVSC" ]
                link [ attr.rel "stylesheet"; attr.href "css/bootstrap/bootstrap.min.css" ]
                link [ attr.rel "stylesheet"; attr.href "css/site.css" ]
            ]
            body [] [
                app<App> this.HttpContextAccessor.HttpContext
                script [ attr.src "_framework/blazor.server.js" ] []
            ]
        ]
    ]
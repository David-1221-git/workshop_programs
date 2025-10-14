namespace DotNetInVSC.Pages

open System
open System.Threading.Tasks
open Microsoft.AspNetCore.Components
open FSharp.Blazor.Html
open FSharp.Blazor
open DotNetInVSC.Data

[<Route("/fetchdata")>]
type FetchData() =
    inherit Component()

    let mutable forecasts = Option<WeatherForecast list>.None

    [<Inject>]
    member val ForecastService : WeatherForecastService = Unchecked.defaultof<WeatherForecastService> with get, set

    override this.OnInitializedAsync() =
        async {
            let! forecasts' = this.ForecastService.GetForecastAsync(DateTime.Now)
            forecasts <- Some forecasts'
            return ()
        } |> Async.StartAsTask :> Task

    override this.Render () = [
        h1 [] [ text "Weather forecast" ]
        p [] [ text "This component demonstrates fetching data from a service." ]
        cond forecasts <| function
            | None ->
                p [] [ em [] [ text "Loading..." ] ]
            | Some forecasts' ->
                table [ attr.``class`` "table" ] [
                    thead [] [
                        tr [] [
                            th [] [ text "Date" ]
                            th [] [ text "Temp. (C)" ]
                            th [] [ text "Temp. (F)" ]
                            th [] [ text "Summary" ]
                        ]
                    ]
                    tbody [] [
                        forEach forecasts' <| fun forecast ->
                            tr [] [
                                td [] [ forecast.Date.ToShortDateString() |> text ]
                                td [] [ forecast.TemperatureC.ToString() |> text ]
                                td [] [ forecast.TemperatureF.ToString() |> text ]
                                td [] [ text forecast.Summary ]
                            ]
                    ]
                ]
    ]
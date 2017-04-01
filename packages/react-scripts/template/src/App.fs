module App

open Fable.Core
open Fable.Import
open Elmish

// MODEL

type Msg =
  | Increment
  | Decrement

let init () = 0

// UPDATE

let update (msg:Msg) count =
  match msg with
  | Increment -> count + 1
  | Decrement -> count - 1

// rendering views with React
open Fable.Core.JsInterop
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

// helper to require css using webpack
[<Emit("require($0)")>]
let requireCss (file: string): unit = jsNative

requireCss "./app.css"

let view count dispatch =
  let onClick msg =
    OnClick <| fun _ -> msg |> dispatch

  R.div []
    [ R.a [ ClassName "btn" ; onClick Increment ] [ R.str "+" ]
      R.div [ ClassName "counter" ] [ R.str (string count) ]
      R.a [ ClassName "btn" ; onClick Decrement ] [ R.str "-" ] ]

open Elmish.React

// APP

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReact "root"
|> Program.run
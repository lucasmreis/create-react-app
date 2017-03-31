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

let appStyle =
  Style [
    unbox("padding", "20px")
    unbox("font-family", "sans-serif")
    unbox("font-size", "30px")
    unbox("text-align", "center") ]

let btnStyle =
  Style [
    unbox("background-color", "rgb(122, 50, 93)")
    unbox("box-shadow", "0px 5px 0px 0px rgb(104,43,79)")
    unbox("color", "white")
    unbox("font-size", "30px")
    unbox("border-radius", "5px")
    unbox("padding", "15px 25px")
    unbox("text-decoration", "none")
    unbox("margin", "20px")
    unbox("cursor", "pointer")
    unbox("position", "relative")
    unbox("display", "inline-block") ]

let counterStyle =
  Style [ Padding "20px" ]

let view count dispatch =
  let onClick msg =
    OnClick <| fun _ -> msg |> dispatch

  R.div [ appStyle ]
    [ R.a [ btnStyle ; onClick Decrement ] [ R.str "-" ]
      R.div [ counterStyle ] [ R.str (string count) ]
      R.a [ btnStyle ; onClick Increment ] [ R.str "+" ] ]

open Elmish.React

// APP

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReact "root"
|> Program.run
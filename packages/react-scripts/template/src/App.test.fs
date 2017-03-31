module AppTest

open Jest
open App

it "should increment" <| fun _ ->
    toEqual 1 (update Increment 0)

it "should decrement" <| fun _ ->
    toEqual 0 (update Decrement 1)

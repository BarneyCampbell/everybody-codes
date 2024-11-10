module KingdomOfAlgorithmia

open Algorithmia
open System

let aDay (day: int): string =
    match day with
    | 1  -> Day1.solve
    //| 2  -> Day2.solv
    | _ -> ""

let all: string =
    String.concat "\n--- --- ---\n" 
        [
            Day1.solve;
            //Day2.solve
        ]

[<EntryPoint>]
let main (args: string array) =
    if args.Length = 0 then 1
    elif args[0].Equals "all" then 
        printf "%s" all
        0
    else
        try
            args[0]
            |> int
            |> aDay
            |> printf "%s"
            0
            with :? FormatException -> 1
module Algorithmia.Day2

open Lib.Util
open System
open System.Text.RegularExpressions

let getWordsList (words: string): string list =
    match words.Split(":") |> Array.toList with
    | _ :: (xs: string) :: [] -> xs.Split(",") |> Array.toList
    | _ -> []

let getRegexCounter (words: string list) =
    (String.concat "|" >> Regex >> (fun (regex: Regex) (str: string) -> regex.Count str)) words

let rec countOccurences (words: string list) (inscription: string): int =
    match words with
    | []        -> 0
    | x :: []   -> Regex.Count (inscription, x)
    | x :: xs   -> Regex.Count (inscription, x) + countOccurences xs inscription

let part1 (input: string list) =
    match input with
    | words :: _ :: inscription :: [] -> countOccurences (getWordsList words) inscription
    | _                         -> 0

let reverseString (input: string): string = String(input.ToCharArray() |> Array.rev)

let part2 (input: string list) =
    match input with
    | words :: _ :: inscription :: [] -> (countOccurences (getWordsList words) inscription) + (countOccurences (getWordsList words) (reverseString inscription))
    | _                         -> 0

let solve =
    let part1Result = (readFile >> List.ofSeq >> part1) "inputs/day2p1.txt"
    let part2Result = (readFile >> List.ofSeq >> part2) "inputs/day2p2.txt"
    $"Part1: {part1Result}\nPart2: {part2Result}\nPart3: {3}"
module Algorithmia.Day1

open Lib.Util

let singleScore (enemy: char) =
    match enemy with
    | 'B' -> 1
    | 'C' -> 3
    | 'D' -> 5
    | _   -> 0

let part1 (input: char list) =
    List.fold (
        fun acc elem
            -> acc + singleScore elem
            ) 0 input

let pairScore (enemy1: char) (enemy2: char): int =
    match enemy1 with
    | 'B' when enemy2 = 'x' -> 1
    | 'C' when enemy2 = 'x' -> 3
    | 'D' when enemy2 = 'x' -> 5
    | 'A' when enemy2 = 'x' -> 0
    | 'x'                   -> singleScore enemy2
    | _   -> singleScore enemy1 + singleScore enemy2 + 2

let rec part2 (input: char list) =
    match input with
    | []            -> 0
    | x :: y :: xs  -> (pairScore x y) +  part2 xs
    | x :: []       -> pairScore x 'x'

// Part 3, 2 for each non x, then the scores for individual
let listSingleScore = Seq.map singleScore >> Seq.sum

let trioScore (trio: char list) =
    (match (Seq.filter (fun (x: char) -> x <> 'x') >> Seq.length) trio with
    | 2 -> 2
    | 3 -> 6
    | _ -> 0) + listSingleScore trio


let rec part3 (input: char list) =
    match input with
    | []                -> 0
    | x :: y :: z :: xs -> trioScore [x; y; z] + part3 xs
    | _                 -> 0

let solve =
    let part1Result = (readSingleLine >>List.ofSeq >> part1) "inputs/day1p1.txt"
    let part2Result = (readSingleLine >>List.ofSeq >> part2) "inputs/day1p2.txt"
    let part3Result = (readSingleLine >>List.ofSeq >> part3) "inputs/day1p3.txt"
    $"Part1: {part1Result}\nPart2: {part2Result}\nPart3: {part3Result}"
module Lib.Util

open System.IO

let readFile (path: string): list<string> = File.ReadLines path |> Seq.toList
let readSingleLine (path: string): string = (File.ReadLines path |> Seq.toList).Head
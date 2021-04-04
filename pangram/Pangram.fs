module Pangram

let isPangram (input: string): bool =

    let containsChar (c: char): bool =
        input
        |> Seq.toArray
        |> Seq.map System.Char.ToLower
        |> Seq.contains (System.Char.ToLower(c))

    "abcdefghijklmnopqrstuvwxyz"
    |> Seq.toArray
    |> Seq.forall containsChar

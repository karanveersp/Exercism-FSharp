module Pangram

let isPangram (input: string): bool =
    input.ToLower()
    |> Seq.filter System.Char.IsLetter
    |> Seq.distinct
    |> Seq.length = 26

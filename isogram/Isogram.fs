module Isogram

let isIsogram (str: string) =
    let allLetters = str.ToLower() |> Seq.filter System.Char.IsLetter
    let distinctLetters = Set.ofSeq allLetters
    Seq.length distinctLetters = Seq.length allLetters

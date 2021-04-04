// With inspiration from swsch's solution

module PhoneNumber

open System

let cannotStartWith = sprintf "%s code cannot start with %s"

let filterValidPunctuation (input: string) =
    input.ToCharArray()
    |> Array.filter (fun c -> Seq.contains c "()-+. " |> not)
    |> Ok

let filterDigits (input: char []) = input |> Array.filter Char.IsDigit

let cleanCountryCode (input: char []) =
    let digits = filterDigits input
    match Array.length digits with
    | n when n < 10 -> Error "incorrect number of digits"
    | 10 -> Ok digits
    | 11 ->
        if digits.[0] = '1' then Ok digits.[1..] else Error "11 digits must start with 1"
    | _ -> Error "more than 11 digits"

let cleanAreaCode (input: char []) =
    let digits = filterDigits input
    match digits.[0] with
    | '0' -> cannotStartWith "area" "zero" |> Error
    | '1' -> cannotStartWith "area" "one" |> Error
    | _ -> Ok digits

let cleanExchangeCode (input: char []) =
    let digits = filterDigits input
    match digits.[3] with
    | '0' -> cannotStartWith "exchange" "zero" |> Error
    | '1' -> cannotStartWith "exchange" "one" |> Error
    | _ -> Ok digits

let checkHasLetters (input: char []) =
    if Array.exists Char.IsLetter input then "letters not permitted" |> Error else Ok input

let checkHasPunctuation (input: char []) =
    if Array.exists Char.IsPunctuation input then "punctuations not permitted" |> Error else Ok input

let toUnsignedLong (input: char []) =
    ("", input)
    |> String.Join
    |> uint64


let clean =
    filterValidPunctuation
    >> Result.bind checkHasLetters
    >> Result.bind checkHasPunctuation
    >> Result.bind cleanCountryCode
    >> Result.bind cleanAreaCode
    >> Result.bind cleanExchangeCode
    >> Result.map toUnsignedLong

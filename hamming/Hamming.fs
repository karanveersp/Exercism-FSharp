module Hamming

let distance (strand1: string) (strand2: string): int option =
    if Seq.length strand1 <> Seq.length strand2 then
        None
    else
        Seq.zip strand1 strand2
        |> Seq.filter (fun (x, y) -> x <> y)
        |> Seq.length
        |> Some

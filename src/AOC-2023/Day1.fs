module Day1

    open System
    open System.Text.RegularExpressions
    open Microsoft.FSharp.Core

    let seqEmptyToNone (input: seq<'anyType>) =
        match input with
        | s when Seq.isEmpty s -> None
        | s -> Some(s)

    let aggregateFirstAndLastDigit (digitSequence: byte seq option) =
        digitSequence
            |> Option.map(Seq.toArray)
            |> Option.map(fun a ->
                match a.Length with
                | 1 -> (a[0] * 10uy, a[0])
                | _ -> (a[0] * 10uy, a[a.Length - 1]))

    let sumData (rows: seq<string>) (funcGetDigits:string -> byte seq option) =
        rows
            |> Seq.map(funcGetDigits)
            |> Seq.map(aggregateFirstAndLastDigit)
            |> Seq.map(fun tuple ->
                match tuple with
                | Some x -> int (fst x) + int (snd x)
                | None -> 0)
            |> Seq.sum

    module Part1 =
        let getDigits (input: string) =
            input |> Seq.filter(Char.IsDigit)
                |> Seq.map(fun x -> Byte.Parse(x.ToString()))
                |> seqEmptyToNone

        let sumData (rows: seq<string>) =
            sumData <| rows <| getDigits

    module Part2 =
        let parseNumericStringsWithPosition (input: string) =
            Regex.Matches(input, "one|two|three|four|five|six|seven|eight|nine", RegexOptions.Compiled)
                |> Seq.map(fun m ->
                    (m.Index,
                     match m.Value with
                     | "one" -> Option.Some(1uy)
                     | "two" -> Option.Some(2uy)
                     | "three" -> Option.Some(3uy)
                     | "four" -> Option.Some(4uy)
                     | "five" -> Option.Some(5uy)
                     | "six" -> Option.Some(6uy)
                     | "seven" -> Option.Some(7uy)
                     | "eight" -> Option.Some(8uy)
                     | "nine" -> Option.Some(9uy)))
                |> seqEmptyToNone

        let parseDigitsWithPosition (input: string) =
            Regex.Matches(input, "[1-9]", RegexOptions.Compiled)
                |> Seq.map(fun m -> (m.Index, Option.Some(Byte.Parse(m.Value))))
                |> seqEmptyToNone

    let Execute =
        let lines = Common.getData ".\Data\input1.txt"

        // Show Data
        // lines |> Seq.iter(printfn "%s")

        let result = Part1.sumData <| lines

        printfn "Day 1 / Part 1 Result: \n\n%A\n" <| result
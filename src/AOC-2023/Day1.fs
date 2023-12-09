module Day1

    open System
    open Microsoft.FSharp.Core

    let getDigits (input: string) =
        let result =
            input |> Seq.filter(Char.IsDigit)
            |> Seq.map(fun x -> Byte.Parse(x.ToString()))
        match result with
        | s when Seq.isEmpty s -> None
        | s -> Some(s)
        
    let aggregateFirstAndLastDigit (digitSequence: byte seq option) =
        digitSequence
            |> Option.map(Seq.toArray)
            |> Option.map(fun a ->
                match a.Length with
                | 1 -> (a[0] * 10uy, a[0])
                | _ -> (a[0] * 10uy, a[a.Length - 1]))
            
    module Part1 =
        let sumData (rows: seq<string>) =
            rows
                |> Seq.map(getDigits)
                |> Seq.map(aggregateFirstAndLastDigit)
                |> Seq.map(fun tuple ->
                    match tuple with
                    | Some x -> int (fst x) + int (snd x)
                    | None -> 0)
                |> Seq.sum
    
    let Execute =
        let lines = Common.getData ".\Data\input1.txt"

        // Show Data        
        // lines |> Seq.iter(printfn "%s")
        
        let result = Part1.sumData <| lines
        
        printfn "Day 1 / Part 1 Result: \n\n%A\n" <| result
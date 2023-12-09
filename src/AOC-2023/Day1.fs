module Day1

    open System

    let getDigits (input: string) =
        let result =
            input |> Seq.filter(Char.IsDigit)
            |> Seq.map(byte)
        match result with
        | s when Seq.isEmpty s -> None
        | s -> Some(s)
        
    let firstAndLastDigit (digitSequence: byte seq option) =
        digitSequence
            |> Option.map(Seq.toArray)
            |> Option.map(fun a -> (a[0], a[a.Length - 1]))
    
    let Execute =
        let lines = Common.getData ".\Data\input1.txt"
        
        lines |> Seq.iter(printfn "%s")
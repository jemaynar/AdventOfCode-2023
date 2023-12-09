module Day1

    open System

    let getDigits (input: string) =
        let result =
            input |> Seq.filter(Char.IsDigit)
            |> Seq.map(byte)
        match result with
        | s when Seq.isEmpty s -> None
        | s -> Some(s)
    
    let Execute =
        let lines = Common.getData ".\Data\input1.txt"
        
        lines |> Seq.iter(printfn "%s")
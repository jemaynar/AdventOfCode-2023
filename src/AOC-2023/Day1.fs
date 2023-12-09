module Day1
    let Execute =
        let lines = Common.getData ".\Data\input1.txt"
        
        lines |> Seq.iter(printfn "%s")
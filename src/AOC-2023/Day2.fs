module Day2
    let Execute (showData: bool) =
        let lines = Common.getData ".\Data\input2.txt"

        if showData then lines |> Seq.iter(printfn "%s")

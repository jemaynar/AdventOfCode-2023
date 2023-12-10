module Day2

    type Color =
        | Red = 0
        | Green = 1
        | Blue = 3

    type Draw = {
        DrawColor: Color
        Count : byte
    }
        
    type Game = { GameNo: byte; Draws: Draw seq seq }

    let Execute (showData: bool) =
        let lines = Common.getData ".\Data\input2.txt"

        if showData then lines |> Seq.iter(printfn "%s")

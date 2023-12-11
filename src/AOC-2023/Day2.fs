module Day2
    open System
    open System.Text.RegularExpressions
    type Color =
        | Red = 0
        | Green = 1
        | Blue = 3

    type Draw = {
        DrawColor: Color
        Count : byte
    }

    type Game = { GameId: byte; Draws: Draw seq seq }

    let parseDraw (input: string) =
        Regex.Matches(input, "^([1-9]|[1][0-9]|20) (red|green|blue)$", RegexOptions.Compiled)
            |> Seq.map(fun x -> {
                Count = Byte.Parse(x.Groups[1].Value.Trim())
                DrawColor = match x.Groups[2].Value.Trim() with
                            | "green" -> Color.Green
                            | "red" -> Color.Red
                            | "blue" -> Color.Blue 
                            | s -> failwith "todo"} )
            |> Seq.tryHead

    (*
    let parseGame (input: string): Game =
        let gameAndDraws = input.Split(":")
        let handFulls = gameAndDraws[1].Split(";")
        let game = { GameId = 1uy Draws = seq { yield { DrawColor = Color.Green; Count = 0 } } }
        game
    *)

    let Execute (showData: bool) =
        let lines = Common.getData ".\Data\input2.txt"

        if showData then lines |> Seq.iter(printfn "%s")
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
                            | _ -> failwith "unknown color"} )
            |> Seq.tryHead

    let parseDraws (input: string) =
        input.Split(",") |> Seq.map(fun x -> x.Trim() |> parseDraw) |> Seq.choose id

    let parseDrawIndex (input: string) : byte =
        Byte.Parse((input.Split(":")[0]).Split(" ")[1])

    let parseGame : string -> Game =
        fun input -> {
            GameId = parseDrawIndex(input)
            Draws = input.Split(":")[1] |> fun x -> x.Split(";") |> Seq.map(parseDraws)
        }

    let Execute (showData: bool) =
        let lines = Common.getData ".\Data\input2.txt"

        if showData then lines |> Seq.iter(printfn "%s")
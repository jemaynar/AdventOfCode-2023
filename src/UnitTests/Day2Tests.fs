module UnitTests.Day2Tests

    open System.Text.RegularExpressions
    open Xunit

    type ParseDrawTestCase = {
        Input: string
        Expected: Day2.Draw option
    }

    let parseDrawTestCases =
        seq {
            yield [| { Input = "1 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 1uy } ) } |]
            yield [| { Input = "2 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 2uy } ) } |]
            yield [| { Input = "3 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 3uy } ) } |]
            yield [| { Input = "4 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 4uy } ) } |]
            yield [| { Input = "5 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 5uy } ) } |]
            yield [| { Input = "6 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 6uy } ) } |]
            yield [| { Input = "7 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 7uy } ) } |]
            yield [| { Input = "8 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 8uy } ) } |]
            yield [| { Input = "9 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 9uy } ) } |]
            yield [| { Input = "10 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 10uy; } ) } |]
            yield [| { Input = "11 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 11uy; } ) } |]
            yield [| { Input = "12 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 12uy; } ) } |]
            yield [| { Input = "13 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 13uy; } ) } |]
            yield [| { Input = "14 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 14uy; } ) } |]
            yield [| { Input = "15 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 15uy; } ) } |]
            yield [| { Input = "16 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 16uy; } ) } |]
            yield [| { Input = "17 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 17uy; } ) } |]
            yield [| { Input = "18 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 18uy; } ) } |]
            yield [| { Input = "19 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 19uy; } ) } |]
            yield [| { Input = "20 blue"; Expected = Some( { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 20uy; } ) } |]
            yield [| { Input = "21 blue"; Expected = None } |]
            yield [| { Input = "1 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 1uy; } ) } |]
            yield [| { Input = "2 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 2uy; } ) } |]
            yield [| { Input = "3 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 3uy; } ) } |]
            yield [| { Input = "4 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 4uy; } ) } |]
            yield [| { Input = "5 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 5uy; } ) } |]
            yield [| { Input = "6 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 6uy; } ) } |]
            yield [| { Input = "7 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 7uy; } ) } |]
            yield [| { Input = "8 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 8uy; } ) } |]
            yield [| { Input = "9 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 9uy; } ) } |]
            yield [| { Input = "10 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 10uy; } ) } |]
            yield [| { Input = "11 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 11uy; } ) } |]
            yield [| { Input = "12 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 12uy; } ) } |]
            yield [| { Input = "13 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 13uy; } ) } |]
            yield [| { Input = "14 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 14uy; } ) } |]
            yield [| { Input = "15 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 15uy; } ) } |]
            yield [| { Input = "16 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 16uy; } ) } |]
            yield [| { Input = "17 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 17uy; } ) } |]
            yield [| { Input = "18 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 18uy; } ) } |]
            yield [| { Input = "19 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 19uy; } ) } |]
            yield [| { Input = "20 red"; Expected = Some( { Day2.DrawColor = Day2.Color.Red; Day2.Count = 20uy; } ) } |]
            yield [| { Input = "21 red"; Expected = None } |]
            yield [| { Input = "1 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 1uy; } ) } |]
            yield [| { Input = "2 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 2uy; } ) } |]
            yield [| { Input = "3 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 3uy; } ) } |]
            yield [| { Input = "4 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 4uy; } ) } |]
            yield [| { Input = "5 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 5uy; } ) } |]
            yield [| { Input = "6 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 6uy; } ) } |]
            yield [| { Input = "7 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 7uy; } ) } |]
            yield [| { Input = "8 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 8uy; } ) } |]
            yield [| { Input = "9 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 9uy; } ) } |]
            yield [| { Input = "10 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 10uy; } ) } |]
            yield [| { Input = "11 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 11uy; } ) } |]
            yield [| { Input = "12 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 12uy; } ) } |]
            yield [| { Input = "13 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 13uy; } ) } |]
            yield [| { Input = "14 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 14uy; } ) } |]
            yield [| { Input = "15 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 15uy; } ) } |]
            yield [| { Input = "16 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 16uy; } ) } |]
            yield [| { Input = "17 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 17uy; } ) } |]
            yield [| { Input = "18 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 18uy; } ) } |]
            yield [| { Input = "19 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 19uy; } ) } |]
            yield [| { Input = "20 green"; Expected = Some( { Day2.DrawColor = Day2.Color.Green; Day2.Count = 20uy; } ) } |]
            yield [| { Input = "21 green"; Expected = None } |]
        }
    
    [<Theory>]
    [<MemberData(nameof(parseDrawTestCases))>]
    let ``parseDraw`` (testCase: ParseDrawTestCase) =
        let result = Day2.parseDraw <| testCase.Input

        let expected = testCase.Expected
        Assert.Equal<Day2.Draw option>(expected, result)
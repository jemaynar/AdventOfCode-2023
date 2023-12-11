module UnitTests.Day2Tests

    open System.Text.RegularExpressions
    open Xunit

    type ParseDrawTestCase = {
        Input: string
        Expected: Day2.Draw seq
    }

    let parseDrawTestCases =
        seq {
            yield [| { Input = "1 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 1uy; } |] } |]
            yield [| { Input = "2 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 2uy; } |] } |]
            yield [| { Input = "3 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 3uy; } |] } |]
            yield [| { Input = "4 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 4uy; } |] } |]
            yield [| { Input = "5 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 5uy; } |] } |]
            yield [| { Input = "6 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 6uy; } |] } |]
            yield [| { Input = "7 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 7uy; } |] } |]
            yield [| { Input = "8 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 8uy; } |] } |]
            yield [| { Input = "9 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 9uy; } |] } |]
            yield [| { Input = "10 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 10uy; } |] } |]
            yield [| { Input = "11 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 11uy; } |] } |]
            yield [| { Input = "12 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 12uy; } |] } |]
            yield [| { Input = "13 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 13uy; } |] } |]
            yield [| { Input = "14 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 14uy; } |] } |]
            yield [| { Input = "15 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 15uy; } |] } |]
            yield [| { Input = "16 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 16uy; } |] } |]
            yield [| { Input = "17 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 17uy; } |] } |]
            yield [| { Input = "18 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 18uy; } |] } |]
            yield [| { Input = "19 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 19uy; } |] } |]
            yield [| { Input = "20 blue"; Expected = [| yield { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 20uy; } |] } |]
            yield [| { Input = "21 blue"; Expected = Seq.empty } |]
        }
    
    [<Theory>]
    [<MemberData(nameof(parseDrawTestCases))>]
    let ``parseDraw`` (testCase: ParseDrawTestCase) =
        let result = Day2.parseDraw <| testCase.Input

        let expected = testCase.Expected
        Assert.Equal<Day2.Draw seq>(expected, result)
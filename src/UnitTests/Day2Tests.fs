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

    type ParseDrawsTestCase = {
        Input: string
        ExpectedSeq: Day2.Draw seq
    }

    let parseDrawsTestCases =
        seq {
            yield [| {
                Input = "3 blue, 4 red"
                ExpectedSeq = [| { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 3uy };
                                 { Day2.DrawColor = Day2.Color.Red; Day2.Count = 4uy }; |] |> Array.toSeq
            } |]
            yield [| {
                Input = "1 red, 2 green, 6 blue"
                ExpectedSeq = [| { Day2.DrawColor = Day2.Color.Red; Day2.Count = 1uy };
                                 { Day2.DrawColor = Day2.Color.Green; Day2.Count = 2uy };
                                 { Day2.DrawColor = Day2.Color.Blue; Day2.Count = 6uy }; |] |> Array.toSeq
            } |]
            yield [| {
                Input = "2 green"
                ExpectedSeq = [| { Day2.DrawColor = Day2.Color.Green; Day2.Count = 2uy }; |] |> Array.toSeq
            } |]
        }
        
    [<Theory>]
    [<MemberData(nameof(parseDrawsTestCases))>]
    let ``parseDraws`` (testCase: ParseDrawsTestCase) =
        let result = Day2.parseDraws <| testCase.Input

        let expected = testCase.ExpectedSeq
        Assert.Equivalent(expected, result)

    type parseGameTestCase = {
        Input: string
        ExpectedGame: Day2.Game
    }

    let gameTestCases =
        seq {
            yield [| {
                 Input = "Game 1: 4 blue, 4 red; 1 red, 2 green, 6 blue; 4 green";
                 ExpectedGame = {
                     Day2.GameId = 1uy;
                     Day2.Draws = seq {
                         yield seq {
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 4uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 4uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 1uy; };
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 2uy; };
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 6uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 4uy; };
                         }
                     }
                 }
            } |]
            yield [| {
                 Input = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
                 ExpectedGame = {
                     Day2.GameId = 2uy;
                     Day2.Draws = seq {
                         yield seq {
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 1uy; };
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 2uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 3uy; };
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 4uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 1uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 1uy; };
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 1uy; };
                         }
                     }
                 }
            } |]
            yield [| {
                 Input = "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
                 ExpectedGame = {
                     Day2.GameId = 3uy;
                     Day2.Draws = seq {
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 8uy; };
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 6uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 20uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 5uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 4uy; };
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 13uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 5uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 1uy; };
                         }
                     }
                 }
            } |]
            yield [| {
                 Input = "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red";
                 ExpectedGame = {
                     Day2.GameId = 4uy;
                     Day2.Draws = seq {
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 1uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 3uy; };
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 6uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 3uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 6uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 3uy; };
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 15uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 14uy; };
                         }
                     }
                 }
            } |]
            yield [| {
                 Input = "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
                 ExpectedGame = {
                     Day2.GameId = 5uy;
                     Day2.Draws = seq {
                         yield seq {
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 6uy; };
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 1uy; };
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 3uy; };
                         }
                         yield seq {
                            yield { DrawColor = Day2.Color.Blue; Day2.Count = 2uy; };
                            yield { DrawColor = Day2.Color.Red; Day2.Count = 1uy; };
                            yield { DrawColor = Day2.Color.Green; Day2.Count = 2uy; };
                         }
                     }
                 }
            } |]
        }

    [<Theory>]
    [<MemberData(nameof(gameTestCases))>]
    let ``parseGame`` (testCase: parseGameTestCase) =
        let result = Day2.parseGame <| testCase.Input

        let expected = testCase.ExpectedGame
        Assert.Multiple(fun () ->
            Assert.Equal(expected.GameId, result.GameId)
            Assert.Equivalent(expected.Draws, result.Draws))

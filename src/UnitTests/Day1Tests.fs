module UnitTests.Day1Tests
    open System.Collections.Generic
    open Xunit

    module Part1 =
        [<Fact>]
        let ``getDigits when empty returns none`` () =
            let result = Day1.Part1.getDigits <| ""

            Assert.Equal<Option<IEnumerable<byte>>>(None, result)

        [<Fact>]
        let ``getDigits when whitespace returns none`` () =
            let result = Day1.Part1.getDigits <| " "

            Assert.Equal<Option<IEnumerable<byte>>>(None, result)

        [<Fact>]
        let ``getDigits when non-digit returns none`` () =
            let result = Day1.Part1.getDigits <| "a"

            Assert.Equal<Option<IEnumerable<byte>>>(None, result)

        [<Fact>]
        let ``getDigits when digit returns some`` () =
            let result = Day1.Part1.getDigits <| "1"

            Assert.True(result.IsSome)

        [<Fact>]
        let ``getDigits when "1" returns some seq equivalent of [ 1uy ]`` () =
            let result = Day1.Part1.getDigits <| "1"

            Assert.Equivalent([| 1uy |] |> Seq.ofArray, result.Value)

        [<Fact>]
        let ``getDigits when "12" returns some seq equivalent of [ 1uy; 2uy ]`` () =
            let result = Day1.Part1.getDigits <| "12"

            Assert.Equivalent([| 1uy; 2uy |] |> Seq.ofArray, result.Value)

        [<Fact>]
        let ``getDigits when "123" returns some seq equivalent of [ 1uy; 2uy; 3uy ]`` () =
            let result = Day1.Part1.getDigits <| "123"

            Assert.Equivalent([| 1uy; 2uy; 3uy |] |> Seq.ofArray, result.Value)

        [<Fact>]
        let ``getDigits when "_1+2b3_" returns some seq equivalent of [ 1uy; 2uy; 3uy ]`` () =
            let result = Day1.Part1.getDigits <| "123"

            Assert.Equivalent([| 1uy; 2uy; 3uy |] |> Seq.ofArray, result.Value)

        [<Fact>]
        let ``sumData when ["1"] then 11`` () =
            let result = Day1.Part1.sumData <| ["1"]

            Assert.Equal<int>(result, 11)

        [<Fact>]
        let ``sumData when ["11"] then 11`` () =
            let result = Day1.Part1.sumData <| ["11"]

            Assert.Equal<int>(result, 11)

        [<Fact>]
        let ``sumData when ["1a1"] then 11`` () =
            let result = Day1.Part1.sumData <| ["1a1"]

            Assert.Equal<int>(result, 11)

        [<Fact>]
        let ``sumData when ["1a1"; "no digits"] then 2`` () =
            let result = Day1.Part1.sumData <| ["11"; "no digits"]

            Assert.Equal<int>(result, 11)

        [<Fact>]
        let ``sumData when ["1a1"; "1"] then 22`` () =
            let result = Day1.Part1.sumData <| ["11"; "1"]

            Assert.Equal<int>(result, 22)

        [<Fact>]
        let ``sumData when ["1a1"; "no digits"; "aa2aa"] then 33`` () =
            let result = Day1.Part1.sumData <| ["11"; "no digits"; "aa2aa"]

            Assert.Equal<int>(result, 33)

        [<Fact>]
        let ``sumData when ["1abc2"; "pqr3stu8vwx"; "a1b2c3d4e5f"; "treb7uchet"] then 142`` () =
            let result = Day1.Part1.sumData <| ["1abc2"; "pqr3stu8vwx"; "a1b2c3d4e5f"; "treb7uchet"]

            Assert.Equal<int>(result, 142)

    module Part2 =
        type resultRow = { Position: int; Value: byte option }
        type ParserTestCase = { Input: string; Expected: resultRow seq option }
        let parseNumericWithStringPositionTestCases =
            seq {
                yield [| { Input = ""; Expected = None } |];
                yield [| { Input = " "; Expected = None } |];
                yield [| { Input = "non-digit"; Expected = None } |];
                yield [| { Input = "1"; Expected = None } |];
                yield [| { Input = "one"; Expected = Some([| { Position = 0; Value = Some(1uy) } |] |> Array.toSeq ) } |];
                yield [| { Input = "two"; Expected = Some([| { Position = 0; Value = Some(2uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "three"; Expected = Some([| { Position = 0; Value = Some(3uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "four"; Expected = Some([| { Position = 0; Value = Some(4uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "five"; Expected = Some([| { Position = 0; Value = Some(5uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "six"; Expected = Some([| { Position = 0; Value = Some(6uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "seven"; Expected = Some([| { Position = 0; Value = Some(7uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "eight"; Expected = Some([| { Position = 0; Value = Some(8uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "nine"; Expected = Some([| { Position = 0; Value = Some(9uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "oneone"; Expected = Some([| { Position = 0; Value = Some(1uy) }; { Position = 3; Value = Some(1uy) } |] |> Array.toSeq ) } |];
                yield [| { Input = "twotwo"; Expected = Some([| { Position = 0; Value = Some(2uy) }; { Position = 3; Value = Some(2uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "threethree"; Expected = Some([| { Position = 0; Value = Some(3uy) }; { Position = 5; Value = Some(3uy) }; |] |> Array.toSeq) } |];
                yield [| { Input = "fourfour"; Expected = Some([| { Position = 0; Value = Some(4uy) }; { Position = 4; Value = Some(4uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "fivefive"; Expected = Some([| { Position = 0; Value = Some(5uy) }; { Position = 4; Value = Some(5uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "sixsix"; Expected = Some([| { Position = 0; Value = Some(6uy) }; { Position = 3; Value = Some(6uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "sevenseven"; Expected = Some([| { Position = 0; Value = Some(7uy) }; { Position = 5; Value = Some(7uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "eighteight"; Expected = Some([| { Position = 0; Value = Some(8uy) }; { Position = 5; Value = Some(8uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "ninenine"; Expected = Some([| { Position = 0; Value = Some(9uy) }; { Position = 4; Value = Some(9uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "aone"; Expected = Some([| { Position = 1; Value = Some(1uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "atwo"; Expected = Some([| { Position = 1; Value = Some(2uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "athree"; Expected = Some([| { Position = 1; Value = Some(3uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "afour"; Expected = Some([| { Position = 1; Value = Some(4uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "afive"; Expected = Some([| { Position = 1; Value = Some(5uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "asix"; Expected = Some([| { Position = 1; Value = Some(6uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "aseven"; Expected = Some([| { Position = 1; Value = Some(7uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "aeight"; Expected = Some([| { Position = 1; Value = Some(8uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "anine"; Expected = Some([| { Position = 1; Value = Some(9uy) } |] |> Array.toSeq) } |];
            }

        [<Theory>]
        [<MemberData(nameof(parseNumericWithStringPositionTestCases))>]
        let ``parseNumericStringsWithPosition`` (testCase: ParserTestCase) =
            let result = testCase.Input |> Day1.Part2.parseNumericStringsWithPosition

            let mappedExpected:(int * byte option) seq option =
                testCase.Expected
                    |> Option.map(fun x -> x |> Seq.map(fun y -> (y.Position, y.Value)))
            
            if testCase.Expected.IsNone then
                Assert.True(result.IsNone)
            else
                Assert.Equivalent(mappedExpected, result)

        let parseDigitsWithStringPositionTestCases =
            seq {
                yield [| { Input = ""; Expected = None } |];
                yield [| { Input = " "; Expected = None } |];
                yield [| { Input = "non-digit"; Expected = None } |];
                yield [| { Input = "one"; Expected = None } |];
                yield [| { Input = "1"; Expected = Some([| { Position = 0; Value = Some(1uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "2"; Expected = Some([| { Position = 0; Value = Some(2uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "3"; Expected = Some([| { Position = 0; Value = Some(3uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "4"; Expected = Some([| { Position = 0; Value = Some(4uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "5"; Expected = Some([| { Position = 0; Value = Some(5uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "6"; Expected = Some([| { Position = 0; Value = Some(6uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "7"; Expected = Some([| { Position = 0; Value = Some(7uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "8"; Expected = Some([| { Position = 0; Value = Some(8uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "9"; Expected = Some([| { Position = 0; Value = Some(9uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "0"; Expected = Some([| { Position = 0; Value = Some(0uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a1"; Expected = Some([| { Position = 1; Value = Some(1uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a2"; Expected = Some([| { Position = 1; Value = Some(2uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a3"; Expected = Some([| { Position = 1; Value = Some(3uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a4"; Expected = Some([| { Position = 1; Value = Some(4uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a5"; Expected = Some([| { Position = 1; Value = Some(5uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a6"; Expected = Some([| { Position = 1; Value = Some(6uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a7"; Expected = Some([| { Position = 1; Value = Some(7uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a8"; Expected = Some([| { Position = 1; Value = Some(8uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a9"; Expected = Some([| { Position = 1; Value = Some(9uy) } |] |> Array.toSeq) } |];
                yield [| { Input = "a0"; Expected = Some([| { Position = 1; Value = Some(0uy) } |] |> Array.toSeq) } |];
            }

        [<Theory>]
        [<MemberData(nameof(parseDigitsWithStringPositionTestCases))>]
        let ``parseDigitsWithPosition`` (testCase: ParserTestCase) =
            let result = testCase.Input |> Day1.Part2.parseDigitsWithPosition

            let mappedExpected:(int * byte option) seq option =
                testCase.Expected
                    |> Option.map(fun x -> x |> Seq.map(fun y -> (y.Position, y.Value)))
            
            if testCase.Expected.IsNone then
                Assert.True(result.IsNone)
            else
                Assert.Equivalent(mappedExpected, result)

    [<Fact>]
    let ``aggregateFirstAndLastDigit when none return none`` () =
        let result = Day1.aggregateFirstAndLastDigit <| None

        Assert.True(result.IsNone)

    [<Fact>]
    let ``aggregateFirstAndLastDigit when some "[| 1uy |]" returns (10uy, 1uy)`` () =
        let result = Day1.aggregateFirstAndLastDigit <| Some([| 1uy |])

        Assert.Equal<byte * byte>(result.Value, (10uy, 1uy))

    [<Fact>]
    let ``aggregateFirstAndLastDigit when some "[| 1uy; 2uy |]" returns (10uy, 2uy)`` () =
        let result = Day1.aggregateFirstAndLastDigit <| Some([| 1uy; 2uy |])

        Assert.Equal<byte * byte>(result.Value, (10uy, 2uy))

    [<Fact>]
    let ``aggregateFirstAndLastDigit when some "[| 1uy; 3uy; 2uy |]" returns (1uy, 2uy)`` () =
        let result = Day1.aggregateFirstAndLastDigit <| Some([| 1uy; 3uy; 2uy |])

        Assert.Equal<byte * byte>(result.Value, (10uy, 2uy))

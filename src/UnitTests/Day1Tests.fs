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
        [<Fact>]
        let ``getNumericStrings when empty returns none`` () =
            let result = "" |> Day1.Part2.getNumericStrings

            Assert.True(result.IsNone)

        [<Fact>]
        let ``getNumericStrings when whitespace returns none`` () =
            let result = " " |> Day1.Part2.getNumericStrings

            Assert.True(result.IsNone)

        [<Fact>]
        let ``getNumericStrings when non-digit returns none`` () =
            let result = "non-digit" |> Day1.Part2.getNumericStrings

            Assert.True(result.IsNone)

        [<Fact>]
        let ``getNumericStrings when digit returns none`` () =
            let result = "1" |> Day1.Part2.getNumericStrings

            Assert.True(result.IsNone)

        [<Fact>]
        let ``getNumericStrings when "one" returns (0, 1uy)`` () =
            let result = "one" |> Day1.Part2.getNumericStrings

            Assert.Equivalent([ (0, Some(1uy)) ], result.Value )

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

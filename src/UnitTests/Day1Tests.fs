module UnitTests.Day1Tests
    open System.Collections.Generic
    open Xunit
    
    [<Fact>]
    let ``Day1.getDigits when empty returns none`` () =
        let result = Day1.getDigits <| ""
        
        Assert.Equal<Option<IEnumerable<byte>>>(None, result)
        
    [<Fact>]
    let ``Day1.getDigits when whitespace returns none`` () =
        let result = Day1.getDigits <| " "
        
        Assert.Equal<Option<IEnumerable<byte>>>(None, result)
        
    [<Fact>]
    let ``Day1.getDigits when non-digit returns none`` () =
        let result = Day1.getDigits <| "a"
        
        Assert.Equal<Option<IEnumerable<byte>>>(None, result)
        
    [<Fact>]
    let ``Day1.getDigits when digit returns some`` () =
        let result = Day1.getDigits <| "1"
        
        Assert.True(result.IsSome)
        
    [<Fact>]
    let ``Day1.firstAndLastDigit when none return none`` () =
        let result = Day1.firstAndLastDigit <| None
        
        Assert.True(result.IsNone)
        
    [<Fact>]
    let ``Day1.firstAndLastDigit when some 1 returns (1, 1)1`` () =
        let result = Day1.firstAndLastDigit <| Some([| 1uy |])
        
        Assert.Equal<byte * byte>(result.Value, (1uy, 1uy))

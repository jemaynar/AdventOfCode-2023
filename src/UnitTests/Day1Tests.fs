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

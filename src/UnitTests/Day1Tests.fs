﻿module UnitTests.Day1Tests
    open System.Collections.Generic
    open Xunit
    
    [<Fact>]
    let ``getDigits when empty returns none`` () =
        let result = Day1.getDigits <| ""
        
        Assert.Equal<Option<IEnumerable<byte>>>(None, result)
        
    [<Fact>]
    let ``getDigits when whitespace returns none`` () =
        let result = Day1.getDigits <| " "
        
        Assert.Equal<Option<IEnumerable<byte>>>(None, result)
        
    [<Fact>]
    let ``getDigits when non-digit returns none`` () =
        let result = Day1.getDigits <| "a"
        
        Assert.Equal<Option<IEnumerable<byte>>>(None, result)
        
    [<Fact>]
    let ``getDigits when digit returns some`` () =
        let result = Day1.getDigits <| "1"
        
        Assert.True(result.IsSome)
        
    [<Fact>]
    let ``getDigits when "1" returns some seq of 1`` () =
        let result = Day1.getDigits <| "1"
        
        Assert.Equal<IEnumerable<byte>>([| 1uy |] |> Seq.ofArray, result.Value)
        
    [<Fact>]
    let ``firstAndLastDigit when none return none`` () =
        let result = Day1.firstAndLastDigit <| None
        
        Assert.True(result.IsNone)
        
    [<Fact>]
    let ``firstAndLastDigit when some "[| 1 |]" returns (1, 1)`` () =
        let result = Day1.firstAndLastDigit <| Some([| 1uy |])
        
        Assert.Equal<byte * byte>(result.Value, (1uy, 1uy))
        
    [<Fact>]
    let ``firstAndLastDigit when some "[| 1; 2 |]" returns (1 2)`` () =
        let result = Day1.firstAndLastDigit <| Some([| 1uy; 2uy |])
        
        Assert.Equal<byte * byte>(result.Value, (1uy, 2uy))
        
    [<Fact>]
    let ``firstAndLastDigit when some "[| 1; 3; 2 |]" returns (1 2)`` () =
        let result = Day1.firstAndLastDigit <| Some([| 1uy; 3uy; 2uy |])
        
        Assert.Equal<byte * byte>(result.Value, (1uy, 2uy))

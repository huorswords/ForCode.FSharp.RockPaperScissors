namespace ForCode.RockPaperScissors.UnitTests

open System
open Xunit
open Xunit.Extensions

module RockPaperScissorsTests = 
    open ForCode.RockPaperScissors.RockPaperScissorsResolver
        
    [<Theory>]
    [<InlineData(Hand.Scissors, Hand.Paper, Hand.Scissors)>]
    [<InlineData(Hand.Scissors, Hand.Rock, Hand.Rock)>]
    [<InlineData(Hand.Scissors, Hand.Scissors, Hand.None)>]
    [<InlineData(Hand.Paper, Hand.Scissors, Hand.Scissors)>]
    [<InlineData(Hand.Rock, Hand.Scissors, Hand.Rock)>]
    [<InlineData(Hand.Paper, Hand.Rock, Hand.Paper)>]
    [<InlineData(Hand.Scissors, Hand.Rock, Hand.Rock)>]
    [<InlineData(Hand.Rock, Hand.Paper, Hand.Paper)>]
    [<InlineData(Hand.Rock, Hand.Scissors, Hand.Rock)>]
    [<InlineData(Hand.Rock, Hand.Rock, Hand.None)>]
    [<InlineData(Hand.Paper, Hand.Scissors, Hand.Scissors)>]
    [<InlineData(Hand.Paper, Hand.Rock, Hand.Paper)>]
    [<InlineData(Hand.Scissors, Hand.Paper, Hand.Scissors)>]
    [<InlineData(Hand.Rock, Hand.Paper, Hand.Paper)>]
    [<InlineData(Hand.Paper, Hand.Paper, Hand.None)>]    
    let WinnerIsCorrect
        (left : Hand)
        (right : Hand) 
        (expected : Hand) =
        let actual = GetWinner left right
        let expected = expected
        Assert.Equal(expected, actual)
    
    [<Theory>]
    [<InlineData(Hand.None, Hand.Scissors)>]
    [<InlineData(Hand.None, Hand.None)>]
    [<InlineData(Hand.Scissors, Hand.None)>]
    let AnyInvalidHandRaisesException
        (left : Hand)
        (right : Hand) =

        try
            let actual = GetWinner left right
            Assert.True(false)
        with
         | Failure(msg) -> printfn "%s" msg;

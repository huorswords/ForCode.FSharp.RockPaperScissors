namespace ForCode.RockPaperScissors.UnitTests

open System
open Xunit
open Xunit.Extensions

module RockPaperScissorsTests = 
    open ForCode.RockPaperScissors.RockPaperScissorsResolver
    
    [<Theory>]
    [<InlineData(HandType.Scissors   , HandType.Paper      , GameResult.Win   )>]
    [<InlineData(HandType.Paper      , HandType.Scissors   , GameResult.Lose  )>]
    [<InlineData(HandType.Scissors   , HandType.Rock       , GameResult.Lose  )>]
    [<InlineData(HandType.Rock       , HandType.Scissors   , GameResult.Win   )>]
    [<InlineData(HandType.Paper      , HandType.Rock       , GameResult.Win   )>]
    [<InlineData(HandType.Rock       , HandType.Paper      , GameResult.Lose  )>]
    [<InlineData(HandType.Paper      , HandType.Lizard     , GameResult.Lose  )>]
    [<InlineData(HandType.Paper      , HandType.Spock      , GameResult.Win   )>]
    [<InlineData(HandType.Scissors   , HandType.Lizard     , GameResult.Win   )>]
    [<InlineData(HandType.Scissors   , HandType.Spock      , GameResult.Lose  )>]
    [<InlineData(HandType.Rock       , HandType.Lizard     , GameResult.Win   )>]
    [<InlineData(HandType.Rock       , HandType.Spock      , GameResult.Lose  )>]
    [<InlineData(HandType.Lizard     , HandType.Paper      , GameResult.Win   )>]
    [<InlineData(HandType.Spock      , HandType.Paper      , GameResult.Lose  )>]
    [<InlineData(HandType.Lizard     , HandType.Scissors   , GameResult.Lose  )>]
    [<InlineData(HandType.Spock      , HandType.Scissors   , GameResult.Win   )>]
    [<InlineData(HandType.Lizard     , HandType.Rock       , GameResult.Lose  )>]
    [<InlineData(HandType.Spock      , HandType.Rock       , GameResult.Win   )>]
    [<InlineData(HandType.Scissors   , HandType.Scissors   , GameResult.Deuce )>]
    [<InlineData(HandType.Rock       , HandType.Rock       , GameResult.Deuce )>]
    [<InlineData(HandType.Paper      , HandType.Paper      , GameResult.Deuce )>]
    [<InlineData(HandType.Lizard     , HandType.Lizard     , GameResult.Deuce )>]
    [<InlineData(HandType.Spock      , HandType.Spock      , GameResult.Deuce )>]
    let GameResultIsAsExpected
        (left: HandType, right: HandType, expected: GameResult) =
        let me = HandFactory.Create left
        let you = HandFactory.Create right
        let actual = me.Play you
        Assert.Equal(expected, actual)
namespace ForCode.RockPaperScissors.UnitTests

open System
open Xunit
open Xunit.Extensions

module RockPaperScissorsTests = 
    open ForCode.RockPaperScissors.RockPaperScissorsResolver

    let TestData = [|
           [| Scissors() :> Hand; Paper()    :> Hand; Scissors()          :> Hand |]
           [| Paper()    :> Hand; Scissors() :> Hand; Scissors()          :> Hand |]
           [| Scissors() :> Hand; Paper()    :> Hand; Scissors()          :> Hand |]
           [| Scissors() :> Hand; Rock()     :> Hand; Rock()              :> Hand |]
           [| Rock()     :> Hand; Scissors() :> Hand; Rock()              :> Hand |]
           [| Paper()    :> Hand; Rock()     :> Hand; Paper()             :> Hand |]
           [| Rock()     :> Hand; Paper()    :> Hand; Paper()             :> Hand |]
           [| Paper()    :> Hand; Lizard()   :> Hand; Lizard()            :> Hand |]
           [| Paper()    :> Hand; Spock()    :> Hand; Paper()             :> Hand |]
           [| Scissors() :> Hand; Lizard()   :> Hand; Scissors()          :> Hand |]
           [| Scissors() :> Hand; Spock()    :> Hand; Spock()             :> Hand |]
           [| Rock()     :> Hand; Lizard()   :> Hand; Rock()              :> Hand |]
           [| Rock()     :> Hand; Spock()    :> Hand; Spock()             :> Hand |]
           [| Lizard()   :> Hand; Paper()    :> Hand; Lizard()            :> Hand |]
           [| Spock()    :> Hand; Paper()    :> Hand; Paper()             :> Hand |]
           [| Lizard()   :> Hand; Scissors() :> Hand; Scissors()          :> Hand |]
           [| Spock()    :> Hand; Scissors() :> Hand; Spock()             :> Hand |]
           [| Lizard()   :> Hand; Rock()     :> Hand; Rock()              :> Hand |]
           [| Spock()    :> Hand; Rock()     :> Hand; Spock()             :> Hand |]

           [| Scissors() :> Hand; Scissors() :> Hand; Hand(HandType.None)         |]
           [| Rock()     :> Hand; Rock()     :> Hand; Hand(HandType.None)         |]
           [| Paper()    :> Hand; Paper()    :> Hand; Hand(HandType.None)         |]
           [| Lizard()   :> Hand; Lizard()   :> Hand; Hand(HandType.None)         |]
           [| Spock()    :> Hand; Spock()    :> Hand; Hand(HandType.None)         |]
        |] 

    let WrongData = [|
            [| Hand(HandType.None); Hand(HandType.None) |]
            [| Hand(HandType.None); Scissors() :> Hand  |]
            [| Scissors() :> Hand ; Hand(HandType.None) |]
        |]

    [<Theory>]
    [<MemberData("TestData")>]
    let WinnerIsCorrect
        (left : Hand)
        (right : Hand)
        (expected : Hand) =
        let actual = GetWinner left right
        let expected = expected
        Assert.Equal(expected.Type, actual.Type)
    
    [<Theory>]
    [<MemberData("WrongData")>]
    let AnyInvalidHandTypeRaisesException
        (left : Hand)
        (right : Hand) =
        try
            let actual = GetWinner left right
            Assert.True(false)
        with
         | Failure(msg) -> printfn "%s" msg;
namespace ForCode.RockPaperScissors

module RockPaperScissorsResolver =

    type HandType =
        | Scissors = 1
        | Rock = 2
        | Paper = 3
        | Lizard = 4
        | Spock = 5

    type GameResult =
        | Deuce = 1
        | Win   = 2
        | Lose  = 3

    type Shape(hand : HandType, loseWith : HandType[]) =
        member x.Hand = hand
        member x.LoseWith = loseWith
        
        member this.Play(versus : Shape) : GameResult =
            if versus.Hand.Equals(hand) then
                GameResult.Deuce
            else
                try
                    let found = Array.find<HandType>(fun elem -> elem.Equals(versus.Hand)) this.LoseWith
                    GameResult.Lose
                with
                    | :? System.Collections.Generic.KeyNotFoundException -> GameResult.Win
             
    [<AbstractClass; Sealed>]
    type HandFactory private() =
        static member Paper() =
            Shape(HandType.Paper, [| HandType.Lizard; HandType.Scissors |])
        static member Rock() =
            Shape(HandType.Rock, [| HandType.Paper; HandType.Spock |])
        static member Scissors() =
            Shape(HandType.Scissors, [| HandType.Rock; HandType.Spock |])
        static member Lizard() =
            Shape(HandType.Lizard, [| HandType.Rock; HandType.Scissors |])
        static member Spock() =
            Shape(HandType.Spock, [| HandType.Lizard; HandType.Paper |])
        static member Create(handType: HandType) =
            match handType with
            | HandType.Spock -> 
                HandFactory.Spock()
            | HandType.Paper -> 
                HandFactory.Paper()
            | HandType.Scissors -> 
                HandFactory.Scissors()
            | HandType.Rock -> 
                HandFactory.Rock()
            | HandType.Lizard-> 
                HandFactory.Lizard()
            | _ ->
                failwith "Invalid hand"
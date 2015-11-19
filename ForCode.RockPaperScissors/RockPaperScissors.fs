namespace ForCode.RockPaperScissors

module RockPaperScissorsResolver =
    type HandType =
        | None = 0
        | Scissors = 1
        | Rock = 2
        | Paper = 3
        | Lizard = 4
        | Spock = 5
        
    type Hand(handType : HandType) =
        member x.Type = handType

        abstract ShootVs : Hand -> Hand
        default this.ShootVs (hand : Hand) =
                failwith "Invalid hand"
        
    type Scissors() =
        inherit Hand(HandType.Scissors)

        override this.ShootVs (hand : Hand) =
            match hand.Type with
            | HandType.Paper ->
                this :> Hand
            | HandType.Rock ->
                hand
            | HandType.Scissors ->
                Hand(HandType.None)
            | HandType.Lizard ->
                this :> Hand
            | HandType.Spock ->
                hand
            | _ ->
                base.ShootVs hand

    type Paper() =
        inherit Hand(HandType.Paper)

        override this.ShootVs (hand : Hand) =
            match hand.Type with
            | HandType.Rock ->
                this :> Hand
            | HandType.Scissors ->
                hand
            | HandType.Paper ->
                Hand(HandType.None)
            | HandType.Lizard ->
                hand
            | HandType.Spock ->
                this :> Hand
            | _ ->
                base.ShootVs hand

    type Rock() =
        inherit Hand(HandType.Rock)

        override this.ShootVs (hand : Hand) =
            match hand.Type with
            | HandType.Scissors ->
                this :> Hand
            | HandType.Paper ->
                hand
            | HandType.Rock ->
                Hand(HandType.None)
            | HandType.Lizard ->
                this :> Hand
            | HandType.Spock ->
                hand
            | _ ->
                base.ShootVs hand
                
    type Lizard() =
        inherit Hand(HandType.Lizard)

        override this.ShootVs (hand : Hand) =
            match hand.Type with
            | HandType.Scissors ->
                hand
            | HandType.Paper ->
                this :> Hand
            | HandType.Rock ->
                hand
            | HandType.Lizard ->
                Hand(HandType.None)
            | HandType.Spock ->
                this :> Hand
            | _ ->
                base.ShootVs hand
                
    type Spock() =
        inherit Hand(HandType.Spock)

        override this.ShootVs (hand : Hand) =
            match hand.Type with
            | HandType.Scissors ->
                this :> Hand
            | HandType.Paper ->
                hand
            | HandType.Rock ->
                this :> Hand
            | HandType.Lizard ->
                hand
            | HandType.Spock ->
                Hand(HandType.None)
            | _ ->
                base.ShootVs hand

    let GetWinner 
        (left : Hand)
        (right : Hand) =
        left.ShootVs right                

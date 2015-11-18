namespace ForCode.RockPaperScissors

module RockPaperScissorsResolver =
    type HandType =
        | None = 0
        | Scissors = 1
        | Rock = 2
        | Paper = 3
        
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
            | _ ->
                base.ShootVs hand

    let GetWinner 
        (left : Hand)
        (right : Hand) =
        left.ShootVs right                

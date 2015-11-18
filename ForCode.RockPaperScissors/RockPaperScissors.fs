namespace ForCode.RockPaperScissors

module RockPaperScissorsResolver =
    type Hand =
        | None = 0
        | Scissors = 1
        | Rock = 2
        | Paper = 3
    
    let GetWinner 
        (left : Hand)
        (right : Hand) =

        if left.Equals(Hand.None)
            || right.Equals(Hand.None) then
            failwith "Invalid hand"
        
        match left with
        | Hand.Scissors ->
            match right with
            | Hand.Paper ->
                left
            | Hand.Rock ->
                right
            | _ ->           
                Hand.None
        | Hand.Paper ->
            match right with
            | Hand.Rock ->
                left
            | Hand.Scissors ->
                right
            | _ ->           
                Hand.None
        | Hand.Rock ->
            match right with
            | Hand.Scissors ->
                left
            | Hand.Paper ->
                right
            | _ ->           
                Hand.None
        | _ ->           
            failwith "Invalid hand"
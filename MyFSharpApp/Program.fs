// For more information see https://aka.ms/fsharp-console-apps
type Coach = {
    CoachName: string
    IFPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let coach1 = { CoachName = "Quin Snyder"; IFPlayer = true }
let coach2 = { CoachName = "Joe Mazzulla"; IFPlayer = true }
let coach3 = { CoachName = "Kevin Ollie"; IFPlayer = false }
let coach4 = { CoachName = "Charles Lee"; IFPlayer = false }
let coach5 = { CoachName = "Billy Donovan"; IFPlayer = true }

let stats1 = { Wins = 36; Losses = 46 }
let stats2 = { Wins = 64; Losses = 18 }
let stats3 = { Wins = 12; Losses = 17 }
let stats4 = { Wins = 2; Losses = 1 }
let stats5 = { Wins = 39; Losses = 43 }

let team1 = { Name = "Atlanta Hawks"; Coach = coach1; Stats = stats1 }
let team2 = { Name = "Boston Celtics"; Coach = coach2; Stats = stats2 }
let team3 = { Name = "Brooklyn Nets"; Coach = coach3; Stats = stats3 }
let team4 = { Name = "Charlotte Hornets"; Coach = coach4; Stats = stats4 }
let team5 = { Name = "Chicago Bulls"; Coach = coach5; Stats = stats5 }

let teams = [team1; team2; team3; team4; team5]


printfn "Name of the coaches:"
printfn " "
for team in teams do
    printfn " Name : %s , Former Player: %b" team.Coach.CoachName team.Coach.IFPlayer

printfn " "
printfn " "


printfn "Name of the teams:"

for team in teams do
    printfn " %s" team.Name

    
printfn " "
printfn " "


let successfulTeams = 
    teams
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

let successPercentage (team: Team) =
    let totalGames = float (team.Stats.Wins + team.Stats.Losses)
    (float team.Stats.Wins / totalGames) * 100.0

let teamSuccessPercentages = 
    successfulTeams
    |> List.map (fun team -> team.Name, successPercentage team)


printfn "The successful teams are:"
printfn " "
teamSuccessPercentages |> List.iter (fun (name, percentage) ->
    printfn " Team :%s      Success Percentage:  %.2f%% " name percentage
)

   
printfn " "
printfn " "


type Cuisine =
    | Korean
    | Turkish

type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float

let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 17.0
        | IMAXWithSnacks -> 22.0
        | DBOXWithSnacks -> 25.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (kilometers, fuelCostPerKm) ->
        float kilometers * fuelCostPerKm


printfn "The budget of different activities are :"
printfn " "


printfn "Budget for board-games : 0 CAD"
printfn "Budget for chilling : 0 CAD"


let budgetForMovie = calculateBudget (Movie IMAX)
printfn "Budget for IMAX movie: %.2f CAD" budgetForMovie

let budgetForRestaurant = calculateBudget (Restaurant Korean)
printfn "Budget for Korean restaurant: %.2f CAD" budgetForRestaurant


let distance = 250
let fuelCostPerKm = 7.0

let budgetForLongDrive = calculateBudget (LongDrive (distance, fuelCostPerKm))
printfn "Budget for Long Drive: %.2f CAD" budgetForLongDrive

module Majunga.Fun

open Majunga.Helpers


let rec PigLatin (word:string) =
    match word.Length with
    | 0 -> "Iay eednay aay ordway!"
    | 1 -> word + "ay"
    | _ ->  
        if (word |> String.firstCharOfString |> Char.isVowel) then word + "ay"
        elif not (word |> String.hasVowels) then word + "ay"
        else PigLatin (String.addHeadToTail word) 

let SentenceToPigLatin (str:string) =
    str |> String.split ' ' |> Array.map (fun (x:string) -> (PigLatin x) + " ") |> String.concatStringArray |> String.trim

let FizzBuzz (i:int) =
    
    if (i % 3 = 0 && i % 5 = 0) then i.ToString() + " - fizzbuzz"
    elif (i % 3 = 0) then i.ToString() + " - fizz"
    elif (i % 5 = 0) then i.ToString() + " - buzz"
    else i.ToString()

let FizzBuzzArray (i : int[]) =
    i |> Array.map FizzBuzz
    
    
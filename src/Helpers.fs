module Majunga.Helpers
open System

module Char =
    let vowels = ['a';'e';'i';'o';'u']
    let isVowel (letter:char) =
        (vowels |> List.contains letter)

    let concatCharArray (str:char[]) =
        str |> String.Concat      

module String =
    let isNullOrWhiteSpace str =
        String.IsNullOrWhiteSpace(str)

    let split (cha:char) (str:string) =
        str.Split(cha)    

    let trim (str:string) =
        str.Trim()

    let concatStringArray (str:string[]) =
        str |> String.Concat  

    let firstCharOfString (word:string)=
        word.ToCharArray() |> Array.head

    let hasVowels (word:string) =
        word |> String.filter Char.isVowel |> isNullOrWhiteSpace |> not

    let addHeadToTail (word:string) = 
        word.ToCharArray() |> (fun x -> [|(Array.head x)|] |> Array.append (Array.tail x))  |> System.String    

    let hasLower (str:string) = 
        str 
            |> String.filter Char.IsLetter 
            |> String.filter Char.IsLower
            |> isNullOrWhiteSpace

    let hasLetters (input:string) = 
        input
            |> String.filter Char.IsLetter 
            |> isNullOrWhiteSpace
            |> not
    let hasNoLower (input:string) = 
        input
            |> String.filter Char.IsLetter 
            |> String.filter Char.IsLower
            |> isNullOrWhiteSpace        

module Decimal = 
    let round (x:decimal) (decimalPlace:int)  =
        Math.Round(x, decimalPlace)
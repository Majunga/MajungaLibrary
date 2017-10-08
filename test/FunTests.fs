namespace MajungaDataTests



module FunTests =
    open Xunit
    open System
    open Asserts
    open Majunga.Fun

    module PigLatinTests =
        [<Fact>]
        let ``No word given`` () =
            PigLatin "" |> equal "Iay eednay aay ordway!"
        
        [<Fact>]
        let ``One letter`` () =
            PigLatin "I" |> equal "Iay"
        
        [<Fact>]    
        let ``Word Test`` () =
            PigLatin "word" |> equal "ordway"
            
        [<Fact>]    
        let ``Recursion Test`` () =
            PigLatin "thyroid" |> equal "oidthyray"
                
        [<Fact>]    
        let ``Rhythm Test`` () =
            PigLatin "rhythm" |> equal "rhythmay"  

        [<Fact>]    
        let ``Pigs will fly`` () =
            "pigs will fly" |> SentenceToPigLatin |> equal "igspay illway flyay"

    module FizzBuzzTests =

        [<Fact>]
        let Nothing () =
            FizzBuzz 1 |> equal "1"

        [<Fact>]
        let ``FizzBuzz!`` () =
            FizzBuzz 15 |> equal "15 - fizzbuzz"        

        [<Fact>]
        let Fizz () =
            FizzBuzz 3 |> equal "3 - fizz" 
            
        [<Fact>]
        let Buzz () =
            FizzBuzz 5 |> equal "5 - buzz"      

        [<Fact>]
        let ``FizzBuzz Array`` () =
            [|1..100|] |> FizzBuzzArray |> Array.map Console.WriteLine




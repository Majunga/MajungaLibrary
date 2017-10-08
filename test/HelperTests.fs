namespace MajungaDataTests



module HelperTests =
    open Xunit
    open System
    open Asserts
    open Majunga.Helpers

    module StringTests =
        [<Fact>]
        let ``String Has a Lower case`` () =
            "String Has a Lower Case" |> String.hasLower |> equal false

        [<Fact>]
        let ``String Has NO Lower case`` () =
            "STRING HAS NO LOWER CASE" |> String.hasLower |> equal true        
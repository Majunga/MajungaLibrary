module Majunga.PatternMatching

    module String =
        open Majunga.Helpers.String
        let (|Empty|_|) (input:string) =
            if (isNullOrWhiteSpace input) then Some input
            else None

        let (|Last|_|) (pattern : string) (input:string) =
            if (input.EndsWith pattern) then Some input
            else None

        let (|AllCaps|_|) (input:string) =
            if (hasLetters input && hasNoLower input) then Some input
            else None
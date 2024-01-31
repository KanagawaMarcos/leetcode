open System
open FSharp.Collections

type Solution() =
    member this.Merge(nums1: byref<int[]>, m: int, nums2: int[], n: int) =
        
        let mutable occurrencies = Map[]
        // Key -> Number
        // Value -> Array of occurencies
        // Save Occurrencies on nums1
        for i in 0 .. m-1 do
            if occurrencies.ContainsKey(nums1.[i]) then
                let cur = nums1.[i]
                occurrencies <- occurrencies.Add (nums1.[i], [yield! occurrencies.Item(cur); cur])
            else
                occurrencies <- occurrencies.Add (nums1.[i], [nums1.[i]])
        // Save Occurrencies on nums2 
        for j in 0 .. n-1 do
            if occurrencies.ContainsKey(nums2.[j]) then
                occurrencies <- occurrencies.Add (nums2.[j], [yield! occurrencies.Item(nums2.[j]); nums2.[j]])
            else
                occurrencies <- occurrencies.Add (nums2.[j], [nums2.[j]])
        
        // Prints occurrencies
        Seq.iter (printfn "%A") occurrencies
        // Remake nums1 
        let mutable res = []
        for KeyValue(k,v) in occurrencies do
            let byRefClosure = nums1 |> Array.toList
            res <- List.append res [yield! v]
        nums1 <- res |> Array.ofList
        ()


let mutable nums1 = [|1;2;3;0;0;0|]
let m = 3
let nums2 = [|2;5;6|]
let n = 3

let solution = Solution().Merge(&nums1,m,nums2,n)

nums1


(**
- title : Introduction to F#
- description : An introduction to F# and functional programming for JavaScript developers
- author : Ryan Riley (@panesofglass)
- theme : night
- transition : default

***

*)

(*** hide ***)
#I "../packages"
#r "FsCheck/lib/net45/FsCheck.dll"

(**

# Intro to F#
<a href="http://fsharp.org/"><img alt="F# Software Foundation" src="images/fssf.png" /></a>

***

## Ryan Riley
<img alt="Tachyus logo" src="images/tachyus.png" style="background-color:#fff;" />
### [@panesofglass](https://twitter.com/panesofglass)
### [github/panesofglass](https://github.com/panesofglass)

***

# Agenda

* What is F#?
* Why Learn FP?
* Code!
* How do you learn more?
* Questions

***

# What is F#?

***

## Open Source

* Apache 2 License
* [Microsoft/visualfsharp](https://github.com/Microsoft/visualfsharp)
* [fsharp/fsharp](https://github.com/fsharp/fsharp)

***

## Functional-first

* Types -> data structures
* Behaviors -> modules of functions
* First-class and higher order functions

' These are simply the most basic defaults and make up
' the bulk of the OOB FSharp.Core.

***

## Immutable by default

' Values are immutable by default in F#. You must explicitly
' declare a value to be mutable or stored in a ref cell if 
' you want to mutate it later.

***

## Avoid `null`

' Almost. .NET code uses `null`, so it's impossible to escape it entirely.
' However, F# avoids allowing `null` by default. Use `'a option` instead.

***

## Statically typed

' This is not your normal Java-style static typing, however.
' F# provides type inference, so you often don't have to specify
' the types of your programs except in cases where you use OO-
' style accessors.

***

## Multi-paradigm

* Functional
* Object-oriented
* Language-oriented

***

## Cross-platform

* Desktop and Server
  * [.NET](http://fsharp.org/use/windows/)
  * [Mono](http://fsharp.org/use/linux/)
* Mobile
  * [Xamarin](https://developer.xamarin.com/guides/cross-platform/fsharp/)
* Web Browser / Node / Electron
  * [Fable](http://fsprojects.github.io/Fable/)
  * [WebSharper](http://websharper.com/)
* [GPU](http://fsharp.org/use/gpu/)

' .NET has a very broad reach across platforms, which means F#
' also has a broad platform reach. You can run F# programs almost
' anywhere!

***

## Scriptable

* [Build scripts](http://fsharp.github.io/FAKE/)
* [Slide decks](http://fsprojects.github.io/FsReveal/)
* [Azure Web Jobs](https://github.com/isaacabraham/fsharp-demonstrator)
* [Azure Functions](http://stackoverflow.com/a/36519526)*
* Notebook / Workbook
  * [FsLab](http://fslab.org/)
  * [Jupyter](https://github.com/fsprojects/IfSharp)
  * [Xamarin Workbooks](https://developer.xamarin.com/guides/cross-platform/workbooks/)*

' F# provides a script format, *.fsx, that allows you to
' write scripts that can be run by F# Interactive, the
' tool that also powers the REPL. The FSharp.Compiler.Service
' allows you execute F# scripts from within another .NET
' program, as well. Examples include FAKE and scriptcs-fsharp.
' In addition, you can generate slide decks like this one
' or use a workbook style approach using scripts.
' * Indicates work in progress.

***

## ML Family

* [OCaml](http://ocaml.org/)
* [Reason](https://facebook.github.io/reason/)
* [Swift](https://developer.apple.com/swift/) (similar)
* [Haskell](https://www.haskell.org/)

' This is important b/c learning F# gets you much closer to
' learning these other languages. ML languages are rising in
' popularity. This is only a small sample of ML-style languages.

***

# Why Learn FP?

* Think mathematically
* Easy to test
* Improve correctness
* Separate structure and behavior
* Enhance reusability

***

> I think the lack of reusability comes in object-oriented languages, not functional languages. Because the problem with object-oriented languages is they’ve got all this implicit environment that they carry around with them. You wanted a banana but what you got was a gorilla holding the banana and the entire jungle.
>
> If you have referentially transparent code, if you have pure functions — all the data comes in its input arguments and everything goes out and leave no state behind — it’s incredibly reusable.

<cite>Joe Armstrong, Source: Coders at Work.</cite>

***

## React Component

    [lang=js]
    class MyComponent extends React.Component {
        render() {
            return (
                <a onClick="this.props.clickAction">
                    <span>
                        Past Revenues: {this.props.pastRevenues}
                    </span>
                    <span>
                        New Revenues: {this.props.newRevenues}
                    </span>
                </a>
            );
        }
    }

<cite>Source: https://gist.github.com/brantphoto/2c4c921107c4eaf8702d780356876df9</cite>

***

## Stateless Component

    [lang=js]
    const MyComponent = (props) =>
        <a onClick="clickAction">
            <span>
                Past Revenues: {props.pastRevenues}
            </span>
            <span>
                New Revenues: {props.newRevenues}
            </span>
        </a>;

<cite>Source: https://gist.github.com/brantphoto/2c4c921107c4eaf8702d780356876df9</cite>

***

# Code!

***

## `let` Bindings

*)

let x = 1
let tuple = ("text", 2, true)
let list = [1;2]
let lst = 1::2::[]
let arr = [|1;2;3|]

(**

' let bindings allow you declare values. These are not assignment operations.
' You can re-bind these just like let in ES2015.

***

## Modules

*)

module Prelude =

    /// Transforms a function by flipping the order of its arguments.
    let inline flip f a b = f b a
    
    /// Transforms an uncurried function to a curried function.
    let inline curry f a b = f(a,b)

    /// Transforms an uncurried function to a curried function.
    let inline uncurry f = fun (a,b) -> f a b
    
    /// Fixed point combinator.
    let rec fix f x = f (fix f) x

(**

' Modules allow you to declare related sets of functionality,
' just like you might declare modules in ES2015. The above shows
' a few useful function definitions. Note that in F#, you use let
' to define both function and value bindings. The above examples
' also show the syntax for lambdas and recursive functions.

***

## Types

---

## Records

*)

type Person = { FirstName: string; LastName: string }

let ryan = { FirstName = "Ryan"; LastName = "Riley" }

(*** include-value: ryan ***)

(**

---

## Classes

*)

type Pet(name) =
    // constructor set up occurs here.
    member this.Name = name
    override this.ToString() =
        this.Name

(**

---

## Unions

*)

type DogBreed =
    | ``Basset Hound``
    | Poodle
    | Other of string
 
type BetterPet =
    | Dog of name:string * breed:DogBreed
    | Fish of name:string

(**

' Unions are a great way to build class hierarchies and
' define strict options. They are similar to enums and
' a similar syntax is used to create .NET enums. Unions
' are only useful when you have the next feature:
' pattern matching.

***

## Pattern Matching

*)

let pet1 = Dog("Josie", ``Basset Hound``)
let petResult =
    match pet1 with
    | Dog(name, breed) ->
        let br =
            match breed with
            | Other b -> b
            | _ -> sprintf "%A" breed
        sprintf "%s is a %s" name br
    | Fish name -> sprintf "%s is a fish" name
(*** include-value: petResult ***)

(**

---

## TypeScript Unions

    [lang=ts]
    class Dog {
        constructor(public name: string, public breed: string) { }
    }
    class Fish {
        constructor(public name: string) { }
    }
    type Pet = Dog | Fish

    const matchPet = (pet: Pet) => {
        if (pet instanceof Dog) {
            // ... pet will be of type Dog in this scope
        } else {
            // ... pet will be of type Fish in this scope
        }
    };

' As a side note, TypeScript provides "untagged" unions. There is no
' support for pattern matching "untagged" unions, but you can use them
' to further restrict the allowed parameter types, which can be quite
' helpful.

---

## Tuples

*)

// tuple was defined above as ("text", 2, true)
let (text, number, boolean) = tuple
(** Value of text: *)
(*** include-value: text ***)
(** Value of number *)
(*** include-value: number ***)
(** Value of boolean *)
(*** include-value: boolean ***)

(**

---

## Destructuring JS Tuples

    [lang=js]
    let [text, num, bool] = ["text", 2, true];
    console.log(text); // "text"
    console.log(num); // 2
    console.log(bool); // true

' Pattern matching is roughly equivalent to destructuring.
' However, pattern matching takes destructuring to a whole new level.

---

## Records

*)

let ryanMatch =
    match ryan with
    | { FirstName = "Ryan"; LastName = "Ryan" } -> "found Ryan Ryan"
    | { LastName = "Ryan" } -> "found Ryan in LastName"
    | { FirstName = "Ryan" } -> "found Ryan in FirstName"
    | { FirstName = first; LastName = last } ->
        sprintf "found %s %s, not Ryan" first last
(*** include-value: ryanMatch ***)

let { LastName = last } = ryan
(*** include-value: last ***)

(**

' Pattern matching on records is quite nice, b/c you can match on all
' or only a part of the value. You can also lift a single field out of the record.

---

## Destructuring JS Objects

    [lang=js]
    let {first, last} = {firstName:"Ryan", lastName:"Riley"};
    console.log(first); // "Ryan"
    console.log(last); // "Riley"

    let {a, b, ...rest} = {a:1, b:2, c:3, d:4}; // ES2016

---

## Lists

*)

let listMatch =
    match list with
    | [] -> "empty list"
    | [x] -> sprintf "one item: %i" x
    | hd::tl -> sprintf "more than one item of %i and %A" hd tl
(*** include-value: listMatch ***)

(**

' List pattern matches are very powerful and useful in many
' forms of computation. You can do something similar in ES2015
' with the spread operator, but you don't have the full power
' of the match syntax and would have to use if ... then ... else.

---

## Arrays

*)

let arrMatch =
    match arr with
    | [||] -> "empty array"
    | [|x|] -> sprintf "one item: %i" x
    | [|x;y|] -> sprintf "two items: %i and %i" x y
    | _ -> sprintf "more than one item of %A" arr
(*** include-value: arrMatch ***)

(**

---

## Arrays (cont)

*)

#nowarn "0025"

let [|a;b|], c = arr.[0..1], arr.[2..]
(** Value of a *)
(*** include-value: a ***)
(** Value of b *)
(*** include-value: b ***)
(** Value of c *)
(*** include-value: c ***)

(**

' Arrays are more limited than lists when used in match expressions,
' but they have useful slice operators for pulling off known ranges.

---

## Destructuring JS Arrays

    [lang=js]
    let [a, b, ...c] = [1, 2, 3];
    console.log(a); // 1
    console.log(b); // 2
    console.log(c); // [3]

---

## Guards

*)

let guardResult =
    match ryan with
    | { LastName = "Riley" } when not (Array.isEmpty c) -> "Winner!"
    | { LastName = "Riley" } -> "Living the life of Riley"
    | _ -> "better luck next time"

(*** include-value: guardResult ***)

(**

' Sometimes, regular pattern matching isn't good enough, and you need
' to add additional checks. `when` guards provide that help.

---

## Active Patterns

*)

let (|StartsA|StartsB|Invalid|) (text:string) =
    if text.StartsWith("A") then StartsA text
    elif text.StartsWith("B") then StartsB text
    else Invalid

let apResult =
    match "Abracadabra" with
    | StartsA t -> "starts with A"
    | StartsB t -> "starts with B"
    | Invalid -> "invalid"

(*** include-value: apResult ***)

(**

' You can create functions called Active Patterns to
' adapt regular .NET types to work with pattern matching.

***

## Pipe `|>`

*)

(** Value of list *)
(*** include-value: list ***)

let listResult =
    list
    |> List.map (fun i -> i * i)
    |> List.filter (fun i -> i > 1)
    |> List.sum
(*** include-value: listResult ***)

(**

---

## Pipe Forward in JS

[ES7 Proposal: The Pipeline Operator](https://github.com/mindeavor/es-pipeline-operator/blob/master/README.md)

' F# has popularized the |> operator that can now be found
' many languages, including Swift, Elixir, and even a proposal
' for ES2016!

---

## Custom Operators

*)

// bind operator from Haskell
let (>>=) m f = m |> Array.collect f
let chars =
    [|"john";"jacob";"jingle"|] >>= fun s -> s.ToCharArray()
(*** include-value: chars ***)

(**

' On occasion, it's nice to have infix operators that you can
' stick between two arguments. Custom operators provide that
' possibility. However, don't take it too far!

---

## Tie-fighter operator

*)

let infixResult = a |>(+)<| b
(*** include-value: infixResult ***)

let infix2Result = None |>defaultArg<| 2
(*** include-value: infix2Result ***)

(**

' You can also combine the pipe-forward and pipe-backward
' operators to turn a normal F# function into an infix function.
' This is not very pretty and doesn't always work like you might
' expect due to operator precedence. It's fun name has increased
' it's popularity.
' Source: https://twitter.com/MattDrivenDev/status/415433890502033408

***

## Computation Expressions!

' Computations expressions allow you to extend the language
' while retaining the consistency of the F# language.

---

## Async

*)

open System.Net
let req1 = HttpWebRequest.Create("http://tryfsharp.org")
let req2 = HttpWebRequest.Create("http://google.com")
let req3 = HttpWebRequest.Create("http://bing.com")

async {
    use! resp1 = req1.AsyncGetResponse()  
    printfn "Downloaded %O" resp1.ResponseUri

    use! resp2 = req2.AsyncGetResponse()  
    printfn "Downloaded %O" resp2.ResponseUri

    use! resp3 = req3.AsyncGetResponse()  
    printfn "Downloaded %O" resp3.ResponseUri
} |> Async.RunSynchronously

(**

---

## Option

*)

let divideBy bottom top =
    if bottom = 0
    then None
    else Some(top/bottom)

(**

---

## Option (cont)

*)

let divideByNested init x y z = 
    let a = init |> divideBy x
    match a with
    | None -> None  // give up
    | Some a' ->    // keep going
        let b = a' |> divideBy y
        match b with
        | None -> None  // give up
        | Some b' ->    // keep going
            let c = b' |> divideBy z
            match c with
            | None -> None  // give up
            | Some c' ->    // keep going
                //return 
                Some c'

(**

---

## Option (cont)

*)

type MaybeBuilder() =

    member this.Bind(x, f) = 
        match x with
        | None -> None
        | Some a -> f a

    member this.Return(x) = 
        Some x
   
let maybe = new MaybeBuilder()

(**

---

## Option (cont)

*)

let divideByWorkflow init x y z = 
    maybe {
        let! a = init |> divideBy x
        let! b = a |> divideBy y
        let! c = b |> divideBy z
        return c
    }

(**

---

## Option (cont)

*)

let maybeSome = divideByWorkflow 64 2 2 2
(*** include-value: maybeSome ***)

let maybeZero = divideByWorkflow 64 2 0 4
(*** include-value: maybeZero ***)

(**

---

## JavaScript Comparisons

* [async/await](https://github.com/tc39/ecmascript-asyncawait)
* [Fantasy Land](https://github.com/fantasyland/fantasy-land)

***

## Type Providers!

* [FSharp.Data](http://fsharp.github.io/FSharp.Data/)
* [FSharp.Data.SqlClient](http://fsprojects.github.io/FSharp.Data.SqlClient)
* [RProvider](http://bluemountaincapital.github.io/FSharpRProvider/)
* [FunScript](http://funscript.info/)

' Type providers provide types based on data schemas that are known
' or can be inferred. Type providers provide a bridge between F# and
' databases, file formats, web services, and even other programming
' platforms such as R and JavaScript.

***

## Correctness

---

## Units of Measure

[Mars Climate Orbiter Team Finds Likely Cause of Loss](http://mars.jpl.nasa.gov/msp98/news/mco990930.html)

*)

[<Measure>] type m
[<Measure>] type ft

let metersToFeet (input: float<m>) =
    input * 3.2808399<ft/m>

let feet = metersToFeet 5.<m>
(*** include-value: feet ***)

(**

' Note that most languages don't provide anything like this.
' You would need to create wrapper types, but it's still
' an interesting and useful feature and should remind you
' to think about such things in your own code.

---

## Property-based Testing

*)

open FsCheck
let revRevIsOrig (xs:list<int>) = List.rev(List.rev xs) = xs
(*** define-output: revRevIsOrig ***)
Check.Quick revRevIsOrig
(*** include-output: revRevIsOrig ***)

(**

' Property-based testing fills in the gap where the type system
' cannot fully protect you. Property-based test frameworks generate
' a lot of random values to try to find problems with your implementation.
' You define properties in much the same way as you might think of mathematical
' properties of your functions. Associativity, commutativity, etc. are good exampls.

---

## Property-based Testing

* [JsVerify](http://jsverify.github.io/) (JavaScript)
* [Rantly](https://www.sitepoint.com/the-how-and-why-of-property-based-testing-in-ruby/) (Ruby)

***

# F# Resources

* [F# Software Foundation](http://fsharp.org/)
* [F# for Fun and Profit](http://fsharpforfunandprofit.com/)
* [Community for F#](http://c4fsharp.net/)
* [FSharp.tv](https://fsharp.tv/)

***

# FP Resources

* [Functional programming? In my React Component?](https://gist.github.com/brantphoto/2c4c921107c4eaf8702d780356876df9)
* [How Do I Learn Some FP?](http://www.fse.guru/how-do-i-learn-some-fp)
* [JavaScript Allongé, the "Six" Edition](https://leanpub.com/javascriptallongesix)
* [Mostly Adequate Guide to FP](https://github.com/MostlyAdequate/mostly-adequate-guide)
* [Functional Programming in Scala](https://www.manning.com/books/functional-programming-in-scala)

***

# Questions?

***

# Houston FP Meetup

* [Introduction to Domain Modeling using Types](http://www.meetup.com/Houston-Functional-Programmers/events/231235775/)
* July 20, 2016
* 7:00 - 8:30 PM
* Miratech

*)
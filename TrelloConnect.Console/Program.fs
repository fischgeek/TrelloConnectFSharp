namespace TrelloConnect

open System
open TrelloConnect

module Main = 
    let wait() = Console.ReadLine() |> ignore
    let outTitle t meta = printfn "%s (%s)" t meta
    let outData (label: 'a) data = 
        printfn "\t%s: %s" (label.ToString()) data

    [<EntryPoint>]
    let main argv =
        let cfg = Config.GetConfig()
        outTitle "API Info" "key/tok"
        outData "key" cfg.APIKey
        outData "tok" cfg.APIToken
        let boardId = "5ff495973c9e0f19fb2baf4e"
        let listId = "5ff495973c9e0f19fb2baf4f"
        let cardId = "5ff5df30aec00a20fca828af"

        outTitle "Get all boards" ""
        Trello.GetBoards()
        |> Seq.iter (fun b -> outData b.Id b.Name)
        
        outTitle "Get a board" boardId 
        let b = Trello.GetBoardById boardId
        outData "board" b.Name

        outTitle "Get lists on a board" boardId
        Trello.GetLists boardId
        |> Seq.iter (fun l -> outData l.Id l.Name)

        outTitle "Get a list" listId
        let l = Trello.GetListById listId
        outData l.Id l.Name
        
        outTitle "Get cards on a list" listId
        Trello.GetCards listId
        |> Seq.iter (fun c -> outData c.Id c.Name)

        outTitle "Get a card" cardId
        let c = Trello.GetCardById cardId
        outData c.Id c.Name

        outTitle "Get attachements on a card" cardId
        let attachments = Trello.GetCardAttachments cardId
        outData "attachments" (attachments.Length.ToString())
        attachments |> Seq.iteri (fun i a -> outData i a.Name)
        wait()
        0

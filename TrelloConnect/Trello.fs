namespace TrelloConnect

open System
open System.Configuration

module Trello =
    let private MakeCall verb url fn msg =
        HRB.Url url
        |> verb
        |> function
        | Success x -> fn x
        | _ -> failwith msg

    let private Get url fn msg = MakeCall HttpGet url fn msg
    let private Put url fn msg = MakeCall HttpPut url fn msg
    let private Del url fn msg = MakeCall HttpDel url fn msg

    let GetBoards() = Get Routes.MyBoards Types.ParseBoards "Could not get boards."
    let GetBoardById id = Get (Routes.Board id) Types.ParseBoard "Could not get board."
    let GetLists boardId = Get (Routes.Lists boardId) Types.ParseLists "Could not get lists."
    let GetListById listId = Get (Routes.List listId) Types.ParseList "Could not get list."
    let GetCards listId = Get (Routes.Cards listId) Types.ParseCards "Could not get cards."
    let GetCardById cardId = Get (Routes.Card cardId) Types.ParseCard "Could not get card."
    let GetCardAttachments cardId = Get (Routes.CardAttachments cardId) Types.ParseAttachments "Could not get attachments."
    let DeleteCard cardId = Del (Routes.Card cardId) (fun x -> "") "Failed to delete card."
    let ArchiveCard cardId = Put (Routes.ArchiveCard cardId) (fun x -> "") "Failed to archive card."

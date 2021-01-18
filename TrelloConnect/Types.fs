namespace TrelloConnect

open FSharp.Data

module Types = 
    type Boards = JsonProvider<"Samples/boards.sample.json", RootName="Boards">
    type Board = JsonProvider<"Samples/board.sample.json", RootName="Board">
    type Lists = JsonProvider<"Samples/lists.sample.json", RootName="Lists">
    type List = JsonProvider<"Samples/list.sample.json", RootName="List">
    type Cards = JsonProvider<"Samples/cards.sample.json", RootName="Cards">
    type Card = JsonProvider<"Samples/card.sample.json", RootName="Card">
    type Attachments = JsonProvider<"Samples/attachments.sample.json", RootName="Attachments">
    
    let ParseBoards x = Boards.Parse x
    let ParseBoard x = Board.Parse x
    let ParseLists x = Lists.Parse x
    let ParseList x = List.Parse x
    let ParseCards x = Cards.Parse x
    let ParseCard x = Card.Parse x
    let ParseAttachments x = Attachments.Parse x

namespace TrelloConnect

open System

module Pipes = 
    type Board = 
        { Id: string
          Name: string }
        static member GetBoardById id = ()

    and CardPipe = 
        static member CreatedDate (cardId: string) = 
            let firstEight = cardId.Substring(0, 8)
            let converted = System.Convert.ToInt64(firstEight, 16)
            let dt = DateTimeOffset.FromUnixTimeSeconds(converted).DateTime
            dt



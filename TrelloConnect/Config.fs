namespace TrelloConnect

open System.Configuration
//open Types
open System.IO

module Config =
    let c = ConfigurationManager.AppSettings
    let GetConfig() =
        {| APIKey = c.["APIKey"]
           APIToken = c.["APIToken"] |}

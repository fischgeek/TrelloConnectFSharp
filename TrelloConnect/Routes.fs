namespace TrelloConnect

open System.Configuration

module Routes = 
    let private c = ConfigurationManager.AppSettings
    let private key = c.["APIKey"]
    let private tok = c.["APIToken"]
    let BaseURL = "https://api.trello.com/1"
    let Auth = sprintf "key=%s&token=%s" key tok
    let MyBoards = sprintf "%s/members/me/boards?%s" BaseURL Auth
    let Board id = sprintf "%s/boards/%s?%s" BaseURL id Auth 
    let Lists boardid = sprintf "%s/boards/%s/lists?%s" BaseURL boardid Auth
    let List id = sprintf "%s/lists/%s?%s" BaseURL id Auth
    let Cards listId = sprintf "%s/lists/%s/cards?%s" BaseURL listId Auth
    let Card id = sprintf "%s/cards/%s?%s" BaseURL id Auth
    let CardAttachments cardId = sprintf "%s/cards/%s/attachments?%s" BaseURL cardId Auth
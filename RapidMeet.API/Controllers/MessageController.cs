using Microsoft.AspNetCore.Mvc;
using RapidMeet.Application.DTOs;
using RapidMeet.Application.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] MessageDTO messageDTO)
    {
        await _messageService.SendMessageAsync(messageDTO);
        return Ok();
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetMessages(int userId)
    {
        var messages = await _messageService.GetMessagesForUserAsync(userId);
        return Ok(messages);
    }
}

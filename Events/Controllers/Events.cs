using System.Collections.Concurrent;
using Events.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private static ConcurrentBag<Event> events = new();
    
    [HttpPost]
    public async Task<IActionResult> PostEvent([FromBody] EventRequestModel eventModel)
    {
        var newEvent = new Event();

        newEvent.Name = eventModel.Name;
        newEvent.Value = eventModel.Value;
        
        events.Add(newEvent);

        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSummary()
    {
        var query = from e in events 
            group e by e.Time
            into g
            select new EventSummaryModel { Time = g.Key, Value = g.Sum(x => x.Value) };
        
        return Ok(query);
    }
}

public class EventRequestModel
{
    public string Name { get; set; } = string.Empty;

    public int Value { get; set; } = 0;
}

public class EventSummaryModel
{
    public string Time { get; set; } 
    public int Value { get; set; }
}
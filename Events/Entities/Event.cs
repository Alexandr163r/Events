namespace Events.Entities;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; } = string.Empty;
    
    public int Value { get; set; }

    public string Time { get; set; } = DateTime.Now.ToString("MM/dd/yyyy H:mm");
}
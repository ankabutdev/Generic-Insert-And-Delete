namespace DemoCrudAdoNet.Entities.Messages;

public class Message
{
    public int MessageId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string MessageContent { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedAt { get; set; }

}
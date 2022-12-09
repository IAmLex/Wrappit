using Microsoft.AspNetCore.Mvc;
using Wrappit.Messaging;

namespace Wrappit.Demo.Controllers;

[ApiController]
[Route("message")]
public class MessageController : ControllerBase
{
    private readonly IWrappitPublisher _publisher;

    public MessageController(IWrappitPublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpPost]
    public void Send(string message)
    {
        _publisher.Publish("Demo.Topic", new ExampleEvent { ExampleProperty = message });
    }
}

public class ExampleEvent : DomainEvent 
{
    public string ExampleProperty { get; set; }
}
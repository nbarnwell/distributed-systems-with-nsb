public void PlaceOrder(int orderId, int userId, int invoiceId) 
{
    // Implementation here...
}











public class PlaceOrderCommand
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int InvoiceId { get; set; }
}

public class PlaceOrderHandler : ICommandHandler<PlaceOrderCommand>
{
    public void Handle(PlaceOrderCommand command)
    {
        // Implementation here...
        _bus.Send(new OrderPlacedEvent(command.OrderId, ...);
    }
}









public class OrderPlacedHandler : IEventHandler<OrderPlacedEvent>
{
    public void Handle(OrderPlacedEvent evt)
    {
        // Implementation here...
    }
}

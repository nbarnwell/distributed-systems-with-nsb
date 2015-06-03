using System;

namespace OrderProcessor.Messages.V1
{
    public class OrderPlaced
    {
        public Guid OrderId { get; set; }
        public string CustomerReference { get; set; }

        public override string ToString()
        {
            return string.Format("OrderId: {0}, CustomerReference: {1}", OrderId, CustomerReference);
        }
    }
}
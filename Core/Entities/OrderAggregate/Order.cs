
using System;
using System.Collections.Generic;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(
        IReadOnlyList<OrderItem> orderItems,
        string buyerEmail,
        string buyerPhoneNo,
        Address shipToAddress,
        DeliveryMethod deliveryMethod,
        decimal subTotal
        )
        {
            BuyerEmail = buyerEmail;
            BuyerPhoneNo = buyerPhoneNo;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            SubTotal = subTotal;      
        }

        public string BuyerEmail { get; set; }
        public string BuyerPhoneNo { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public DeliveryMethod DeliveryMethod { get; set; }
        public Address ShipToAddress { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Price;
        }
    }   
}
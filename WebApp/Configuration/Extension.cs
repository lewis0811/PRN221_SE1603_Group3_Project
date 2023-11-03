using Domain.Enums;
using System;

namespace WebApp.Configuration
{
    public class Extension
    {
        public OrderStatus getNext(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Collecting:
                    return OrderStatus.Washing;
                case OrderStatus.Washing:
                    return OrderStatus.Washed;
                case OrderStatus.Washed:
                    return OrderStatus.Finished;
            }
            return status;
        }
    }
}

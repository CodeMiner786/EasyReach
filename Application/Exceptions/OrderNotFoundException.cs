using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.Exceptions
{
    public class OrderNotFoundException(Guid orderId) : Exception($"Order with ID '{orderId}' was not found.")
    {
    }
}

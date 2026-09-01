using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.Exceptions
{
    public class InvalidCustomerInformationException(string message) : Exception(message)
    {
    }
}

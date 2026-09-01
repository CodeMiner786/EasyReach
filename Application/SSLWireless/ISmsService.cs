using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.SSLWireless
{
    public interface ISmsService
    {
        // phoneNumber accepts local (01XXXXXXXXX) or international (8801XXXXXXXXX) format.
        // isUnicode should be true for Bangla text.
        Task SendAsync(string phoneNumber, string message, bool isUnicode = false, CancellationToken cancellationToken = default);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.NotificationMessages
{
    public record NotificationMessage(
        string PhoneNumber,
        string Email,
        string SmsBody,
        string EmailSubject,
        string EmailBody
    );
}

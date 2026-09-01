using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Reviews
{
    public record AddReviewDto(Guid ProductId, int Rating, string Comment);
}

using EasyReach_Application.CQRS.Querys.Navigations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Navigations
{
    [ApiController]
    [Route("api/navigations")]
    [Tags("Navigations")]
    public class NavigationsController(ISender mediator) : ControllerBase
    {
        /// <summary>
        /// পাবলিক ফ্রন্টএন্ডে ডায়নামিক নেভিগেশন মেনু এবং সাব-মেনু (Tree View) দেখানোর জন্য
        /// </summary>
        [HttpGet("tree")]
        public async Task<IActionResult> GetTree() => Ok(await mediator.Send(new GetNavigationTreeQuery()));
    }
}


// Public Frontend-এ ডায়নামিক নেভিগেশন মেনু এবং সাব-মেনু (Tree View) দেখানোর জন্য এই API ব্যবহার করা হবে।

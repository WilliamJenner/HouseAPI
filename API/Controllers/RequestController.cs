// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace House.API.Controllers
{
    using House.API.Models.Request;
    using House.DAL;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("request")]
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("expire")]
        public IActionResult Expire()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> ExpireRows()
        {
            return await _requestRepository.ExpireRequestItems();
        }

        [HttpPost]
        public async Task<bool> SubmitRequest(RequestModel model)
        {
            return await _requestRepository.SaveRequestItem(new SaveItemRequest
            {
                Amount = model.Amount,
                Requester = model.Requester
            });
        }
    }
}

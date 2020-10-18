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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("expire")]
        public IActionResult Expire()
        {
            return View();
        }

        [HttpPost("ExpireRows")]
        public async Task<bool> ExpireRows() => await _requestRepository.ExpireRequestItems();

        [HttpPost("SubmitRequest")]
        public async Task<bool> SubmitRequest(RequestModel model) => await _requestRepository.SaveRequestItem(new SaveItemRequest
        {
            Amount = model.Amount,
            Requester = model.Requester
        });
    }
}

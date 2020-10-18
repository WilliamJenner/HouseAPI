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
        public IActionResult Index(bool? success)
        {
            return View("Index",new RequestModel
            {
                Success = success
            });
        }

        [HttpGet("expire")]
        public IActionResult Expire()
        {
            return View();
        }

        [HttpGet("amount")]
        public async Task<decimal> GetTotalAmount() => await _requestRepository.GetAmountRequired();

        [HttpPost("ExpireRows")]
        public async Task<bool> ExpireRows() => await _requestRepository.ExpireRequestItems();

        [HttpPost("SubmitRequest")]
        public async Task<IActionResult> SubmitRequest(RequestModel model)
        {
            return Index(await _requestRepository.SaveRequestItem(new SaveItemRequest
            {
                Amount = model.Amount,
                Requester = model.Requester
            }));
            
        }
    }
}

using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rentACar.Application.Features.Models.Models;
using rentACar.Application.Features.Models.Queries.GetListModel;
using rentACar.Application.Features.Models.Queries.GetListModelByDynamic;

namespace rentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery { PageRequest = pageRequest };

            ModelListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListModelByDynamicQuery getListModelByDynamicQuery = new GetListModelByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };

            ModelListModel result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }
    }
}

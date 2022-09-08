
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rentACar.Application.Features.Brands.Commands.CreateBrand;
using rentACar.Application.Features.Brands.Dtos;
using rentACar.Application.Features.Brands.Models;
using rentACar.Application.Features.Brands.Queries.GetByID;
using rentACar.Application.Features.Brands.Queries.GetListBrand;

namespace rentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
        {
            BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdBrandQuery);
            return Ok(brandGetByIdDto);
        }
    }
}

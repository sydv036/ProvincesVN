using AutoMapper;
using LearnOneProvincesVN.Api.BaseResponse;
using LearnOneProvincesVN.Domain.Dtos;
using LearnOneProvincesVN.Domain.Request;
using LearnOneProvincesVN.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Net;

namespace LearnOneProvincesVN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictsService _districtsService;
        private readonly IMapper _mapper;

        public DistrictsController(IDistrictsService districtsService, IMapper mapper)
        {
            _districtsService = districtsService;
            _mapper = mapper;
        }

        private BaseResponse<object> BaseResponTemplate(HttpStatusCode httpStatusCode, string message, object ojct)
        {
            return new BaseResponse<object>(httpStatusCode, message, 0, ojct);
        }

        private DistrictsDtos MapperObject(object ojct)
        {
            return _mapper.Map<DistrictsDtos>(ojct);
        }

        [HttpGet]
        public async Task<IActionResult> getAll(int? PageNumber = 1, int? PageSize = 5)
        {
            try
            {
                var result = _districtsService.GetAll();
                var page = result.ToPagedList((int)PageNumber, (int)PageSize);
                var pagingList = new Paging<IPagedList<DistrictsDtos>>(page.PageNumber, page.PageSize, page.PageCount, page);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Successfully", pagingList));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DistrictAddRequest districtAddRequest)
        {
            try
            {
                await _districtsService.AddAsync(MapperObject(districtAddRequest));
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Successfully", districtAddRequest));
            }
            catch (Exception ex)
            {
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DistrictUpdateRequest districtUpdateRequest)
        {
            try
            {
                _districtsService.UpdateAsync(MapperObject(districtUpdateRequest));
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Successfully", districtUpdateRequest));
            }
            catch (Exception ex)
            {
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _districtsService.DeleteAsync(id);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Successfully", "null"));
            }
            catch (Exception ex)
            {
                return NotFound("Invald");
            }

        }
        [HttpGet("/Tim-Kiem-Districts")]
        public async Task<IActionResult> timKiem(string name, int? PageNumber = 1, int? PageSize = 5)
        {
            try
            {
                var result = _districtsService.GetAll().Where(p => p.Districs_Name.Contains(name));
                var page = result.ToPagedList((int)PageNumber, (int)PageSize);
                var pagingList = new Paging<IPagedList<DistrictsDtos>>(page.PageNumber, page.PageSize, page.PageCount, page);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Successfully", pagingList));
            }
            catch (Exception ex)
            {
                return BadRequest("Server Error");
            }

        }
    }
}

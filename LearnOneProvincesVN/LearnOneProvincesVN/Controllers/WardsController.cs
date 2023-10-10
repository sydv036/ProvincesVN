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
    public class WardsController : ControllerBase
    {
        private readonly IWardsService _wardsService;
        private readonly IMapper _mapper;

        public WardsController(IWardsService wardsService, IMapper mapper)
        {
            _wardsService = wardsService;
            _mapper = mapper;
        }

        private WardsDtos MapperObject(object ojct)
        {
            return _mapper.Map<WardsDtos>(ojct);
        }

        private BaseResponse<object> BaseResponTemplate(HttpStatusCode httpStatusCode, string message, object ojct)
        {
            return new BaseResponse<object>(httpStatusCode, message, 0, ojct);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? PageNumber = 1, int? PageSize = 5)
        {
            try
            {
                var result = _wardsService.GetAll();
                var page = result.ToPagedList((int)PageNumber, (int)PageSize);
                var pagingList = new Paging<IPagedList<WardsDtos>>(page.PageNumber, page.PageSize, page.PageCount, page);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Success", pagingList));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(WardsAddRequest wardsAddRequest)
        {
            try
            {
                _wardsService.AddAsync(MapperObject(wardsAddRequest));
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Add thanh cong", wardsAddRequest));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(WardsUpdateRequest wardsUpdateRequest)
        {
            try
            {
                _wardsService.UpdateAsync(MapperObject(wardsUpdateRequest));
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Update thanh cong", wardsUpdateRequest));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                _wardsService.DeleteAsync(id);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Xoa thanh cong", "null"));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return NotFound("Invalid");
            }

        }
    }
}

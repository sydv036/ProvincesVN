using AutoMapper;
using LearnOneProvincesVN.Api.BaseResponse;
using LearnOneProvincesVN.Domain.Dtos;
using LearnOneProvincesVN.Domain.Request;
using LearnOneProvincesVN.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;

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

        private BaseResponse<object> BaseResponTemplate(string message, object ojct)
        {
            return new BaseResponse<object>(System.Net.HttpStatusCode.OK, message, 0, ojct);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? PageNumber = 1, int? PageSize = 5)
        {
            var result = _wardsService.GetAll();
            var page = result.ToPagedList((int)PageNumber, (int)PageSize);
            var pagingList = new Paging<IPagedList<WardsDtos>>(page.PageNumber, page.PageSize, page.PageCount, page);
            return Ok(BaseResponTemplate("Thanh cong", pagingList));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(WardsAddRequest wardsAddRequest)
        {
            _wardsService.AddAsync(MapperObject(wardsAddRequest));
            return Ok(BaseResponTemplate("Add thanh cong", wardsAddRequest));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(WardsUpdateRequest wardsUpdateRequest)
        {
            _wardsService.UpdateAsync(MapperObject(wardsUpdateRequest));
            return Ok(BaseResponTemplate("Update thanh cong", wardsUpdateRequest));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _wardsService.DeleteAsync(id);
            return Ok(BaseResponTemplate("Xoa thanh cong", "null"));
        }
    }
}

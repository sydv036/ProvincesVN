using AutoMapper;
using LearnOneProvincesVN.Api.BaseResponse;
using LearnOneProvincesVN.Domain.Dtos;
using LearnOneProvincesVN.Domain.Request;
using LearnOneProvincesVN.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Net;

namespace LearnOneProvincesVN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvincesService _provincesService;
        private readonly IMapper _mapper;

        public ProvincesController(IProvincesService provincesService, IMapper mapper)
        {
            _provincesService = provincesService;
            _mapper = mapper;
        }

        private ProvincesDtos MapperObject(object objc)
        {
            return _mapper.Map<ProvincesDtos>(objc);
        }

        private BaseResponse<object> BaseResponTemplate(HttpStatusCode httpStatus, string message, object? ojct)
        {
            return new BaseResponse<object>(httpStatus, message, 0, ojct);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int? PageNumber = 1, int? PageSize = 5)
        {
            try
            {
                var result = _provincesService.GetAll();
                var page = result.ToPagedList((int)PageNumber, (int)PageSize);
                var pagingList = new Paging<IPagedList<ProvincesDtos>>(page.PageNumber, page.PageSize, page.PageCount, page);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Success", pagingList));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(ProvincesAddRequest provincesRequest)
        {
            try
            {
                var provincesDtos = MapperObject(provincesRequest);
                await _provincesService.AddAsync(provincesDtos);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Success", provincesRequest));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Ok(BaseResponTemplate(HttpStatusCode.NotAcceptable, "Error", null));
            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProvincesUpdateRequest provincesUpdate)
        {
            try
            {
                var provincesDtos = MapperObject(provincesUpdate);
                _provincesService.UpdateAsync(provincesDtos);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Success", provincesUpdate));
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
                _provincesService.DeleteAsync(id);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Success", "null"));
            }
            catch (Exception ex)
            {
                return NotFound("Invalid");
            }

        }
        [HttpGet]
        [Route("/Tim-kiem")]
        [Authorize]
        public async Task<IActionResult> timKiem(string nameProvince, int? PageNumber = 1, int? PageSize = 5)
        {
            try
            {
                var result = _provincesService.GetAll().Where(p => p.Provinces_Name.Contains(nameProvince));
                var page = result.ToPagedList((int)PageNumber, (int)PageSize);
                var pagingList = new Paging<IPagedList<ProvincesDtos>>(page.PageNumber, page.PageSize, page.PageCount, page);
                return Ok(BaseResponTemplate(HttpStatusCode.OK, "Success", pagingList));
            }
            catch (Exception ex)
            {
                return BadRequest("Server Error");
            }

        }
    }
}

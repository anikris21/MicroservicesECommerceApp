using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        ResponseDto _response = new ResponseDto();
        public CouponAPIController(AppDbContext appDbContext) {
            _db = appDbContext;
        }

        [HttpGet]
        public ResponseDto GetCoupons()
        {
           try
            {
                _response.Result = _db.Coupons;
                _response.IsSuccess = true;


            } catch
            {
                _response.IsSuccess = false;

            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            _response.Result = _db.Coupons.FirstOrDefault(c => c.CouponId == id);
            _response.IsSuccess = true;
            return _response;
        }



    }
}

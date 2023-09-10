using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        ResponseDto _response = new ResponseDto();
        IMapper mapper;

        public CouponAPIController(AppDbContext appDbContext, IMapper mapper)
        {
            _db = appDbContext;
            this.mapper = mapper;
        }

        [HttpDelete]
        //[Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon c = _db.Coupons.First(c => c.CouponId == id);
                _db.Coupons.Remove(c);

                _db.SaveChanges();
                _response.Result = mapper.Map<CouponDto>(c);
                _response.IsSuccess = true;

            }
            catch
            {
                _response.IsSuccess = false;

            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put(CouponDto couponDto)
        {
            try
            {
                _db.Coupons.Update(mapper.Map<Coupon>(couponDto));

                _db.SaveChanges();
                _response.Result = couponDto;
                _response.IsSuccess = true;

            }
            catch
            {
                _response.IsSuccess = false;

            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post1(CouponDto couponDto)
        {
            try
            {
                _db.Coupons.Add(mapper.Map<Coupon>(couponDto));
                
                _db.SaveChanges();
                _response.Result = couponDto;
                _response.IsSuccess = true;

            }
            catch
            {
                _response.IsSuccess = false;

            }
            return _response;
        }

        [HttpGet]
        public ResponseDto GetCoupons()
        {
           try
            {
             
                _response.Result = mapper.Map<IEnumerable<CouponDto>>(_db.Coupons);
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
       
            _response.Result = mapper.Map<CouponDto>(_db.Coupons.FirstOrDefault(c => c.CouponId == id));
            _response.IsSuccess = true;
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {

            _response.Result = mapper.Map<CouponDto>(_db.Coupons.FirstOrDefault(c => c.CouponCode == code));
            _response.IsSuccess = true;
            return _response;
        }



    }
}

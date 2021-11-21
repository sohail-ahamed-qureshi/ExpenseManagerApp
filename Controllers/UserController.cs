using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        [HttpPost]
        public ActionResult RegisterUser(UserReq ReqPayload)
        {
            var response = _userBL.RegisterUser(ReqPayload);
            if (string.IsNullOrEmpty(response.Token))
            {
                return Ok(new { Success = true, Message = "Login Successful", Data = response });
            }
            return BadRequest(new { Success = false, Message = "Login Failed" });
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAppUdemy.Business;
using RestAppUdemy.Data.VO;

namespace RestAppUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [AllowAnonymous]
        public object Post([FromBody] UserVO user)
        {
            if (user == null)
                return BadRequest();

            return _loginBusiness.FindByLogin(user);
        }

    }
}

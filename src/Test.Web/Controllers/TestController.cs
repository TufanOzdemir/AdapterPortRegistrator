using Microsoft.AspNetCore.Mvc;
using Test.Domain;

namespace Test.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestPort1 _testPort1;
        private readonly ITestPort2 _testPort2;
        private readonly ITestPort3 _testPort3;

        public TestController(ITestPort1 testPort1, ITestPort2 testPort2, ITestPort3 testPort3)
        {
            _testPort1 = testPort1;
            _testPort2 = testPort2;
            _testPort3 = testPort3;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _testPort1.A();
            _testPort2.C(1);
            _testPort3.D();
            return Ok();
        }
    }
}
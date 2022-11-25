using Microsoft.AspNetCore.Mvc;
using WebApplicationTestFile.Services;
using verify = WebApplicationTestFile.Services.verify;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationTestFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class verifyController : ControllerBase
    {
        static List<verify> LoginList;

        static verifyController()
        {
            LoginList = new List<verify>();
            LoginList.Add(new verify() { Userid = 1, Email = "michael@gmail.com", Password = "alligator13" });
            LoginList.Add(new verify() { Userid = 2, Email = "dorian.yahoo.com", Password = "hackeralptraum123" });
            LoginList.Add(new verify() { Userid = 3, Email = "stefan.icq.de", Password = "SchlimmerFinger420" });

        }
        // GET: api/<verifyController>
        [HttpGet]
        public List<verify> Get()

        {
            return LoginList;
        }

        // GET api/<verifyController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            UserIdValidatorService _test = new UserIdValidatorService();

            var erg = _test.ValidUser(id, LoginList);




            verify gefunden = new verify();
            foreach (verify forEachVariable in LoginList)
            {
                if (forEachVariable.Userid == id)
                {
                    gefunden = forEachVariable;
                }
            }

            if (gefunden.Userid == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(gefunden);
            }
        }

        // POST api/<verifyController>
        [HttpPost]
        public IActionResult Post([FromBody] verify LoginData)
        {
            var login = LoginList.Find(a => a.Email == LoginData.Email);

            if (login != null)
            {
                if (LoginData.Password == login.Password)
                {
                    return Ok("logged in");
                }
                else
                {
                    return Unauthorized();
                }

            }
            else
            {
                return Unauthorized();
            }
        }

        // PUT api/<verifyController>/5
        [HttpPut("{id}")]
        public verify Put(int id, [FromBody] verify value)
        {
            var newuser = LoginList.Where(l => l.Userid == id).FirstOrDefault();
            newuser.Email = value.Email;
            newuser.Password = value.Password;
            return newuser;
        }

        // DELETE api/<verifyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = LoginList.Where(l => l.Userid == id).FirstOrDefault();
            LoginList.Remove(user);
        }
    }
}
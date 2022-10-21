using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentifizierungController : ControllerBase
    {

        static List<CredentialsClass> LoginList;
       

        static AuthentifizierungController()
        {
            LoginList = new List<CredentialsClass>();
            LoginList.Add(new CredentialsClass() { Email = "michael@gmail.com", Password = "alligator13" });
            LoginList.Add(new CredentialsClass() { Email = "dorian@yahoo.com", Password = "hackeralptraum123" });
            LoginList.Add(new CredentialsClass() { Email = "stefan.icq.de", Password = "SchlimmerFinger420" });
            
        }

       

        // GET: api/<Authetifizierung>
        [HttpGet]
        public List<CredentialsClass> Get()
        {
            return LoginList;
        }

        // GET api/<Authetifizierung>/5
       // [HttpGet("{id}")]
        //public string Get(int id)
        //{
          //  return "value";
        //}

        // POST api/<Authetifizierung>
        [HttpPost]
        public IActionResult Post([FromBody] CredentialsClass LoginData)
        {
            var login = LoginList.Find(a => a.Email == LoginData.Email);

            if (login!= null)
            {
                if (LoginData.Password==login.Password)
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


        // PUT api/<Authetifizierung>/5
        [HttpPut("{id}")]
        public CredentialsClass Put(string id, [FromBody] CredentialsClass LoginData)
        {
            var newLoginEmail = LoginList.Where(l => l.Email == id).FirstOrDefault();
            newLoginEmail.Email = LoginData.Email;
            return newLoginEmail;

            var newLoginPass = LoginList.Where(l => l.Password == id).FirstOrDefault();
            newLoginPass.Password = LoginData.Password;
            return newLoginPass;
        }

        // DELETE api/<Authetifizierung>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var DataEmail = LoginList.Where((l) => l.Email == id).FirstOrDefault();
            LoginList.Remove(DataEmail);

            var DataPass = LoginList.Where((l) => l.Password == id).FirstOrDefault();
            LoginList.Remove(DataPass);
        }
    }
}

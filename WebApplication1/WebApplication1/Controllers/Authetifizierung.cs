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

        static Authetifizierung()
        {
            LoginList = new List<Authetifizierung>();
        }

        // GET: api/<Authetifizierung>
        [HttpGet]
        public List<Authetifizierung> Get()
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
        public IActionResult Post([FromBody] Authetifizierung credentials)
        {
            if (credentials == LoginList)
        }

        // PUT api/<Authetifizierung>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Authetifizierung>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

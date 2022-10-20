using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authetifizierung : ControllerBase
    {

        static List<Authetifizierung> LoginList;
        

        static Authetifizierung()
        {
            LoginList = new List<string>();
            LoginList.Add("michael@gmail.com", "alligator13");
            LoginList.Add("dorian@yahoo.com", "hackeralptraum123");
            LoginList.Add("stefan@icq.de", "SchlimmerFinger420");
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

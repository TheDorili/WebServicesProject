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
        public List<CredentialsClass> GetEmail()
        {
            return LoginList;
        }

        [HttpGet("{id}")]

       // public string Get(int id)
        //{
       //     return LoginList[id].Email;
       // }
        //Login wird überprüft ob es überhaupt da ist und ob das Passwort stimmt
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

        //neuen User Anlegen
        // PUT api/<Authetifizierung>/5
        [HttpPut("{id]")]
        public CredentialsClass Put(int id, [FromBody] CredentialsClass value, CredentialsClass? newData)
        {
            var newCreData = LoginList.Where(i => i.Userid == id).FirstOrDefault();
            newCreData.Email = value.Email;
            newCreData.Password = value.Password;
            return newCreData;
        }
     

        

        //bestehenden User löschen
        // DELETE api/<Authetifizierung>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var data = LoginList.Where(l => l.Email == id).FirstOrDefault();
            LoginList.Remove(data);
        }
    }
}

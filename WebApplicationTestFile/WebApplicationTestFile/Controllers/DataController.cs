using Microsoft.AspNetCore.Mvc;
using WebApplicationTestFile.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationTestFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        static List<Data> DataList;

        static DataController()
        {
            DataList = new List<Data>();
        }
        // GET: api/<DataController>
        [HttpGet]
        public List<Data> Get()
        {
            return DataList;
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Data gefunden = new Data();
            foreach (Data forEachVariable in DataList)
            {
                if(forEachVariable.storageId == id)
                {
                    gefunden = forEachVariable;
                }
            }
        if (gefunden.storageId == 0)
            {
                return NotFound();
            }
        else
            {
                return Ok(gefunden);
            }
        }

        // POST api/<DataController>
        [HttpPost]
        public IActionResult Post([FromBody] Data data)
        {
            if (data.name == string.Empty)
            {
                return BadRequest();
            }

            data.storageId = DataList.Count + 1;
            DataList.Add(data);

            return Ok(data);

        }

        // PUT api/<DataController>/5
        [HttpPut("{id}")]
        public Data Put(int id, [FromBody] Data value)
        {
            var data = DataList.Where(l => l.storageId == id).FirstOrDefault();
            data.name = value.name;
            return data;
        }

        // DELETE api/<DataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = DataList.Where(l => l.storageId == id).FirstOrDefault();
            DataList.Remove(data);
            
        }
    }
}

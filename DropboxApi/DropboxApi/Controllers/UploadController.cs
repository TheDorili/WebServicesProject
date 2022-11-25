using DropboxApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DropboxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UploadContext _context;

        public UploadController(UploadContext context)
        {
            _context = context;
        }
        // GET: api/<UploadController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadItem>>> GetUploadItems()
        {
            return await _context.UploadItems.ToListAsync();
        }
        // GET api/<UploadController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UploadItem>> GetUploadItem(long id)
        {
            var uploadItem = await _context.UploadItems.FindAsync(id);

            if (uploadItem == null)
            {
                return NotFound();
            }

            return uploadItem;
        }

        // POST api/<UploadController>
        [HttpPost]
        public async Task<IActionResult> PutUploadItem(long id, UploadItem uploadItem)
        {
            if (id != uploadItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(uploadItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!UploadItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT api/<UploadController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UploadItem>> PostUploadItem(UploadItem uploadItem)
        {
            _context.UploadItems.Add(uploadItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUploadItem", new { id = uploadItem.Id }, uploadItem);
        }
        // DELETE api/<UploadController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUploadItem(long id)
        {
            var uploadItem = await _context.UploadItems.FindAsync(id);
            if (uploadItem == null)
            {
                return NotFound();
            }

            _context.UploadItems.Remove(uploadItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UploadItemExists(long id)
        {
            return _context.UploadItems.Any(e => e.Id == id);
        }
    }
}

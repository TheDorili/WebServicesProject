using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DropboxApi.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

        // GET: api/FileSearch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadItem>>> GetUploadItems()
        {
            return await _context.UploadItems.ToListAsync();
        }

        // GET: api/UploadItems/5
        [HttpGet("LookUpForData")]
        public async Task<ActionResult<UploadItem>> GetUploadItem(long id)
        {
            var uploadItem = await _context.UploadItems.FindAsync(id);

            if (uploadItem == null)
            {
                return NotFound();
            }

            return uploadItem;
        }

        // PUT: api/UploadItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("CreateData")]
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

        // POST: api/UploadItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UploadItem>> PostUploadItem(UploadItem uploadItem)
        {
            _context.UploadItems.Add(uploadItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUploadItem", new { id = uploadItem.Id }, uploadItem);
        }

        // DELETE: api/UploadItems/5
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

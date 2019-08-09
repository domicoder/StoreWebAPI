using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;
using PERSISTENCE;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceProductDetailController : ControllerBase
    {
        private readonly StoreContext _context;

        public InvoiceProductDetailController(StoreContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceProductDetail
        [HttpGet]
        public IEnumerable<InvoiceProductDetail> GetInvoiceProductDetails()
        {
            return _context.InvoiceProductDetails;
        }

        // GET: api/InvoiceProductDetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceProductDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoiceProductDetail = await _context.InvoiceProductDetails.FindAsync(id);

            if (invoiceProductDetail == null)
            {
                return NotFound();
            }

            return Ok(invoiceProductDetail);
        }

        // PUT: api/InvoiceProductDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceProductDetail([FromRoute] int id, [FromBody] InvoiceProductDetail invoiceProductDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoiceProductDetail.InvoiceProductDetailId)
            {
                return BadRequest();
            }

            _context.Entry(invoiceProductDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceProductDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(invoiceProductDetail);
        }

        // POST: api/InvoiceProductDetail
        [HttpPost]
        public async Task<IActionResult> PostInvoiceProductDetail([FromBody] InvoiceProductDetail invoiceProductDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InvoiceProductDetails.Add(invoiceProductDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceProductDetail", new { id = invoiceProductDetail.InvoiceProductDetailId }, invoiceProductDetail);
        }

        // DELETE: api/InvoiceProductDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceProductDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoiceProductDetail = await _context.InvoiceProductDetails.FindAsync(id);
            if (invoiceProductDetail == null)
            {
                return NotFound();
            }

            _context.InvoiceProductDetails.Remove(invoiceProductDetail);
            await _context.SaveChangesAsync();

            return Ok(invoiceProductDetail);
        }

        private bool InvoiceProductDetailExists(int id)
        {
            return _context.InvoiceProductDetails.Any(e => e.InvoiceProductDetailId == id);
        }
    }
}
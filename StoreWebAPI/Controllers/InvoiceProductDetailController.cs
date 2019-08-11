using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;
using PERSISTENCE;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.InvoiceProductDetails.Include(i => i.Invoice).Include(p => p.Product);
        }

        // GET: api/InvoiceProductDetail/5
        [HttpGet("api/InvoiceProductDetail/customer/{CustomerId}/invoice/{InvoiceId}/product/{ProductId}")]
        public IActionResult GetInvoiceProductDetail([FromRoute] int CustomerId, int InvoiceId, int ProductId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoiceProductDetail = _context.Products.Where(x => x.ProductId == ProductId)
                                                        .Include(x => x.Invoices)
                                                        .ThenInclude(y => y.Invoice).Include(i => i.Category);

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

            if (id != invoiceProductDetail.InvoiceId)
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InvoiceProductDetailExists(invoiceProductDetail.InvoiceId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInvoiceProductDetail", new { id = invoiceProductDetail.InvoiceId }, invoiceProductDetail);
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
            return _context.InvoiceProductDetails.Any(e => e.InvoiceId == id);
        }
    }
}
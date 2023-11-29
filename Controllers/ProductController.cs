using listing_process.Web.Models;
using listing_process.Web.Models.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace listing_process.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var value = await _context.Product.ToListAsync();

            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateList(Product create)
        {
            await _context.AddAsync(create);
            _context.SaveChanges();
            return Ok("Kayıt Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateList(Product update)
        {
            _context.Product.Update(update);
            _context.SaveChanges();
            return Ok("Güncelleme başarıyla kayıt edilmiştir");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteList(int id)
        {
            var delete = await _context.Product.FindAsync(id);
           _context.Product.Remove(delete);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
    }
}

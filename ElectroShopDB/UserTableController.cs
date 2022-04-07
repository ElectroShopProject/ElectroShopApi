using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectroShopApi.Tables;

namespace ElectroShopApi
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class UserTableController : ControllerBase
    //{
    //    private readonly TaxRateTableContext _context;

    //    public UserTableController(TaxRateTableContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/UserTable
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<UserTable>>> GetUserTable()
    //    {
    //        return await _context.UserTable.ToListAsync();
    //    }

    //    // GET: api/UserTable/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<UserTable>> GetUserTable(int id)
    //    {
    //        var userTable = await _context.UserTable.FindAsync(id);

    //        if (userTable == null)
    //        {
    //            return NotFound();
    //        }

    //        return userTable;
    //    }

    //    // PUT: api/UserTable/5
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutUserTable(int id, UserTable userTable)
    //    {
    //        if (id != userTable.Id)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(userTable).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!UserTableExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/UserTable
    //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //    [HttpPost]
    //    public async Task<ActionResult<UserTable>> PostUserTable(UserTable userTable)
    //    {
    //        _context.UserTable.Add(userTable);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetUserTable", new { id = userTable.Id }, userTable);
    //    }

    //    // DELETE: api/UserTable/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteUserTable(int id)
    //    {
    //        var userTable = await _context.UserTable.FindAsync(id);
    //        if (userTable == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.UserTable.Remove(userTable);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool UserTableExists(int id)
    //    {
    //        return _context.UserTable.Any(e => e.Id == id);
    //    }
    //}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Models;
using System.Collections;

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly challengeContext _context;

        public UsersController(challengeContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;


        }

        // GET: api/Users/5/summary
        [HttpGet("{id}/summary")]
        public async Task<IEnumerable> GetSummary(int id)
        {
            var goals = await _context.Goals.Where(b => b.Userid == id).Join(_context.Goaltransactionfundings, Goals => Goals.Id, Goaltransactionfundings => Goaltransactionfundings.Goalid, (Goals, Goaltransactionfundings) => new
            {
                Goals,
                Goaltransactionfundings
            }).Join(_context.Fundingsharevalues, Goals => Goals.Goaltransactionfundings.Fundingid, Fundingsharevalues => Fundingsharevalues.Fundingid, (Goals, Fundingsharevalues) => new
            {
                Fundingsharevalues,
                Goals
            }).Join(_context.Currencyindicators, Goals => Goals.Goals.Goals.Currencyid, Currencyindicators => Currencyindicators.Id, (Goals, Currencyindicators) => new
            {
                Currencyindicators,
                Goals
            })
            .Select(campos => new
            {
                balance= campos.Currencyindicators.Value * campos.Goals.Fundingsharevalues.Value * campos.Goals.Goals.Goaltransactionfundings.Quotas,
                
                
                //fechareal = fecha.OrderByDescending(t => t.Date).FirstOrDefaultAsync()
            })
            .ToListAsync();

            var ls = goals.Max(x => x.balance);


            return goals;


        }


        // GET: api/Users/5/goals
        [HttpGet("{id}/goals")]
        public async Task<IEnumerable> GetGoals(int id)
        {
            var goals = await _context.Goals.Where(b => b.Userid == id).Join(_context.Portfolios, Goals => Goals.Portfolioid, Portfolios => Portfolios.Id, (Goals, Portfolios) => new
            {
                Goals,
                Portfolios
            }).Join(_context.Financialentities, Goals => Goals.Goals.Financialentityid, Financialentity => Financialentity.Id, (Goals, Financialentity) => new
            {
                Financialentity,
                Goals
            }).Select(campos => new
            {
                campos.Goals.Goals.Title,
                campos.Goals.Goals.Years,
                campos.Goals.Goals.Initialinvestment,
                campos.Goals.Goals.Monthlycontribution,
                campos.Goals.Goals.Targetamount,
                campos.Goals.Goals.Financialentityid,
                entidad_financiera = campos.Financialentity.Title,
                campos.Goals.Goals.Portfolioid,
                portafolio = campos.Goals.Portfolios,
                campos.Goals.Goals.Created,

            })
            .ToListAsync();


            return goals;


        }


        // GET: api/Users/5/goals/5
        [HttpGet("{id}/goals/{goalid}")]
        public async Task<IEnumerable> GetGoalsById(int id, int goalid)
        {
            var goals = await _context.Goals.Where(b => b.Userid == id && b.Id == goalid).Join(_context.Portfolios, Goals => Goals.Portfolioid, Portfolios => Portfolios.Id, (Goals, Portfolios) => new
            {
                Goals,
                Portfolios
            }).Join(_context.Financialentities, Goals => Goals.Goals.Financialentityid, Financialentity => Financialentity.Id, (Goals, Financialentity) => new
            {
                Financialentity,
                Goals
            }).Join(_context.Goalcategories, Goals => Goals.Goals.Goals.Goalcategoryid, Goalcategory => Goalcategory.Id, (Goals, Goalcategory) => new
            {
                Goalcategory,
                Goals
            }).Join(_context.Goaltransactionfundings, Goals => Goals.Goals.Goals.Goals.Id, Goaltransactionfundings => Goaltransactionfundings.Goalid, (Goals, Goaltransactionfundings) => new
            {
                Goaltransactionfundings,
                Goals
            }).Select(campos => new
            {
                campos.Goals.Goals.Goals.Goals.Title,
                campos.Goals.Goals.Goals.Goals.Years,
                campos.Goals.Goals.Goals.Goals.Initialinvestment,
                campos.Goals.Goals.Goals.Goals.Monthlycontribution,
                campos.Goals.Goals.Goals.Goals.Targetamount,
                campos.Goals.Goalcategory,
                campos.Goals.Goals.Goals.Goals.Financialentityid,
                entidad_financiera = campos.Goals.Goals.Financialentity.Title,
                campos.Goals.Goals.Goals.Goals.Portfolioid,
                portafolio = campos.Goals.Goals.Goals.Portfolios,
                campos.Goaltransactionfundings.Amount,
                campos.Goaltransactionfundings.Percentage
            })
            .ToListAsync();


            return goals;


        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productManagementAPI.Models;
using productManagementAPI.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace productManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
    /*    [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/
        public readonly IUnitOfWorkRepository _db;
        public UsersController(IUnitOfWorkRepository db)
        {
          
            _db = db;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            IEnumerable<User> UserList;
           // try
           // {
                UserList = _db.UserRep.GetAll(includeProperties: "UserType");
                return UserList.ToList();
                // return await UserList;
            //}
           // catch (Exception ex)
           // {
            //    return null;
              //  return RedirectToAction("ErrorIndex", "Error", new { area = "Customer" });
           // }


        }

        // GET api/<UsersController>/5
   /*     [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<UsersController>
       // [HttpPost]
      /*  public void Post([FromBody] string value)
        {
        }*/
 /*       public async Task<ActionResult<User>> PostUser(User users)
        {
            if (_db.UserRep == null)
            {
                return Problem("Entity set 'DatabaseContext.Products'  is null.");
            }
            _db.UserRep.Add(users);
             _db.Save();

            return CreatedAtAction("GetProducts", new { id = users.Id }, users);
        }*/

        // PUT api/<UsersController>/5
    /*    [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_db.UserRep == null)
            {
                return NotFound();
            }
            //var user = _db.UserRep.GetFirstOrDefault(x => x.Id == id);
            var user= _db.UserRep.GetFirstOrDefault(x => x.Id == id,includeProperties: "UserType");
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet("{email},{password}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email,string password)
        {
            if (_db.UserRep == null)
            {
                return NotFound();
            }
            //var user = _db.UserRep.GetFirstOrDefault(x => x.Id == id);
            var user = _db.UserRep.GetFirstOrDefault(x => x.Email == email && x.Password==password, includeProperties: "UserType");
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }

           // return user;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _db.UserRep.Update(user);
           
            // _context.Entry(products).State = EntityState.Modified;

            try
            {
                _db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (UserExists(id)==null)
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_db.UserRep == null)
            {
                return Problem("Entity set 'DatabaseContext.Products'  is null.");
            }
           var u= _db.UserRep.GetFirstOrDefault(users => users.Email == user.Email);
            if(u == null) {
                _db.UserRep.Add(user);
                _db.Save();
            }
            else
            {
                return BadRequest();
            }
            

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_db.UserRep == null)
            {
                return NotFound();
            }
            var user =  _db.UserRep.GetFirstOrDefault(u=>u.Id==id);
            if (user == null)
            {
                return NotFound();
            }

            _db.UserRep.Remove(user);
            _db.Save();

            return NoContent();
        }

        private string UserExists(int id)
        {
            return _db.UserRep?.GetFirstOrDefault(e => e.Id == id).ToString();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        
        private readonly DbApiContext _dbApiContext;
        public MemberController(DbApiContext dbContext)
        {
            _dbApiContext = dbContext;
        }

        [HttpPost]
        public void Post([FromBody] Member member)
        {
            _dbApiContext.Add(member);
            _dbApiContext.SaveChanges();
        }

        [HttpPut]
        public void Put(int id, Member member)
        {
            var m = _dbApiContext.Members.FirstOrDefault(x => x.Id == member.Id);
            if (m == null)
            {
                return;
            }

            m.Name = member.Name;
            m.Age = member.Age;

            _dbApiContext.SaveChanges();
        }

        [HttpGet]
        public void GetAll()
        {
            var x = _dbApiContext.Members;
            _dbApiContext.Dispose();
        }

        [HttpGet("{id}")]
        public void GeById(int id)
        {
            //DbApiContext dbApiContext = new(); 
            var x = _dbApiContext.Members.Find(id);
            _dbApiContext.Dispose();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //DbApiContext dbApiContext = new(); 
            var x = _dbApiContext.Members.Find(id);
            if (x != null)
            {
                _dbApiContext.Remove(x);
                _dbApiContext.SaveChanges();
            }
            
            _dbApiContext.Dispose();
        }

    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;
using TraversalApiProect.DAL.Context;
using TraversalApiProect.DAL.Entities;

namespace TraversalApiProect.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values= context.Visitors.Find(id);
                if(values == null)
                {
                    return NotFound();
                }
                else
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        { 
            using(var context = new VisitorContext())
            {
                var values =context.Visitors.Find(id);
                if(values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Visitors.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut()]
        public IActionResult VisitorUpdate(Visitor visitor) 
        { 
            using (var context = new VisitorContext())
            {
                var values= context.Visitors.Find(visitor.VisitorID);
                if(values== null)
                {
                    return NotFound();
                }
                else
                {
                    values.City = visitor.City;
                    values.VisitorName = visitor.VisitorName;
                    values.VisitorSurName = visitor.VisitorSurName;
                    values.Country = visitor.Country;
                    values.Mail = visitor.Mail;
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Authorization;
using ApplicationService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmigosController : ControllerBase
    {
        private AmigoServices Services { get; set; }

        public AmigosController(AmigoServices services)
        {
            this.Services = services;
        }

        // GET: api/Amigos
        [HttpGet]
        public IEnumerable<Amigo> Get()
        {
            return Services.GetAll();
        }

        // GET: api/Amigos/5
        [HttpGet("{id}")]
        public Amigo Get(Guid id)
        {
            return Services.GetAmigoById(id);
        }

        // PUT: api/Amigos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Amigo model)
        {
            this.Services.Update(id, model);
        }

        // POST: api/Amigos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void Post([FromBody] Amigo model)
        {
            try
            {
                this.Services.Save(model);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        // DELETE: api/Amigos/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.Services.Delete(id);
        }
    }
}

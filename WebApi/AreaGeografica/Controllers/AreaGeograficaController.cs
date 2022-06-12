using AreaGeografica.Models;
using AreaGeografica.Persistance.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using AreaGeografica.Models.Communication;


namespace AreaGeografica.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AreaGeograficaController : ControllerBase
    {
        private readonly ILogger<AreaGeograficaController> _logger;
 
        private DatabaseCxt _context;
        private IOptions<AppSettings> _setting;
        public AreaGeograficaController(ILogger<AreaGeograficaController> logger,
            DatabaseCxt ctx
        )
        {
            _logger = logger;
            _context = ctx;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> Get()
        {
            var students = await _context.Cities.ToListAsync();
            return Ok(students);
        }


        [HttpGet("Title")]
        public async Task<IActionResult> GetByCities(string Title)
        {
            Country c = null;
            using (_context)
            {
                c = await _context.Country.Where(c => c.nameCountry == Title).FirstAsync();
                var data = _context.Country
               .Include(s => s.cities)
               .First(c => c.id == c.id);

                return Ok(data);
            }

        }



        [HttpPost]
        public IActionResult Post([FromBody] SaveCitiesResources value)
        {
            Cities result = null;
            try
            {
                try
                {
                    result = _context.Cities.Add(value.toCities()).Entity;
                    _context.SaveChanges();
                    return Ok(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] SaveCitiesResources payload)
        {
            var std = await _context.Cities.FindAsync(id);
            Cities stdRsrc = payload.toCities();
            std.cities = stdRsrc.cities;
            std.numeroAbitanti = stdRsrc.numeroAbitanti;
            var result = _context.Cities.Update(std).Entity;
            try
            {
                var res = await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpDelete("{cities}")]
        public async Task Delete(int id)
        {
            Cities s = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(s);
            await _context.SaveChangesAsync();
        }
    }
}

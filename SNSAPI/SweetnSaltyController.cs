using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using SweetnSaltyBusiness;
using SweetnSaltyModels;
using System;

namespace SweetnSaltyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweetnSaltyController : Controller
    {
        private readonly ISweetnSaltyBusinessClass _business;
        //constructor
        public SweetnSaltyController(ISweetnSaltyBusinessClass ISweetnSaltyBusinessClass)
        {
            _business = ISweetnSaltyBusinessClass;
        }


        [HttpPost]
        [Route("postaflavor/{flavor}")]
        public async Task<ActionResult<Flavor>> PostFlavor(string flavor)
        {
            Flavor f1 = await _business.PostFlavor(flavor);
            if(f1 != null)
            
                return Created($"http://5001/sweetnsalty/postaflavor/{f1.FlavorId}", f1);
            
            else  return BadRequest(); 
        }

        [HttpPost]
        [Route("postaperson/{fname}/{lname}")]
        public async Task<ActionResult<Person>> PostPerson(string fname, string lname)
        {
            Person person = await _business.PostPerson(fname, lname);
            if (person != null)
            {
                return Created($"http://5001/sweetnsalty/postaperson/{person.FirstName}/{person.LastName}", person);
            }
            else { return BadRequest(); }
        }

        [HttpGet]
        [Route("getaperson/{fname}/{lname}")]
        public async Task<ActionResult<Person>> GetPerson(string fname, string lname)
        {
           Person person = await _business.GetPerson(fname, lname);
            if(person != null)
            
                return Ok(person);
            
            else  return NotFound();
        }

        [HttpGet]
        [Route("getapersonandflavors/{id}")]
        public async Task<ActionResult<Person>> GetPersonAndFlavors(int id)
        {
            Person person = await _business.GetPersonAndFlavors(id);
            if(person != null)
            
                return Ok(person);
            
            else {  return NotFound(); }
        }

        [HttpGet]
        [Route("getlistofflavors")]
        public async Task<ActionResult<List<Flavor>>> GetAllFlavors()
        {
            List<Flavor> f = await _business.GetAllFlavors();
            if (f.Count != 0)
            {
                return Ok(f);
            }
            else { return NotFound(); }
        }


    }
}

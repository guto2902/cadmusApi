using cadmus.Models;
using cadmus.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cadmus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {

                var itens = _service.GetAllItems();
                
                return Ok(itens);
                

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var item = _service.GetById(id);

                return Ok(item);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post(Cliente cl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Add(cl);

                    return Created("~/Cliente/" + cl.Id.ToString(), cl);
                    
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public ActionResult Put(Cliente cl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingItem = _service.GetById(cl.Id);

                    if (existingItem == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _service.Update(cl);


                        return NoContent();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var existingItem = _service.GetById(id);

                if (existingItem == null)
                {
                    return NotFound();
                }
                else
                {
                    _service.Remove(id);


                    return NoContent();
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }



        // GET: api/<ProdutoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {

                var itens= _service.GetAllItems();
               

                return Ok(itens);
               

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<ProdutoController>/5
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

        // POST api/<ProdutoController>
        [HttpPost]
        public ActionResult Post(Produto pr)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _service.Add(pr);

                    return Created("~/Produto/" + pr.Id.ToString(), pr);
                    
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

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public ActionResult Put(Produto pr)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var existingItem = _service.GetById(pr.Id);

                    if (existingItem == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _service.Update(pr);


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

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {

                var existingItem = _service.GetById(id);

                if (existingItem==null)
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

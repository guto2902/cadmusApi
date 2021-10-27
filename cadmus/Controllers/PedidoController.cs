using cadmus.Models;
using cadmus.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace cadmus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoService _service;

        public PedidoController(IPedidoService service)
        {
            _service = service;
        }



        // GET: api/<PedidoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var itens = _service.GetAllItems();

                return Ok(itens);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<PedidoController>/5
        [HttpGet("{numero}")]
        public ActionResult Get(int numero)
        {
            try
            {
                var item= _service.GetById(numero);

                
                return Ok(item);
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<PedidoController>
        [HttpPost]
        public ActionResult Post(Pedido pd)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _service.Add(pd);
                    
                    return Created("~/Pedido/" + pd.Numero.ToString(), pd);
                   
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

        // PUT api/<PedidoController>/5
        [HttpPut]
        public ActionResult Put(Pedido pd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingItem = _service.GetById(pd.Numero);

                    if (existingItem == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _service.Update(pd);


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

        // DELETE api/<PedidoController>/5
        [HttpDelete("{numero}")]
        public ActionResult Delete(int numero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingItem = _service.GetById(numero);

                    if (existingItem == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _service.Remove(numero);


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
    }
}

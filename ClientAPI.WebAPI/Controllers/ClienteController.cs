using ClientApi.Infra.Data.Repository;
using ClientAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientAPI.Service.Validators;
using FluentValidation;

namespace ClientAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteRepository _clienteRepository;
        private ClienteValidator _clientValidator;

        public ClienteController(ClienteRepository clienteRepository, ClienteValidator clientValidator)
        {
            _clienteRepository = clienteRepository;
            _clientValidator = clientValidator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                _clientValidator.CustomValidate(cliente);
                _clienteRepository.Insert(cliente);

                return Ok(cliente.id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                _clientValidator.CustomValidate(cliente);
                _clienteRepository.Update(cliente);

                return Ok(cliente.id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clienteRepository.Delete(id);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_clienteRepository.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clienteRepository.List());
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

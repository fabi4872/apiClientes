using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAbmClientes.Models;

namespace ApiAbmClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesContext _context;


        public ClientesController(ClientesContext context)
        {
            _context = context;
        }


        // GET: api/Clientes/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            return await _context.Cliente.ToListAsync();
        }


        // GET: api/Clientes/Get?id=5
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }


        // PUT: api/Clientes
        [HttpPut]
        public async Task<ActionResult<Cliente>> PutCliente(Cliente cliente)
        {
            try
            {
                if (ClienteExists(cliente.Id))
                {
                    _context.Entry(cliente).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return cliente;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NotFound();
        }


        // POST: api/Clientes/Insert
        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var clienteExistente = await _context.Cliente.Where(c => c.Email == cliente.Email).FirstOrDefaultAsync();

            if(clienteExistente != null)
                return BadRequest("El correo electrónico ingresdado ya existe");
                               
            try
            {
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteExists(cliente.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }


        // GET: api/Clientes/Search?nombre=Fabian
        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<Cliente>> SearchCliente(string nombre)
        {
            var cliente = await _context.Cliente.Where(cliente => cliente.Nombres == nombre).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }


        //Sugerencia: Agregar endpoint para retornar una lista de clientes cuya cadena pasada por parámetro sea subcadena del nombre
        // GET: api/Clientes/SearchAll?nombre=abi
        [HttpGet]
        [Route("SearchAll")]
        public async Task<ActionResult<IEnumerable<Cliente>>> SearchAllClientes(string nombre)
        {
            return await _context.Cliente.Where(cliente => cliente.Nombres.Contains(nombre)).ToListAsync();
        }


        //Sugerencia: Agregar delete
        // DELETE: api/Clientes/Delete?id=5
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }


        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}

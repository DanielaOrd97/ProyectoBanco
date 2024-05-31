using ApiBanco.Models.DTO;
using ApiBanco.Models.Entities;
using ApiBanco.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IRepository<Usuarios> Repository { get; }

        public UsuariosController(IRepository<Usuarios> repository)
        {
            this.Repository = repository;
        }

        private OperadorDTO MapToDto(Usuarios usuarios)
        {
            return new OperadorDTO
            {
                Id = usuarios.Id,
                NombreUsuario = usuarios.NombreUsuario,
                Contraseña = usuarios.Contraseña,
                Nombre = usuarios.Nombre,
                EsOperador = (bool)usuarios.EsOperador,
                FechaDeRegistro = (DateTime)usuarios.FechaDeRegistro,
                IdCaja = usuarios.IdCaja
            };
        }

        private Usuarios MapToEntity(OperadorDTO dto, Usuarios? original = null)
        {
            if (original == null)
            {
                original = new Usuarios();
            }

            return new Usuarios
            {
                Id = dto.Id ?? 0,
                NombreUsuario = dto.NombreUsuario,
                Contraseña = dto.Contraseña,
                Nombre = dto.Nombre,
                EsAdmin = false,
                EsOperador = true,
                FechaDeRegistro = DateTime.Now,
                IdCaja = dto.IdCaja
            };
        }

        /// <summary>
        /// MOSTRAR SOLO AQUELLOS QUE SON OPERADORES.
        /// </summary>

        [HttpGet("Operadores")]
        public IActionResult GetAll()
        {
            var operadores = Repository.GetAll()
                .Where(x => x.EsOperador == true)
                .Select(x => MapToDto(x));

            return Ok(operadores);
        }

        ///<summary>
        ///BUSCAR UN OPERADOR EN ESPECIFICO
        /// </summary>
        [HttpGet("Operador/{id}")]
        public IActionResult GetOperador(int id)
        {
            var operador = Repository.Get(id);

            if (operador == null)
            {
                return NotFound();
            }
            return Ok(MapToDto(operador));
        }

        ///<summary>
        ///AGREGAR UN OPERADOR.
        /// </summary>
        [HttpPost("AgregarOperador")]
        public IActionResult PostOperador(OperadorDTO dto)
        {
            if (dto != null)
            {
                var operador = MapToEntity(dto);
                Repository.Insert(operador);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        ///<summary>
        ///EDITAR UN OPERADOR
        /// </summary>
        /// 
        [HttpPut("EditarOperador")]
        public IActionResult PutOperador(OperadorDTO dto)
        {
            if (dto != null)
            {
                var operador = Repository.Get(dto.Id ?? 0);

                if (operador != null)
                {

                    operador.NombreUsuario = dto.Nombre;
                    operador.Contraseña = dto.Contraseña;
                    operador.Nombre = dto.Nombre;
                    operador.EsOperador = operador.EsOperador;
                    operador.FechaDeRegistro = operador.FechaDeRegistro;
                    
                    if(dto.IdCaja == null)
                    {
                        operador.IdCaja = operador.IdCaja;
                    }
                    else
                    {
                        operador.IdCaja = dto.IdCaja;
                    }

                    Repository.Update(operador);
                    return Ok();
                }
            }
            return NotFound();
        }

        /// <summary>
        /// ELIMINAR UN OPERADOR
        /// </summary>

        [HttpDelete("EliminarOperador/{id}")]
        public IActionResult DeleteOperador(int id)
        {
            var operador = Repository.Get(id);

            if (operador != null)
            {
                Repository.Delete(operador);
                return Ok();
            }

            return NotFound();
        }

    }
}

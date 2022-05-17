using Api_Up_Base.Database;
using Api_Up_Base.Dtos;
using Api_Up_Base.Models;
using Api_Up_Base.Views;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api_Up_Base.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase {

        private readonly ApiUpBaseContext _context;
        private IMapper _mapper;

        public UsuarioController(ApiUpBaseContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] UsuarioDTO usuarioDTO) {

            UsuarioModel usuario = _mapper.Map<UsuarioModel>(usuarioDTO);

            if (usuario.Senha == usuario.ConfirmarSenha) {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return CreatedAtAction(nameof(ListarUsuarioPorId), new { Id = usuario.Id }, usuario);
            }

            return BadRequest();
        }

        [HttpGet]
        public IEnumerable<UsuarioModel> ListarUsuarios() {

            return _context.Usuario;
        }

        [HttpGet("{id}")]
        public IActionResult ListarUsuarioPorId(int id) {

            UsuarioModel usuario = _context.Usuario.FirstOrDefault(usuario => usuario.Id == id);
            if (usuario != null) {

                UsuarioViews usuarioViews = _mapper.Map<UsuarioViews>(usuario);
                return Ok(usuarioViews);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AlterarUsuario(int id, [FromBody] AlterarUsuarioDTO usuarioDTO) {

            UsuarioModel usuario = _context.Usuario.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null) {
                return NotFound();
            }

            _mapper.Map(usuarioDTO, usuario);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id) {

            UsuarioModel usuario = _context.Usuario.FirstOrDefault(usuario => usuario.Id == id);

            if (usuario == null) {
                return NotFound();
            }

            _context.Remove(usuario);
            _context.SaveChanges();
            return NoContent();

        }
    }
}

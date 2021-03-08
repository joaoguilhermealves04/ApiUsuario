using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDomain.Entities;
using APIRepository.Contracts;
using APIRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        [HttpPost]
        public IActionResult Post(UsuarioModel model)
        {
            try
            {
                var usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Senhar = model.Senhar;

                var emailExiste = _usuarioRepository.ObterPorEmail(model.Email);
                if (emailExiste != null)
                {
                    var resultado = new StatusResultado("E-mail já existente");

                    return StatusCode(404, resultado);
                }

                _usuarioRepository.Inserir(usuario);

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioLoginModel usuario)
        {
            try
            {
                var usuarioExistente = _usuarioRepository.Login(usuario.Email, usuario.Senha);
                if (usuarioExistente != null)
                {
                    return Ok(usuarioExistente);
                }

                var resultado = new StatusResultado("Usuário e/ou senha inválidos");

                return StatusCode(404,  resultado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(AlteracaoUsuarioModel model)
        {
            try
            {
                var usuario = _usuarioRepository.ObterporId(model.Id);
                usuario.Nome = model.Nome;
                usuario.Senhar = model.Senha;
                usuario.DataAlteracao = DateTime.Now;

                _usuarioRepository.Alterar(usuario);

                var resultado = new StatusResultado("Alteração feita com Sucesso!");
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var usuario = _usuarioRepository.ObterporId(id);

                _usuarioRepository.Excluir(usuario);

                var resultado = new StatusResultado("Excluido Com Sucesso!");
                return Ok(resultado);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var usuarios = _usuarioRepository.ObterTodos();

                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("ObterPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                _usuarioRepository.ObterporId(id);

                return Ok(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

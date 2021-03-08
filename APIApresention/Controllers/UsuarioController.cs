using APIApresention.Models;
using APIDomain.Entities;
using APIRepository.Contracts;
using APIRepository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApresention.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
    

        [HttpPost]
        public IActionResult Post(UsuarioModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();

                var usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Senhar = model.Senhar;

                
                usuarioRepository.Inserir(usuario);
                return Ok("Cadastrado Com sucesso!");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(AlteracaoUsuarioModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();

                var usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Senhar = model.Senhar;

                usuarioRepository.Alterar(usuario);

                return Ok("Alteração feita com Sucesso!");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();

                var usuario = new Usuario();

                usuario.Id = id;

                usuarioRepository.Excluir(id);

                return Ok("Excluido Com Sucesso!");

            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ObterporNome/{nome}")]
        public IActionResult ObterporNome(string Nome)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();

                var usuario = new Usuario();

                usuarioRepository.ObterporNome(Nome);

                return Ok(Nome);


            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ObterPorEmail/{email}")]
        public IActionResult ObterPorEmail(string email)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();

                var usuario = new Usuario();

                usuarioRepository.ObterPorEmail(email);

                return Ok(email);


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
                var usuarioRepository = new UsuarioRepository();

                usuarioRepository.ObterTodos();




               return Ok("Lista ");
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
                var usuarioRepository = new UsuarioRepository();

                var usuario = new Usuario();

               usuarioRepository.ObterporId(id);

               return Ok(id);


           }
            catch (Exception e)
           {
                return StatusCode(500, e.Message);
            }
        }

    }
}

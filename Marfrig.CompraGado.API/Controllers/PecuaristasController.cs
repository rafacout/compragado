using AutoMapper;
using Marfrig.CompraGado.API.ViewModels;
using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Marfrig.CompraGado.API.Controllers
{
    public class PecuaristasController : ApiController
    {
        private readonly IPecuaristaApplication _pecuaristaApplication;

        public PecuaristasController(IPecuaristaApplication pecuaristaApplication)
        {
            _pecuaristaApplication = pecuaristaApplication;
        }


        public IHttpActionResult Get()
        {
            var animais = Mapper.Map<IEnumerable<Pecuarista>, IEnumerable<PecuaristaViewModel>>(_pecuaristaApplication.GetAll());

            return Ok(animais);
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var pecuarista = _pecuaristaApplication.GetById(id);

                if (pecuarista == null)
                {
                    return BadRequest("Pecuarista não encontrado");
                }

                var pecuaristaViewModel = Mapper.Map<Pecuarista, PecuaristaViewModel>(pecuarista);

                return Ok(pecuaristaViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody]PecuaristaViewModel pecuarista)
        {
            try
            {
                if (pecuarista == null)
                {
                    return BadRequest("Pecuarista não pode ser vazio");
                }

                var pecuaristaViewModel = Mapper.Map<PecuaristaViewModel, Pecuarista>(pecuarista);

                _pecuaristaApplication.Add(pecuaristaViewModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(int id, [FromBody]PecuaristaViewModel pecuarista)
        {
            try
            {
                if (pecuarista == null)
                {
                    return BadRequest("Pecuarista não pode ser vazio");
                }

                var pecuaristaViewModel = Mapper.Map<PecuaristaViewModel, Pecuarista>(pecuarista);

                _pecuaristaApplication.Update(pecuaristaViewModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var pecuarista = _pecuaristaApplication.GetById(id);

                if (pecuarista == null)
                {
                    return BadRequest("Pecuarista não encontrado");
                }

                _pecuaristaApplication.Remove(pecuarista);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using AutoMapper;
using Marfrig.CompraGado.API.ViewModels;
using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Marfrig.CompraGado.API.Controllers
{
    public class CompraGadosController : ApiController
    {
        private readonly ICompraGadoApplication _compraGadoApplication;

        public CompraGadosController(ICompraGadoApplication compraGadoApplication)
        {
            _compraGadoApplication = compraGadoApplication;
        }


        public IHttpActionResult Get([FromUri]FiltroCompraGadoViewModel filtros)
        {
            var filtersDomain = Mapper.Map<FiltroCompraGadoViewModel, FiltroCompraGado>(filtros);

            var compraGadosDomain = _compraGadoApplication.GetByFilter(filtersDomain);

            var compraGados = Mapper.Map<IEnumerable<Domain.Entities.CompraGado>, IEnumerable<CompraGadoViewModel>>(compraGadosDomain);

            return Ok(compraGados);
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var compraGado = _compraGadoApplication.GetById(id);

                if (compraGado == null)
                {
                    return BadRequest("Compra de Gado não encontrado");
                }

                var compraGadoViewModel = Mapper.Map<Domain.Entities.CompraGado, CompraGadoViewModel>(compraGado);

                return Ok(compraGadoViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody]CompraGadoViewModel compraGado)
        {
            try
            {
                if (compraGado == null)
                {
                    return BadRequest("Compra de Gado não pode ser vazio");
                }

                var compraGadoViewModel = Mapper.Map<CompraGadoViewModel, Domain.Entities.CompraGado>(compraGado);

                _compraGadoApplication.Add(compraGadoViewModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody]CompraGadoViewModel compraGado)
        {
            try
            {
                if (compraGado == null)
                {
                    return BadRequest("Compra de Gado não pode ser vazio");
                }

                var compraGadoViewModel = Mapper.Map<CompraGadoViewModel, Domain.Entities.CompraGado>(compraGado);

                _compraGadoApplication.Update(compraGadoViewModel);

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
                var compraGado = _compraGadoApplication.GetById(id);

                if (compraGado == null)
                {
                    return BadRequest("Compra de Gado não encontrado");
                }

                _compraGadoApplication.Remove(compraGado);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

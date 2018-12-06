using AutoMapper;
using Marfrig.CompraGado.API.ViewModels;
using Marfrig.CompraGado.Application.Interfaces;
using Marfrig.CompraGado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Marfrig.CompraGado.API.Controllers
{
    public class AnimaisController : ApiController
    {
        private readonly IAnimalApplication _animalApplication;

        public AnimaisController(IAnimalApplication animalApplication)
        {
            _animalApplication = animalApplication;
        }


        public IHttpActionResult Get()
        {
            var animais = Mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalViewModel>>(_animalApplication.GetAll());

            return Ok(animais);
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var animal = _animalApplication.GetById(id);

                if (animal == null)
                {
                    return BadRequest("Animal não encontrado");
                }

                var animalViewModel = Mapper.Map<Animal, AnimalViewModel>(animal);

                return Ok(animalViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody]AnimalViewModel animal)
        {
            try
            {
                if (animal == null)
                {
                    return BadRequest("Animal não pode ser vazio");
                }

                var animalViewModel = Mapper.Map<AnimalViewModel, Animal>(animal);

                _animalApplication.Add(animalViewModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(int id, [FromBody]AnimalViewModel animal)
        {
            try
            {
                if (animal == null)
                {
                    return BadRequest("Animal não pode ser vazio");
                }

                var animalViewModel = Mapper.Map<AnimalViewModel, Animal>(animal);

                _animalApplication.Update(animalViewModel);

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
                var animal = _animalApplication.GetById(id);

                if (animal == null)
                {
                    return BadRequest("Animal não encontrado");
                }

                _animalApplication.Remove(animal);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

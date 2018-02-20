using Models.ViewModels;
using Services.cs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TechTest.Controllers.Api
{
    public class PeopleController : ApiController
    {
        private IPersonService PersonService;
        private IColourService ColourService;

        public PeopleController(IPersonService personService, IColourService colourService)
        {
            PersonService = personService;
            ColourService = colourService;
        }

        public IHttpActionResult GetPeople()
        {
            var people = PersonService.GetPeople();
            return Ok(people);
        }

        [HttpPost]
        public IHttpActionResult SavePerson(SaveUpdateViewModel model)
        {
            try
            {
                if (model.Person.PersonId == 0)
                {
                    PersonService.AddPerson(model);
                }
                else
                {
                    PersonService.UpdatePerson(model);
                }

                PersonService.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult DeletePerson(int id)
        {
            try
            {
                PersonService.DeletePerson(id);
                PersonService.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPerson(int id)
        {
            PersonViewModel personViewModel = PersonService.GetPersonByID(id);

            if (personViewModel == null)
            {
                return BadRequest("No person found");
            }

            return Ok(personViewModel);
        }
    }
}
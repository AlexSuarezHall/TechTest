using AutoMapper;
using DataAccess.cs;
using Models.Models;
using Models.ViewModels;
using Services.cs.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.cs
{
    public class PersonService : IPersonService
    {
        public ITechTestContext Context { get; }

        public PersonService(ITechTestContext context)
        {
            Context = context;
        }

        public List<PersonViewModel> GetPeople()
        {
            var list = Context.People.ToList();

            var returnList = new List<PersonViewModel>();

            foreach (Person person in list)
            {
                var model = Mapper.Map<Person, PersonViewModel>(person);
                model.Colours = person.Colours.Select(Mapper.Map<Colour, ColourViewModel>).ToList();
                returnList.Add(model);
            }

            return returnList;
        }

        public PersonViewModel GetPersonByID(int id)
        {
            PersonViewModel personViewModel = Mapper.Map<Person,PersonViewModel>(Context.People.Find(id));

            if (personViewModel.Colours.Any())
            {
                foreach (ColourViewModel colourVm in personViewModel.Colours)
                {
                    personViewModel.ColourIds.Add(colourVm.ColourId);
                }
            }

            return personViewModel;
        }

        public void AddPerson(SaveUpdateViewModel model)
        {
            var newColours = Context.Colour.Where(x => model.ColourIds.Contains(x.ColourId)).ToList();
            var person = Mapper.Map<PersonViewModel, Person>(model.Person);
            person.Colours = newColours;
            Context.People.Add(person);
        }

        public void DeletePerson(int personId)
        {
            var model = Context.People.Find(personId);
            Context.People.Remove(model);
        }

        public void UpdatePerson(SaveUpdateViewModel model)
        {
            var newPerson = Context.People.Find(model.Person.PersonId);
            var newColours = Context.Colour.Where(c => model.ColourIds.Contains(c.ColourId)).ToList();

            newPerson.FirstName = model.Person.FirstName;
            newPerson.LastName = model.Person.LastName;
            newPerson.Gender = model.Person.Gender;
            newPerson.DOB = model.Person.DOB;
            newPerson.PreviouslyOrdered = model.Person.PreviouslyOrdered;
            newPerson.Colours.Clear();
            newPerson.Colours = newColours;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}

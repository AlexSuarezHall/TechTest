using Models.Models;
using Models.ViewModels;
using System.Collections.Generic;

namespace Services.cs.Interfaces
{
    public interface IPersonService
    {
        List<PersonViewModel> GetPeople();
        PersonViewModel GetPersonByID(int id);
        void AddPerson(SaveUpdateViewModel model);
        void DeletePerson(int personId);
        void UpdatePerson(SaveUpdateViewModel model);
        void Save();
    }
}

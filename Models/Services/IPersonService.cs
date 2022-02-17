using System.Collections.Generic;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Models.Services
{
    public interface IPersonService
    {

        Person Add(CreatePersonViewModel personVM);

        List<Person> createStartList();

        Person GetById(int id);

        List<Person> GetList();

        List<Person> GetList2();

        List<Person> Search(string text);

        bool Delete(int id);
        void DeleteAll();
    }
}
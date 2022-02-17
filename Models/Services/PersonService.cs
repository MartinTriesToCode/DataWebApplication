using System.Collections.Generic;
using WebApplication1.Models.Entities;
using WebApplication1.Models.Repo;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Models.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepo _personRepo;

        public PersonService()
        {
            _personRepo = new InMemoryPersonRepo();
        }

        public Person Add(CreatePersonViewModel personVM)
        {
            if (string.IsNullOrWhiteSpace(personVM.Name) || string.IsNullOrWhiteSpace(personVM.City))
            {
                return null;
            }
            Person newPerson = new Person()
            {
                Name = personVM.Name,
                Phone = personVM.Phone,
                City = personVM.City
            };

            Person person = _personRepo.Create(newPerson);

            return person;
        }

        public List<Person> createStartList()
        {
            return _personRepo.InitiateList();
        }

        public Person GetById(int id)
        {
            return _personRepo.Read(id);
        }

        public List<Person> GetList()
        {
            return _personRepo.Read();
        }

        public List<Person> GetList2()
        {
            return _personRepo.Read2();
        }

        public List<Person> Search(string text)
        {
            

            var list = _personRepo.Read();
            List<Person> matches = new List<Person>();

            foreach (var item in list)
            {
                if (text.Contains(item.Name)|| text.Contains(item.City))
                {
                    matches.Add(item);
                }
            }
            
            return matches;
        }

        public bool Delete(int id)
        {
            return _personRepo.Delete(id);
        }

        public void DeleteAll()
        {
            _personRepo.DeleteAll();
        }
    }
}

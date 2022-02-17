using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Repo
{
    public class InMemoryPersonRepo : IPersonRepo
    {
        private static int idCounter = 0;
        private static List<Person> listOfPerson = new List<Person>();
        private static List<Person> backupList = new List<Person>();

        public Person Create(Person person)
        {
            idCounter = listOfPerson.Count;
            Person newPerson = new Person();
            newPerson.Id = ++idCounter;
            newPerson.Name = person.Name;
            newPerson.Phone = person.Phone;
            newPerson.City = person.City;


            listOfPerson.Add(newPerson);
            backupList.Add(newPerson);
            return newPerson;
        }

        public List<Person> InitiateList()
        {
            listOfPerson.Add(new Person { Id = 1, Name = "Jane", Phone = 0701234641, City = "Jokkmokk" });
            listOfPerson.Add(new Person { Id = 2, Name = "Elon", Phone = 0765820742, City = "Kiruna" });
            listOfPerson.Add(new Person { Id = 3, Name = "Tuva", Phone = 0729836275, City = "Boden" });
            listOfPerson.Add(new Person { Id = 4, Name = "Erik", Phone = 0787256184, City = "Kvikkjokk" });
            listOfPerson.Add(new Person { Id = 5, Name = "Saga", Phone = 0737889396, City = "Gällivare" });
            listOfPerson.Add(new Person { Id = 6, Name = "Nils", Phone = 0754782963, City = "Luleå" });
            listOfPerson.Add(new Person { Id = 7, Name = "Mona", Phone = 0772894679, City = "Niemisel" });
            listOfPerson.Add(new Person { Id = 8, Name = "Mats", Phone = 0767372294, City = "Hakkas" });
            listOfPerson.Add(new Person { Id = 9, Name = "Elin", Phone = 0710846249, City = "Torneå" });
            listOfPerson.Add(new Person { Id = 10, Name = "Olle", Phone = 0792786345, City = "Haparanda" });

            backupList.Add(new Person { Id = 1, Name = "Jane", Phone = 0701234641, City = "Jokkmokk" });
            backupList.Add(new Person { Id = 2, Name = "Elon", Phone = 0765820742, City = "Kiruna" });
            backupList.Add(new Person { Id = 3, Name = "Tuva", Phone = 0729836275, City = "Boden" });
            backupList.Add(new Person { Id = 4, Name = "Erik", Phone = 0787256184, City = "Kvikkjokk" });
            backupList.Add(new Person { Id = 5, Name = "Saga", Phone = 0737889396, City = "Gällivare" });
            backupList.Add(new Person { Id = 6, Name = "Nils", Phone = 0754782963, City = "Luleå" });
            backupList.Add(new Person { Id = 7, Name = "Mona", Phone = 0772894679, City = "Niemisel" });
            backupList.Add(new Person { Id = 8, Name = "Mats", Phone = 0767372294, City = "Hakkas" });
            backupList.Add(new Person { Id = 9, Name = "Elin", Phone = 0710846249, City = "Torneå" });
            backupList.Add(new Person { Id = 10, Name = "Olle", Phone = 0792786345, City = "Haparanda" });


            return listOfPerson;
        }

        public List<Person> Read()
        {
            return listOfPerson;
        }

        public List<Person> Read2()
        {
            return backupList;
        }


        public Person Read(int id)
        {
            return listOfPerson.SingleOrDefault(c => c.Id == id);
        }

        public bool Delete(int id)
        {
            Person original = Read(id);

            if (original == null)
            {
                return false;
            }
            backupList.Remove(original);
            return listOfPerson.Remove(original);
        }

        public void DeleteAll()
        {
            listOfPerson.Clear();
        }
    }
}

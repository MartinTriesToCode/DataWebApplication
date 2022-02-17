using System.Collections.Generic;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Repo
{
    public interface IPersonRepo
    {
        //C.R.U.D for Person


        Person Create(Person person);

        List<Person> InitiateList();

        List<Person> Read();

        List<Person> Read2();

        Person Read(int id);

        bool Delete(int id);

        void DeleteAll();
    }
}

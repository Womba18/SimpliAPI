using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.Repository_Interfaces
{
    public interface IRepository <T>
    {
        string Create(T t);

        List<T> ReadAll();

        T Read(string ID);

        string Update(T t);

        string Delete(T t);

        T BuildObject();

        T DeconstructObject();

        List<T> BuildObjects();

        List<T> DeconstructObjects();
    }
}

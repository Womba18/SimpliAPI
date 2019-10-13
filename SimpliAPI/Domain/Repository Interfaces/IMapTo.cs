using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.Repository_Interfaces
{
    public interface IMapTo<T>
    {
        T MapTo(string key);
    }
}

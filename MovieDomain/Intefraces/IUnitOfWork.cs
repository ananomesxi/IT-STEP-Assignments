using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Intefraces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}

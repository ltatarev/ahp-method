using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AHP.Repository.Common
{
    public interface IUnitOfWork 
    {
        IProjectRepository Projects { get; }
        int Complete();

    }
}

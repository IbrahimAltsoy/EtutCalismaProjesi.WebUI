using EtutCalismaProjesi.Data.Absract;
using EtutCalismaProjesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtutCalismaProjesi.Service.Absract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {

    }
}

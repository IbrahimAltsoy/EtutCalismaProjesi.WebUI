using EtutCalismaProjesi.Data.Concreate;
using EtutCalismaProjesi.Data;
using EtutCalismaProjesi.Entities;
using EtutCalismaProjesi.Service.Absract;

namespace EtutCalismaProjesi.Service.Concreate
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {


        }


    }
}

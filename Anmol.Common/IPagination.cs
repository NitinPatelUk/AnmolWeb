using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Anmol.Common
{
    public interface Ipagination<T> where T : class
    {
        IQueryable<T> GetPainated(string filter, int initialpage, int pageSize, out int totalRecords, out int recordsFiltered);
    }
}

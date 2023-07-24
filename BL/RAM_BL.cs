using ET;
using DAL;
using System.Data;

namespace BL
{
    public class RAM_BL
    {
        private RAM_DAL dal = new RAM_DAL();
        public DataTable BuscarRam()
        {
            return dal.BuscarRAM();
        }
    }
}
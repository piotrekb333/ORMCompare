using ORMCompare.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCompare.Services.Repositories
{
    public class ManageDatabaseRepository : IManageDatabaseRepository
    {
        private readonly DbContext _context;

        public ManageDatabaseRepository(DbContext context)
        {
            this._context = context;
        }

        public bool CheckDatabase()
        {
            if (!_context.Database.Exists())
            {
                _context.Database.Create();
            }
            return true;
        }

        public bool CheckIfExistsDatabase()
        {
            try
            {
                return _context.Database.Exists();
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

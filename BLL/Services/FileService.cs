using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class FileService
    {
        private readonly DataContext _db;
        public FileService(DataContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Delete file if he exist
        /// </summary>
        public async Task DeleteFileByName(string fileName)
        {
            var fileDb = await _db.Files.FirstOrDefaultAsync(x => x.NameFile == fileName);
            if (fileDb != null)
            {
                _db.Files.Remove(fileDb);
                await _db.SaveChangesAsync();
            }
        }
    }
}

using Ajaxcrud.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace Ajaxcrud.Data
{
    public class Applicationdb :DbContext
    {
        public Applicationdb(DbContextOptions<Applicationdb> options) : base (options)
        {


        }
        DbSet<Employee> Employees { get; set; } 


    }
}

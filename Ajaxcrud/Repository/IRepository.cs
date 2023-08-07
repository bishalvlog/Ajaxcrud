using Ajaxcrud.Models;

namespace Ajaxcrud.Repository
{
    public interface IRepository
    {
        public List<Employee> GetAll();
        public int Add(Employee employee);  
        public int Update(Employee employee);
        public int Delete(int Id);
    }
}

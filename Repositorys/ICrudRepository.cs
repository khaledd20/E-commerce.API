using System.Collections.Generic;

namespace AngEcommerceProject.Repositorys
{
    public interface ICrudRepository<T> where T : class
    {
        public T create(T item);
        public T update(int id ,T item);
        public int delete(T item); 
        public T GetById(int id);
        public List<T> GetAll();
    }
}

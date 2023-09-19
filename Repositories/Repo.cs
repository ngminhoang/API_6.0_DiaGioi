using API_6._0_2.DBcontext;

namespace API_6._0_2.Repositories
{
    public interface Repo<T> where T : class
    {
        List<T> GetAll();
        T Read(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int MaxId();
    }
 }

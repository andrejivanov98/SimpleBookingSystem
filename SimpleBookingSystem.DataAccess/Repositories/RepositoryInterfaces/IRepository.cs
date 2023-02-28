namespace SimpleBookingSystem.DataAccess.Repositories.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
		T GetById(int id);
		void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}

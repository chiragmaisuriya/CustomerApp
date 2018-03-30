using CustomerAPP.Model;

namespace CustomerAPP.Data
{
    /// <summary>
    /// Interface for "Unit of Work"
    /// </summary>
    public interface ICustomerAPPUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
       
        IRepository<Customer> CustomersRepository { get; }
       
    }
}
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce.DataAccess.Abstracts;

public interface IUnitOfWork
{
  Task<int> SaveChangesAsync();
  Task<IDbContextTransaction> BeginTransactionAsync();
}
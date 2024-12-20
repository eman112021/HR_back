using HR_2024.Core;
using HR_2024.Core.Interface;
using HR_2024.Core.Model;
using HR_2024.Ef.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Ef
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppCon _appcon;
        private IDbContextTransaction _transaction;

        public IbaseRep<GeneralManagement> generalManagement { private set; get; }
        public IbaseRep<Management_Sub> management_sub {  private set; get; }
        public IbaseRep<Department> department {  private set; get; }
        public IbaseRep<Vacation> vacation { private set; get; }

        public IbaseRep<Tb_Help> help { private set; get; }
        public IbaseRep<Evaluation> evaluation { private set; get; }

        public UnitOfWork(AppCon appcon)
        {
            _appcon = appcon;
            generalManagement = new BaseRep<GeneralManagement>(_appcon);
            management_sub= new BaseRep<Management_Sub>(_appcon);
            department = new BaseRep<Department>(_appcon);
            vacation = new BaseRep<Vacation>(_appcon);
            help = new BaseRep<Tb_Help>(_appcon);
            evaluation = new BaseRep<Evaluation>(_appcon);


        }



        public async Task BeginTransctionAsync()
        {
            _transaction= await _appcon.Database.BeginTransactionAsync();


        }
       
        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }
        public async  Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
        public async Task<int> complete()
        {
            return await _appcon.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appcon.Dispose();
            _transaction?.Dispose();
           
        }
    }
}

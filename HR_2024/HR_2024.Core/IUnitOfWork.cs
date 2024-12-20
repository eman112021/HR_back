using HR_2024.Core.Interface;
using HR_2024.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core
{
    public interface IUnitOfWork :IDisposable
    {
      public IbaseRep<GeneralManagement> generalManagement { get; }
        public IbaseRep<Management_Sub> management_sub {  get; }
        public IbaseRep<Department> department { get; }
        public IbaseRep<Vacation> vacation { get; }
        public IbaseRep<Tb_Help> help { get; }
        public IbaseRep<Evaluation> evaluation { get; }


        Task<int> complete();

        Task BeginTransctionAsync();
        Task CommitAsync();
        Task RollbackAsync();
            
        
    }
}

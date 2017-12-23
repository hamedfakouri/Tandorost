using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Framework.Core;

namespace Framework.CastleWindsor
{
    public class TransactionInterceptor : IInterceptor
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionInterceptor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Intercept(IInvocation invocation)
        {
            if (ShouldNotProceddInTransaction(invocation))
            {
                invocation.Proceed();
                return;
            }
            ProceedMethodInTransaction(invocation);

        }
        private static bool ShouldNotProceddInTransaction(IInvocation invocation)
        {
            bool result=false;
            if (invocation.Method.Name.StartsWith("Get", StringComparison.InvariantCultureIgnoreCase)
                || invocation.Method.Name.StartsWith("Upload", StringComparison.InvariantCultureIgnoreCase))
                result = true;
            return result;
                
        }
        private void ProceedMethodInTransaction(IInvocation invocation)
        {
            try
            {
                _unitOfWork.Begin();
                invocation.Proceed();
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    _unitOfWork.RollBack();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}

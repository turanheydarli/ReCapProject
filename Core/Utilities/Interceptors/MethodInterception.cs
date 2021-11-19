using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
	public abstract class MethodInterception : MethodInterceptionBaseAttribute
	{
		protected virtual void OnBefore(IInvocation invocation) { }
		protected virtual void OnAfter(IInvocation invocation) { }
		protected virtual void OnException(IInvocation invocation, System.Exception e) { }
		protected virtual void OnSuccess(IInvocation invocation) { }

		public override void Intercept(IInvocation invocation)
		{
			var isSucces = true;
			OnBefore(invocation);
			try
			{
				invocation.Proceed();
			}
			catch (Exception e)
			{
				OnException(invocation, e);
				isSucces = false;
				throw;
			}
			finally
			{
				if (isSucces)
				{
					OnSuccess(invocation);
				}
			}
			OnAfter(invocation);
		}

	}
}

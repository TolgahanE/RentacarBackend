using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        // Öncelik belirtme
        public int Priority { get; set; }

        // invocation = Metodumuzu bulan parametre = metot.
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}

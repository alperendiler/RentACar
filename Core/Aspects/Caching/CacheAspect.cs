using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//DurationSet
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {                                       //Method.NameSpace.Manager.MethodName(Example:Business.Concrete.IProductService.GetAll)            
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
                         //Method.parameters.ToList()
            var arguments = invocation.Arguments.ToList();
            // method+                    if there is parameter =parameters else not parameters = null
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {   //Method.Return = _cacheManager.Get(key);
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //Method.Continue
            invocation.Proceed();
            //AddCache(Key,Return,duration
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}

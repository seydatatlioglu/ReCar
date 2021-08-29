using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new PerformanceAspect(5));//bir metotun çalışması 5 sn yi geçerse beni uyar... tüm metotlar için geçerli
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));  >>>>  (loglama'yı default olarak ekler)
            //loglama yapmak istiyorsak bu metotu çalıştırabiliriz..

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}

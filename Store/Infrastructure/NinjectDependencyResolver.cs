using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using Store.Domain.Abstract;
using Store.Domain.Concrete;
using Store.Domain.Entities;

namespace Store.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this._kernel = kernel;
            AddBindings();
        }
        
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}
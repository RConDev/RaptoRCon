using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Web.Http.Dependencies;

namespace RaptoRCon.Server.Config
{
    /// <summary>
    /// Resolve dependencies for Web API using MEF.
    /// </summary>
    public class MefDependencyResolver : IDependencyResolver
    {
        private readonly CompositionContainer container;

        public MefDependencyResolver(CompositionContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// Called to request a service implementation.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementation or null.</returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            var name = AttributedModelServices.GetContractName(serviceType);
            var export = container.GetExportedValueOrDefault<object>(name);
            return export;
        }

        /// <summary>
        /// Called to request service implementations.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementations.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }

            var exports = container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
            return exports;
        }

        public void Dispose()
        {
        }
    }
}

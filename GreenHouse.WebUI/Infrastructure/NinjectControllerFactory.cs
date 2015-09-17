using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using GreenHouse.Domain.Abstract;
using GreenHouse.Domain.Concrete;

namespace GreenHouse.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
              ? null
              : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IRoomRepository>().To<EFRoomRepository>();
            _ninjectKernel.Bind<IReservationRepository>().To<EFReservationRepository>();
        }
    }
}
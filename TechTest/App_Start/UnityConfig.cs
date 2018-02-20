using DataAccess.cs;
using Services.cs;
using Services.cs.Interfaces;
using System;
using TechTest.Models;
using Unity;

namespace TechTest
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterType<ITechTestContext, TechTestContext>()
                .RegisterType<IPersonService, PersonService>()
                .RegisterType<IColourService, ColourService>();
        }
    }
}
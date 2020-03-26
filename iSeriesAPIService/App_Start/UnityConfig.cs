using iSeriesAPIService.Interfaces;
using iSeriesAPIService.Services;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.WebApi;

namespace iSeriesAPIService
{
    public static class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static void RegisterTypes(IUnityContainer container)
        {
            container
                .RegisterType<IParameterService, ParameterService>();
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
    }
}
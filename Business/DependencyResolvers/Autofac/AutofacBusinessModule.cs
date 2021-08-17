using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OurServiceManager>().As<IOurServiceService>();
            builder.RegisterType<EfOurServiceDal>().As<IOurServiceDal>();

            builder.RegisterType<OurServiceImageManager>().As<IOurServiceImageService>();
            builder.RegisterType<EfOurServiceImageDal>().As<IOurServiceImageDal>();

            builder.RegisterType<FileHelper>().As<IFileHelper>();

            builder.RegisterType<AboutUsManager>().As<IAboutUsService>();
            builder.RegisterType<EfAboutUsDal>().As<IAboutUsDal>();

            builder.RegisterType<PersonelFormManager>().As<IPersonelFormService>();
            builder.RegisterType<EfPersonelFormDal>().As<IPersonelFormDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()

            });

        }


    }
}

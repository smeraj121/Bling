using ProofOfConcept.Repository;
using ProofOfConcept.Services;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ProofOfConcept
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
              container.RegisterType<IUserRepository, UserRepository>();
              container.RegisterType<IUserService, UserService>();
              container.RegisterType<IUserDetailsRepository, UserDetailsRepository>();
              container.RegisterType<IUserDetailsService, UserDetailsService>();
              container.RegisterType<IPhotoService, PhotoService>();
              container.RegisterType<IPhotoRepository, PhotoRepository>();
              container.RegisterType<IPhotoStatsRepository, PhotoStatsRepository>();
              container.RegisterType<IPhotoStatsService,PhotoStatsService>();
              container.RegisterType<IPopularsRepository, PopularsRepository>(); 
              container.RegisterType<IPresentService, PresentService>();
              container.RegisterType<IUsersRepository, UsersRepository>();
              container.RegisterType<IUsersService, UsersService>();
              container.RegisterType<IAdminRepository, AdminRepository>();
              container.RegisterType<IAdminService, AdminService>();
              container.RegisterType<IAdminPhotoRepository, AdminPhotoRepository>();
              container.RegisterType<IAdminPhotoService, AdminPhotoService>();
              container.RegisterType<IAdminUsersRepository, AdminUsersRepository>();
              container.RegisterType<IAdminUsersService, AdminUsersService>();
              //container.RegisterType<IInstitutionService, InstitutionService>();
              RegisterTypes(container);
              DependencyResolver.SetResolver(new UnityDependencyResolver(container));
              return container;
          });
        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.REST.CMS
{
	/// <summary>
	/// REST WCF service for SiteDomains
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CMS/SiteDomain")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class SiteDomainService : ISiteDomainService, IService
    {
		/// <summary>
		/// Gets a SiteDomain object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CMS.DTO.SiteDomain Get( string id )
        {
            var currentUser = Rock.CMS.User.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
				Rock.CMS.SiteDomain SiteDomain = SiteDomainService.Get( int.Parse( id ) );
				if ( SiteDomain.Authorized( "View", currentUser ) )
					return SiteDomain.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this SiteDomain", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a SiteDomain object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CMS.DTO.SiteDomain ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
					Rock.CMS.SiteDomain SiteDomain = SiteDomainService.Get( int.Parse( id ) );
					if ( SiteDomain.Authorized( "View", user.UserName ) )
						return SiteDomain.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this SiteDomain", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a SiteDomain object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateSiteDomain( string id, Rock.CMS.DTO.SiteDomain SiteDomain )
        {
            var currentUser = Rock.CMS.User.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
				Rock.CMS.SiteDomain existingSiteDomain = SiteDomainService.Get( int.Parse( id ) );
				if ( existingSiteDomain.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingSiteDomain).CurrentValues.SetValues(SiteDomain);
					
					if (existingSiteDomain.IsValid)
						SiteDomainService.Save( existingSiteDomain, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingSiteDomain.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this SiteDomain", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a SiteDomain object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateSiteDomain( string id, string apiKey, Rock.CMS.DTO.SiteDomain SiteDomain )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
					Rock.CMS.SiteDomain existingSiteDomain = SiteDomainService.Get( int.Parse( id ) );
					if ( existingSiteDomain.Authorized( "Edit", user.UserName ) )
					{
						uow.objectContext.Entry(existingSiteDomain).CurrentValues.SetValues(SiteDomain);
					
						if (existingSiteDomain.IsValid)
							SiteDomainService.Save( existingSiteDomain, user.PersonId );
						else
							throw new WebFaultException<string>( existingSiteDomain.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this SiteDomain", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new SiteDomain object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateSiteDomain( Rock.CMS.DTO.SiteDomain SiteDomain )
        {
            var currentUser = Rock.CMS.User.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
				Rock.CMS.SiteDomain existingSiteDomain = new Rock.CMS.SiteDomain();
				SiteDomainService.Add( existingSiteDomain, currentUser.PersonId );
				uow.objectContext.Entry(existingSiteDomain).CurrentValues.SetValues(SiteDomain);

				if (existingSiteDomain.IsValid)
					SiteDomainService.Save( existingSiteDomain, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingSiteDomain.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new SiteDomain object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateSiteDomain( string apiKey, Rock.CMS.DTO.SiteDomain SiteDomain )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
					Rock.CMS.SiteDomain existingSiteDomain = new Rock.CMS.SiteDomain();
					SiteDomainService.Add( existingSiteDomain, user.PersonId );
					uow.objectContext.Entry(existingSiteDomain).CurrentValues.SetValues(SiteDomain);

					if (existingSiteDomain.IsValid)
						SiteDomainService.Save( existingSiteDomain, user.PersonId );
					else
						throw new WebFaultException<string>( existingSiteDomain.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a SiteDomain object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteSiteDomain( string id )
        {
            var currentUser = Rock.CMS.User.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
				Rock.CMS.SiteDomain SiteDomain = SiteDomainService.Get( int.Parse( id ) );
				if ( SiteDomain.Authorized( "Edit", currentUser ) )
				{
					SiteDomainService.Delete( SiteDomain, currentUser.PersonId );
					SiteDomainService.Save( SiteDomain, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this SiteDomain", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a SiteDomain object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteSiteDomain( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.SiteDomainService SiteDomainService = new Rock.CMS.SiteDomainService();
					Rock.CMS.SiteDomain SiteDomain = SiteDomainService.Get( int.Parse( id ) );
					if ( SiteDomain.Authorized( "Edit", user.UserName ) )
					{
						SiteDomainService.Delete( SiteDomain, user.PersonId );
						SiteDomainService.Save( SiteDomain, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this SiteDomain", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}

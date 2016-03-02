# plain.webapi
A super clean and plain 'ol WebAPI project template

- Create a project
    - Web
    - ASP.NET Web Application
        - Name your project
        - Uncheck “Create directory for solution” (check if your project will be the main solution)
            - A good structure to follow
                - Project Name (Solution Level)
                    - Project Name.WebApi (Project Level)
                    - Project Name.Web (Project Level)
                    - Project Name.Data (Project Level)
                    - Project Name.Tests (Project Level)
        - Click OK
    - Select a template
        - Empty
        - Click OK
- Add WebApi dependency
    - Right on the project
        - Click Manage NuGet Packages...
    - Search online for
        - Microsoft.AspNet.WebApi
    - OR
        - Run in Package Manager Console
            - Install-Package Microsoft.AspNet.WebApi
- Add NuGet Restore
    - Right click on the project
    - Properties
    - Build Events
    - Pre-build event command line
        - nuget.exe restore "$(SolutionPath)"
- Configure routing
    - Add a Global Application Class to the root of the project.  Default name supplied: Global.asax
    - Create a new folder called App_Start
        - Add a class called WebApiConfig
        - Create a static void method called Register(HttpConfiguration config)

```
        public static void Register(HttpConfiguration config)
        {
            // Web API Routes
            config.MapHttpAttributeRoutes();

            // Configure Json Formatter
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); 
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // Set Routing
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
```
- In the Application_Start(), add:
``` 
GlobalConfiguration.Configure(WebApiConfig.Register);
```
- Add a Controller
    - Create new folder called “Controllers"
    - Add a class in that folder
    - Choose empty
    - Add simple Get method
```
        [HttpGet]
        [Route(“api/[whatever name]")]
        public string Get()
        {
            return "Hi";
        }
```

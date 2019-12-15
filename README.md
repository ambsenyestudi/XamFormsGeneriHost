In order to make the project work you must insert at appsettins.json seciton Movies your omdbapi key at field ApiKey

For Di I Followed
https://montemagno.com/add-asp-net-cores-dependency-injection-into-xamarin-apps-with-hostbuilder/

For http api consumtions I used this api 
http://www.omdbapi.com/

Mentioned in this the article
https://somostechies.com/consumiendo-servicios-rest-con-refit/

Your appsettings file has to be an embedded resource
You need to install Microsoft.Extensions.Http Nuget in order to had httpclient
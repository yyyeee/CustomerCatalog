# ABOUT:
## GOAL
Customer catalog is a project created especially for interview and training purposes. 

## TECHNOLOGIES
.NET CORE 2.1
ASP.NET Core WebApi
LiteDB
Vue.js + Vuex
Xunit + FluentAssertions
Specflow + Selenium

## AUTHOR
yyyeee

# PREREQUISITIES:
* Install npm
* Install @vue/cli: _npm install -g @vue/cli_
* Install @vue/cli: _npm install -g @vue/cli-service-global_
* Install Dotnet Core SDK 2.1 (e.g. using choco _choco install dotnetcore-sdk --pre_)

# GO TO PRODUCTION:
* Prepare client application
** Go to _src\Client.Vue_
** Run _npm start build_
** Copy _src\Client.Vue\dist_ to server
* Prepare server application
** Go to _src\Web_
** Use _dotnet publish_ command
** Or open VS with project Web.csproj and use publish

# DEVELOPMENT:

## RUN SERVER:
* Go to _src\Web_
* Run _dotnet run_
* Open _http://localhost:2321/swagger_

## RUN CLIENT:
* Go to _src\Client.Vue_
* Run _npm start serve_
* Open _http://localhost:8080_

## RUN INTEGRATION TESTS:
* Go to _src\IntegrationTests_
* Run _dotnet test_

## RUN ACCEPTANCE TESTS:
* TODO
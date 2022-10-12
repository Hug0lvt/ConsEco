FROM aosapps/drone-sonar-plugin AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

RUN dotnet tool install --global dotnet-sonarscanner

RUN dotnet tool install --global dotnet-reportgenerator-globaltool

RUN dotnet sonarscanner begin /k:"ConsEco" /d:sonar.host.url="https://codefirst.iut.uca.fr/sonar"  /d:sonar.login="sqp_ffc02968e133d03daeb917e8c2e6f243a80d087a"
RUN dotnet build
RUN dotnet sonarscanner end /d:sonar.login="sqp_ffc02968e133d03daeb917e8c2e6f243a80d087a"
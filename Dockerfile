RUN dotnet tool install --global dotnet-sonarscanner

RUN dotnet sonarscanner begin /k:"ConsEco" /d:sonar.host.url="https://codefirst.iut.uca.fr/sonar"  /d:sonar.login="sqp_ffc02968e133d03daeb917e8c2e6f243a80d087a"
RUN dotnet build
RUN dotnet sonarscanner end /d:sonar.login="sqp_ffc02968e133d03daeb917e8c2e6f243a80d087a"
FROM aosapps/drone-sonar-plugin AS base
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

COPY --from=base /bin/drone-sonar /bin/
WORKDIR /bin

RUN apk update && apk add openjdk11-jre nodejs && rm -rf /tmp/* /var/cache/apk/*

RUN dotnet tool install --global dotnet-sonarscanner
RUN dotnet tool install --global dotnet-reportgenerator-globaltool

ENV JAVA_HOME /usr/lib/jvm/default-jvm/
ENV PATH ${PATH}:${JAVA_HOME}/bin
ENV PATH $PATH:/root/.dotnet/tools

ENTRYPOINT /bin/drone-sonar

RUN dotnet sonarscanner begin /k:"ConsEco" /d:sonar.host.url="https://codefirst.iut.uca.fr/sonar"  /d:sonar.login="sqp_ffc02968e133d03daeb917e8c2e6f243a80d087a"
RUN dotnet build
RUN dotnet sonarscanner end /d:sonar.login="sqp_ffc02968e133d03daeb917e8c2e6f243a80d087a"
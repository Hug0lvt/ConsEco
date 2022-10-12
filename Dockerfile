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
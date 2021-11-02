#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["ProyectoUSMP_GYM/ProyectoUSMP_GYM.csproj", "ProyectoUSMP_GYM/"]
#RUN dotnet restore "ProyectoUSMP_GYM/ProyectoUSMP_GYM.csproj"
#COPY . .
#WORKDIR "/src/ProyectoUSMP_GYM"
#RUN dotnet build "ProyectoUSMP_GYM.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ProyectoUSMP_GYM.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProyectoUSMP_GYM.dll"]

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .

#CAMBIAR AQUI EL NOMBRE DEL APLICATIVO
#nombre de tu app busca en bin\Release\netcore5.0\plantitas.exe
ENV APP_NET_CORE ProyectoUSMP_GYM.dll

CMD ASPNETCORE_URLS=http://*:$PORT dotnet $APP_NET_CORE	
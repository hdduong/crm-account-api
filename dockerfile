FROM microsoft/aspnetcore:2.0
WORKDIR /app
EXPOSE 80
COPY ./Crm.Api/Docker/publish .
ENTRYPOINT ["dotnet", "Crm.Api.dll"]
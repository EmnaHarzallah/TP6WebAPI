# TP6 – ASP.NET Core Web API

## Fonctionnalités
- CRUD des catégories
- Utilisation des **DTO** avec **AutoMapper**
- Accès aux données via **Entity Framework Core**
- Authentification avec **ASP.NET Core Identity**
- Autorisation basée sur les rôles (**Admin / Customer**)
- Sécurisation des API avec **JWT Bearer Token**
- Documentation et tests via **Swagger**

## Technologies
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- AutoMapper
- JWT
- Swagger

## Lancement
```bash
dotnet restore
dotnet ef database update
dotnet run

Navigation vers : http://localhost:***/swagger

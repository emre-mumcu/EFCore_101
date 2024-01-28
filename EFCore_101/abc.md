whoami /user
Get-Acl

# Code
``` bash
dotnet ef migrations add Migration1 -o App_Data\Migrations
dotnet ef database update
dotnet watch run
```



# Package List
dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Relational

dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.InMemory

dotnet add package Markdig

# Adding a migration
```bash
# Open the terminal for the project having DbContext
# Ex: PS> dotnet ef migrations add Migration1  -c EIhaleDbContext -s ..\EIhale.Manager\ -o FolderName
PS> dotnet ef migrations add Migration1 -o App_Data\Migrations
```

# Update Database

```bash
# Ex: PS> dotnet ef database update  -c EIhaleDbContext -s ..\EIhale.UI.Mvc.Manager\ 
PS> dotnet ef database update
```


# Create Migration Scripts

```bash

# Ex: PS> dotnet ef migrations script Migration1 Migration2 -c EIhaleDbContext -s ..\EIhale.UI.Mvc.Manager\ -o script.sql
# Ex: PS> dotnet ef migrations script --help
# Ex: PS> dotnet ef migrations script ver1 ver2
# Ex: PS> dotnet ef migrations script ver1 ver2 -o ./script.sql
PS> 
```

## Not
```bash
PS D:\AppStore\EIhale\EIhale\EIhale.Data>
dotnet ef migrations add Migration1 -c EIhaleDbContext -s ..\EIhale.UI.Mvc.Manager\

PS D:\AppStore\EIhale\EIhale\EIhale.Data>
dotnet ef database update  -c EIhaleDbContext -s ..\EIhale.UI.Mvc.Manager\

PS D:\AppStore\EIhale\EIhale\EIhale.Data>
dotnet ef migrations script Migration1 Migration2 -c EIhaleDbContext -s ..\EIhale.UI.Mvc.Manager\ -o Sql3.sql
```


PS D:\AppStore\EIhale\EIhale\EIhale.Data> 
dotnet ef migrations add Migration1 -c EIhaleDbContext -s ..\EIhale.UI.Mvc.Manager\
dotnet ef database update  -c EIhaleDbContext -s ..\EIhale.UI.Mvc.Manager\


# EF Core Inheritance

https://learn.microsoft.com/en-us/ef/core/modeling/inheritance
https://www.learnentityframeworkcore.com/inheritance

// using Microsoft.EntityFrameworkCore.Relational; 
// TPC sadece EFCore7 de destekleniyor
// modelBuilder.Entity<IhaleBilgi>().UseTpcMappingStrategy();
// modelBuilder.Entity<IhaleBilgi>().UseTpcMappingStrategy().ToTable(nameof(IhaleBilgi));
// EF Core 7 Öncesinde aşağıdaki gibi çözülebilir ancak inherit edilen propertiy'lerde sorun oluyor!
// modelBuilder.Entity<LogIhaleBilgi>().ToTable(nameof(LogIhaleBilgi));


# DB First

https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli

dotnet user-secrets init

dotnet user-secrets set ConnectionStrings:Chinook "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook"

dotnet ef dbcontext scaffold "Name=ConnectionStrings:Chinook" Microsoft.EntityFrameworkCore.SqlServer

dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook" Microsoft.EntityFrameworkCore.SqlServer

-Context AppDbContext --context-dir Data --output-dir Models

# how to create MVC dotnet app via terminal

dotnet new mvc -n MyMvcApp

# to run the app

dotnet run

# To add a new package

dotnet add package Microsoft.EntityFrameworkCore

# database

dotnet ef migrations add InitialMigration

dotnet ef database update


# partial validation
In Order to add javascript validation, we can use Validation partial script defined in shared 


@section Script{
    @{
        <partial name="_ValidationScriptsPartial" />
    }
}
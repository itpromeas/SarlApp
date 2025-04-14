# How to create MVC dotnet app via terminal

dotnet new mvc -n MyMvcApp

# How to create razor dotnet app via terminal

dotnet new razor -n MyMvcApp

# to run the app

dotnet run

# To add a new package

dotnet add package Microsoft.EntityFrameworkCore

# database

dotnet ef migrations add InitialMigration

dotnet ef database update


# How to create library dotnet app via terminal

dotnet new classlib -n MyLibrary


example:

dotnet new classlib -n MVCWebApp.DataAccess

# partial validation
In Order to add javascript validation, we can use Validation partial script defined in shared 


@section Script{
    @{
        <partial name="_ValidationScriptsPartial" />
    }
}

# Find id in db

The following are eqivalent:

1. using Find() which uses the primary key of the model
CategoryModel? categoryFromDb = _db.Categories.Find(id);

2. Using FirstOrDefault or Where condition which use any field of the default
CategoryModel? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
CategoryModel? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();


Note: *id* in asp-route-id should match with parameter name *id* in *public IActionResult Edit(int? id)*

If you use categoryId, then we will have

asp-route-categoryId="@item.Id" 

# edit

add *<input asp-for="Id" hidden />* in order not to create a new category in edit

# TempData
only stay for one instance... then goes away

# Notification

It is better to add a common partial view in _Layout in order to be used in all pages

# toastr

https://codeseven.github.io/toastr/

3 Easy Steps

For other API calls, see the demo.

Link to toastr.css <link href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css" rel="stylesheet"/>

Link to toastr.js <script src="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>

use toastr to display a toast for info, success, warning or error

// Display an info toast with no title
toastr.info('Are you the 6 fingered man?')




# Multiple App in one solution


dotnet new sln -n MySolution
cd MySolution

## App 1
dotnet new mvc -n MVCWebApp

//add it to the solution

dotnet sln add MVCWebApp/MVCWebApp.csproj


### To build the whole solution
dotnet build

### To run a specific project

### How to add package in multiple project solution .net

dotnet add WebApp/WebApp.csproj package <PackageName>
dotnet add ApiService/ApiService.csproj package <PackageName>
dotnet add MyLibrary/MyLibrary.csproj package <PackageName>

example:

dotnet add MVCWebApp/MVCWebApp.csproj package Microsoft.EntityFrameworkCore  

### How to add migration in multiple project solution .net

dotnet ef migrations add <MigrationName> --project <DbContextProject> --startup-project <StartupProject>
dotnet ef database update --project DataAccess --startup-project WebApp

Example:

dotnet ef migrations add InitialMigration --project MVCWebApp --startup-project MVCWebApp 
dotnet ef database update --project MVCWebApp --startup-project MVCWebApp



--project: Points to the project containing your DbContext
--startup-project: Points to the project that contains the app entry point (e.g., Razor or API)

### How to run a specific app in multiple project solution .net

dotnet run --project <PathToProject>

Example:

dotnet run --project MVCWebApp/MVCWebApp.csproj


## App 2

dotnet new razor -n RazorApp
dotnet sln add RazorApp/RazorApp.csproj

dotnet run --project RazorApp/RazorApp.csproj  



### Migration
dotnet ef migrations add AddCategoryToDB --project RazorApp --startup-project RazorApp
dotnet ef database update --project RazorApp --startup-project RazorApp

### Adding reference
dotnet add reference ../MVCWebApp.Models/MVCWebApp.Models.csproj 


## Specific to Razor page

1. We do not use again asp-controller asp-action

<a asp-page="Categories/Edit" asp-route-id="@item.Id" class="btn btn-info mx-2">
    <i class="bi bi-pencil-square"></i> Edit
</a>

instead of 

<a asp-controller="Category" asp-action="Edit" asp-route-id="@item.Id" class="btn btn-info mx-2">
    <i class="bi bi-pencil-square"></i> Edit
</a>

2. Always put *On* infront of the method name in .cs file

public void *OnGet()*
{
    CategoryList = _db.Categories.ToList();
}


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
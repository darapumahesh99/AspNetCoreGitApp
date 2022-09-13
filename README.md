# AspNetCoreGitApp

# Installing AspnetCoreRunTimeCompilation Package
step 1: right click on root project => select manage nuget package => select browse => enter "Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" and install
<------> step 2: make changes in startup file => services.AddRazorPages().AddRazorRuntimeCompilation();
<------> step 3: adding conditional run time compilation in debug mode only => {#if DEBUG
                                                                                        services.AddRazorPages().AddRazorRuntimeCompilation();
                                                                                #endif}


# 05/09/2020: Making web responsive 
             Header, footer, navbar, display model list data on view
# Section and RenderSection
 Header=> css => Body => Footer => Js
 If we write js code in view then it will not come in the above mentioned manner in layout. Section and RenderSection will Solve this problem.



# 06/09/2022: 
# _viewStart file in Asp net core => 
common code in views will be written here => if we don't want this common code in some views then override(Layout=null) in that particular view. 
we can use different _viewstart files for different views

# _viewImports file
to import common libraries among views

# RenderSection
RenderSection is a space with a specific name and it used on
_Layout file.
RenderSection tells the application that some other code
(coming from view) will be placed here.

# Section
Section is used on Views.
To create a section we use @section directive.
Each section has a unique name and whatever we will write
inside this section block that will replace the RenderSection
(defined in _Layout file) with same name.



# viewBag[used to pass data from [# action to view]

=> this type of data binding is known as loosely binding
=> we can pass any type of data
=> viewbag use dynamic property. Syntax: ViewBag.PropertyName = data; and use this in view as (@ViewBag.PropertyName)
=> we can pass data in viewBag with or without model
=> the scope of ViewBag is current action method to view


# 06/09/2022:
# ViewData [used to pass data from action to view & can also be used to pass data from view to layout]
=> Syntax: ViewData["Property name"] = data;
=> to use in view use razor syntax: @Viewdata["Property name"]

# Viewdata attribute[pass data from controller to view, controller to Layout]
[ViewData]
public string Name{get;set;}

{
eg., [Viewpata]
public string CustomProperty { get; set; }
public ViewResult Index()
{
CustomProperty "Custom value";
return View();
}

# Dynamic views
# Advantages
=> we can update the action method's logic easily
=> we can pass anonymous data easily
# Disadvantages
=> no compile time error
=> Not a good architecture
=> Generally developers avoid to use dynamic views

# 07/09/2022:
# Tag helpers
=> tag helpers used to render server side code on razor file to create and render HTML elements
# how to start with tag helpers
=> @addTagHelper => @addTagHelper tagHelper, assembly eg., @addTagHelper *, Micosoft.AspNetCore.Mvc.TagHelpers
=> @removeTagHelper

Note: if we want to use in one file then write in that file only else write in _ViewImports file

# Anchor tag helpers
What is Anchor tag helper
How to create a link using anchor tag helper
How to pass parameter value
How to pass lots of query string data
How to pass fragment
How to pass a complete url
And lots of other thing ...

=> Anchor tag helper is used to create a link using <a> </a> html element
=> By default all tag helpers attributes are prefixed with asp

# How to use Anchor tag helper
The main feature of using a link is to navigate to a specific page.
Attributes:
✓ asp-controller
✓asp-action
✓ asp-area

How to pass parameter using Anchor tag
Attribute
# asp-route-{paramName}

# Pass lots of data using Anchor tag
Attribute
asp-all-route-data = variable name (dictionary)

# Pass fragment using Anchor tag
Attribute
asp-fragment

# Pass complete url using Anchor tag
Attribute
asp-protocol
asp-host

# Compatible with routing
Attribute
asp-route
<--------------------------------------------->



# Image Tag helper
What is Image tag helper
What problem does Images tag helper resolve
How to handle caching using Image tag helper


=>Image tag helper is used to give some additional capabilities to
=>HTML img tag
=>Image tag helper is used to provide cache-busting behaviour for
=>static image

# what is the problem with the html image tag? 
=> once the page is loaded then we update an image then if we refresh the page then we don't get the updated image because data will be retrieved from memory cache
=> once after loaded. In order to see the change have to empty cache and hard reload or click ctrl+shift+del to delete cache.
=> image tag helpers solve this problem

# How to handle caching for static file
Attribute: asp-append-version="true"

# Note: Image taghelper works only in while accessing from local server. Using any third party source this image tag helper won't work

# Environment tag helper
Environment tag helper is used to render some content based on current environment.
Environments:
  Development
  ✓ Staging
  ✓ Production
  
# Problem: non minified files has large space (performance not good) and minified files are small in size(performance good but can't debug on brwser). Depends on the environmnet the usage of files should be there for better performance
# Environment tag helper attributes
names
include
exclude


# 09/09/2022
# Link tag helpers
What is Link tag helper
What problem does Link tag helper
resolve
How to use Link tag helper
How fallback works

# CDN (content delivery network) => loads the content based on the geographical location (bootstrap, jquery...)
once the data loaded into browser will never hit the server, next time will get from browser cache


# Link tag helper attributes (used in environment tag)
href
asp-fallback-href
asp-fallback-test-class
asp-fallback-test-property
asp-fallback-test-value






# Form tag helpers
Form:
=>A form is used to get data from user.
=>A form has various input options for user to get data easily.
=>Text box, Text Area, Calendar, Radio button, Checkbox
=>Dropdown, Number, Email etc.
# Form components
Form tag
Input elements
Method
Submit URL
Submit button









# Entity Framework Core
EF Core is Microsoft's official technology to interact with
relational database.
EF Core can work with lots of databases.
✓ Sql Server
✓ MySQL
✓ Cosmos db

# Entity Framework Core features
✓O/RM (object-relational mapper)
✓ Open-source
✓ Lightweight
✓ Extensible
✓ Support Async

# O/RM
✓ O/RM is a tool and is used to manage database data from an
object-oriented perspective.
✓ Database tables => Classes
Column=> Properties
To generate database tables or classes we can use either
code first or database first approach

# How EF Core work
✓ EF Core works with the help of Model.
✓ A model is made up of entity classes and a context object.


# EF Core approach
✓ Code first
✓ Db first

# 12/09/2022
# Install Entity Framework Core in asp.net core application
# Packages
=> The global package for ef core is [Microsoft.Entity FrameworkCore]
=> Based on the database we also need to install several other packages.
 
# EF Core packages for Sql Server
Microsoft.Entity FrameworkCore
Micosoft.Entity FrameworkCore.Relational
Microsoft.Entity FrameworkCore.SqlServer [ By installing this, the first two packages automatically installed]
Microsoft.Entity FramerworkCore.Tools [next install this]

# EF Core database provider
=> https://docs.microsoft.com/en-us/ef/core/providers

1) click on the above link and install package or from visual studio right click on project source explorer and select nuget package manager then install by searching 
   "Microsoft.EntityFrameworkCore.SqlServer"
2) create a class and then extend with DbContext 
3) create a constructor eg., public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options){}
4) Create data base name. eg., public DbSet<Books> Books { get; set; }
5) Add service in startUp class: services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=.;Database=BookStore;Integrated Security=True;"));
  
# Click on tools => 
  Select Package Manager Console => enter get-help entityframework => enter "Add-Migration init" => enter "update-database" => see the migration table in SSMS (key).
  
# Generate DataBase using Entity framework core CLI
=> after enter "Add-Migration init" => enter "update-database"
=> see the changes in SSMS (we can also update table by adding new columns)
  
  
# Add data in database using entity framework core
1) open repository => 
  
# Making Async call using entity framework core 
 => add async await in add new book
  
  
  
  
# Model Validations
# What is validation
=> Validation is a process of checking an activity whether it meets the desired level of compliance.
=> In Asp.Net core, validation is the process of checking fields of a form in order to meet the defined criteria.

  
# Server side (model) validation
=>In asp.net core we use validations as attributes.
=>These attributes are available in
=>[System.ComponenetModel.DataAnnotations]
=>Using these attributes we can validate, set error message, set display label, Field type, etc. for a particular field
  
# Server side (model) validation attributes
✓ Required 
✓ RegularExpression
✓ EmailAddress 
✓ Url
✓Range(min, max) 
✓ Remote
✓ StringLength 
✓ We can also create custom
✓ Credit Card validation attributes
✓ Compare
Phone

# How to check the model validation
=> ModelState.IsValid  



# 13/09/2022

# Validation summary
=> Validation summary tag helper is used to display a summary of validation messages.
=> We use asp-validation-summary attribute to display validation summary
✓ asp-validation-summary is used with div tag.

# Validation summary attribute value
✓ All => to get error msg without custom messages
✓ ModelOnly => only custom messages will be displayed
✓ None => no validation summary error messages will be displayed

# Data type attribute 
# Attribute
✓ DataType(DataType.NameOfProperty)

# Dropdown
=> Create dropdown using Hardcoded values
=> Pass data from view to controller
✓ Default selected value
✓ Select optional text
✓ Add HTML 5 validation
✓ Add server side validation

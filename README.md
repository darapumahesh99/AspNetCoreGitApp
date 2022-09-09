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

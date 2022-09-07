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

# viewBag
=> used to pass data from # action to view
=> this type of data binding is known as loosely binding
=> we can pass any type of data
=> viewbag use dynamic property. Syntax: ViewBag.PropertyName = data; and use this in view as (@ViewBag.PropertyName)
=> we can pass data in viewBag with or without model
=> the scope of ViewBag is current action method to view

# 06/09/2022:
# ViewData

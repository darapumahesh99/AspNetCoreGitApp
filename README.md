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

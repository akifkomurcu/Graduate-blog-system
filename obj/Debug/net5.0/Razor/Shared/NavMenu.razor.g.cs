#pragma checksum "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39ecaac5b2d86ce0f36b795a5097a6e9984389f8"
// <auto-generated/>
#pragma warning disable 1591
namespace mvvm1.Shared
{
    #line hidden
#nullable restore
#line 2 "C:\Users\Akif\Desktop\mvvm1\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Akif\Desktop\mvvm1\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Akif\Desktop\mvvm1\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Akif\Desktop\mvvm1\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Akif\Desktop\mvvm1\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Akif\Desktop\mvvm1\_Imports.razor"
using mvvm1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Akif\Desktop\mvvm1\_Imports.razor"
using mvvm1.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Threading.Tasks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Diagnostics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Net;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Net.Sockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using Microsoft.Data.SqlClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "top-row pl-4 navbar navbar-dark");
            __builder.AddAttribute(2, "b-ii7uf7t4ry");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href b-ii7uf7t4ry>PROJE</a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 3 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "b-ii7uf7t4ry");
            __builder.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\" b-ii7uf7t4ry></span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", 
#nullable restore
#line 8 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
             NavMenuCssClass

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
                                        ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "b-ii7uf7t4ry");
            __builder.OpenElement(14, "ul");
            __builder.AddAttribute(15, "class", "nav flex-column");
            __builder.AddAttribute(16, "b-ii7uf7t4ry");
            __builder.OpenElement(17, "li");
            __builder.AddAttribute(18, "class", "nav-item px-3");
            __builder.AddAttribute(19, "b-ii7uf7t4ry");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(20);
            __builder.AddAttribute(21, "class", "nav-link");
            __builder.AddAttribute(22, "href", "");
            __builder.AddAttribute(23, "Match", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Routing.NavLinkMatch>(
#nullable restore
#line 11 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
                                                     NavLinkMatch.All

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(25, "<span class=\"oi oi-home\" aria-hidden=\"true\" b-ii7uf7t4ry></span> Giriş Yap\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n\r\n        ");
            __builder.OpenElement(27, "li");
            __builder.AddAttribute(28, "class", "nav-item px-3");
            __builder.AddAttribute(29, "b-ii7uf7t4ry");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(30);
            __builder.AddAttribute(31, "class", "nav-link");
            __builder.AddAttribute(32, "href", "sohbet");
            __builder.AddAttribute(33, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(34, "<span class=\"oi oi-plus\" aria-hidden=\"true\" b-ii7uf7t4ry></span> Sohbet\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n        ");
#nullable restore
#line 21 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
__builder.AddContent(36, UserID);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "C:\Users\Akif\Desktop\mvvm1\Shared\NavMenu.razor"
                                   
    private bool collapseNavMenu = true;
    [Inject]
    public ProtectedLocalStorage localStorage { get; set; }
    public string resultCookieValue { get; set; } = "";
    public string UserID { get; set; } = "";
    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "E:\GitHubRepos\InternetShop\InternetShop\Views\Admin\AddCategoryProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87be9b8bd2abe72dfb01625e03a65f2b27261679"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AddCategoryProduct), @"mvc.1.0.view", @"/Views/Admin/AddCategoryProduct.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\GitHubRepos\InternetShop\InternetShop\Views\_ViewImports.cshtml"
using InternetShop.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GitHubRepos\InternetShop\InternetShop\Views\_ViewImports.cshtml"
using Entities.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\GitHubRepos\InternetShop\InternetShop\Views\_ViewImports.cshtml"
using Entities.DataTransferObject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\GitHubRepos\InternetShop\InternetShop\Views\_ViewImports.cshtml"
using Repository;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87be9b8bd2abe72dfb01625e03a65f2b27261679", @"/Views/Admin/AddCategoryProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e0077474ae92c08a5ba068b202716e0edecdf5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AddCategoryProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductCategoryDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>AddProductCategory</h1>\r\n<div>\r\n");
#nullable restore
#line 4 "E:\GitHubRepos\InternetShop\InternetShop\Views\Admin\AddCategoryProduct.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"panel-body\">\r\n            ");
#nullable restore
#line 7 "E:\GitHubRepos\InternetShop\InternetShop\Views\Admin\AddCategoryProduct.cshtml"
       Write(Html.EditorForModel());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"panel-footer\">\r\n            <input type=\"submit\" value=\"???????????????? ??????????????????\" />\r\n            ");
#nullable restore
#line 11 "E:\GitHubRepos\InternetShop\InternetShop\Views\Admin\AddCategoryProduct.cshtml"
       Write(Html.ActionLink("????????????", "Index", "Admin", new { @class = "btn btn-dark" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 13 "E:\GitHubRepos\InternetShop\InternetShop\Views\Admin\AddCategoryProduct.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductCategoryDto> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fd3ea760492d535364bcd8bc806d3eee5919b76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Level2), @"mvc.1.0.view", @"/Views/Home/Level2.cshtml")]
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
#line 1 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\_ViewImports.cshtml"
using NASA_Hackathon;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\_ViewImports.cshtml"
using NASA_Hackathon.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fd3ea760492d535364bcd8bc806d3eee5919b76", @"/Views/Home/Level2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566735061923bc7f239313bf5aae59c3809d44af", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Level2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NASA_Hackathon.Models.Level2Model>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
  
    ViewBag.Title = "Level2";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Level 2</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
 using (Html.BeginForm()) 
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"form-horizontal\">\r\n    <hr />\r\n    ");
#nullable restore
#line 15 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 17 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
   Write(Html.LabelFor(model => model.NeutralizingAntibodies, "中和抗體數據", htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-4\">\r\n            ");
#nullable restore
#line 19 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
       Write(Html.EditorFor(model => model.NeutralizingAntibodies, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 20 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
       Write(Html.ValidationMessageFor(model => model.NeutralizingAntibodies, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" value=\"Submit\" class=\"btn btn-primary\" />\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 30 "C:\Users\YiSong\source\repos\NASA Hackathon\NASA Hackathon\Views\Home\Level2.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NASA_Hackathon.Models.Level2Model> Html { get; private set; }
    }
}
#pragma warning restore 1591
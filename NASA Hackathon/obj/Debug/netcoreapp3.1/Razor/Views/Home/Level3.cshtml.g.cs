#pragma checksum "C:\gitlab\NASA-Hackathon\NASA Hackathon\Views\Home\Level3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d5587c1ea6076c895ede04afb872867b25f396d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Level3), @"mvc.1.0.view", @"/Views/Home/Level3.cshtml")]
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
#line 1 "C:\gitlab\NASA-Hackathon\NASA Hackathon\Views\_ViewImports.cshtml"
using NASA_Hackathon;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\gitlab\NASA-Hackathon\NASA Hackathon\Views\_ViewImports.cshtml"
using NASA_Hackathon.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d5587c1ea6076c895ede04afb872867b25f396d", @"/Views/Home/Level3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"566735061923bc7f239313bf5aae59c3809d44af", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Level3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NASA_Hackathon.Models.Level3Model>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/webcamjs/webcam.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\gitlab\NASA-Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
  
    ViewBag.Title = "??????????????????????????????????????????";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Neutralizing Antibody Test Kit Calculate Neutralizing Antibody Concentration</h2>\r\n\r\n");
#nullable restore
#line 9 "C:\gitlab\NASA-Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\gitlab\NASA-Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\gitlab\NASA-Hackathon\NASA Hackathon\Views\Home\Level3.cshtml"
                            

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script type=\"text/javascript\" src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5587c1ea6076c895ede04afb872867b25f396d4807", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">
    $(function () {
        Webcam.set({
            width: 240,
            height: 360,
            image_format: 'jpeg',
            jpeg_quality: 100
        });

        Webcam.set('constraints', {
            facingMode: ""environment""
        });
        Webcam.attach(""#idwebcam"")

        //??????
        $(""#btncapture"").click(function () {
            Webcam.snap(function (data_uri) {
                $(""#idcaptured"")[0].src = data_uri;
                var element = document.getElementById('idcaptured');
                element.style.clip = ""rect(160px, 140px, 175px, 60px)"";
                element.style.position = ""absolute"";


                var element = document.getElementById('MyImage');
                element.value = """";
                /*Webcam.upload(data_uri, '/Home/Level3', function (code, text) {
                    alert(""123"")
                });*/
            });
        });

        //??????
        $(""#btncalculate"").click(fun");
            WriteLiteral(@"ction () {
            var file = document.getElementById(""idcaptured"").src;

            var formdata = new FormData();
            formdata.append(""base64image"", file);

            var element = document.getElementById('idcaptured');
            if (element.style.position == ""absolute"")
                formdata.append(""crop"", true);
            else
                formdata.append(""crop"", false);

            $.ajax({
                url: ""/Home/Level3"",
                type: ""POST"",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (response) {
                    alert(response.responseText);
                },
            });
        });

        //??????
        $(""#MyImage"").change(function () {
            if (this.files && this.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#idcaptured').attr('src', e.target");
            WriteLiteral(@".result);
                }
                var element = document.getElementById('idcaptured');
                element.style.clip = ""rect(auto, auto, auto, auto)"";
                element.style.position = ""relative"";

                reader.readAsDataURL(this.files[0]);
            }
        });
    });
</script>

<hr />
<table border=""0"" cellpadding=""0"" cellspacing=""0"" data-role=""table"" class=""ui-responsive"">
    <tr>
        <th align=""center"">Live Camera</th>
        <th align=""center"">Captured Picture</th>
    </tr>
    <tr>
        <td style=""position: relative"">
            <div id=""idwebcam""></div>
            <span style=""position: absolute; top: 140px; left: 20px; color:red; font-weight:bold;"">Align to the test kit area</span>
            <div style=""position: absolute; top: 160px; left: 60px; border: 5px solid red; width: 80px; height: 15px""></div>
        </td>
        <td style=""position: relative; text-align:center; vertical-align:middle"">
            <img style=""positi");
            WriteLiteral(@"on: absolute; top: 0px; left: 0px; clip: rect(160px 140px 175px 60px);"" id=""idcaptured"" />
        </td>
    </tr>
    <tr>
        <td align=""center"">
            <input type=""file"" id=""MyImage"" name=""MyImage"">
        </td>
        <td align=""center"">
        </td>
    </tr>
    <tr>
        <td align=""center"">
            <input type=""button"" id=""btncapture"" value=""Capture"" class=""btn btn-primary"" />
        </td>
        <td align=""center"">
            <input type=""submit"" id=""btncalculate"" value=""Calculate"" class=""btn btn-primary"" />
        </td>
    </tr>
</table>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NASA_Hackathon.Models.Level3Model> Html { get; private set; }
    }
}
#pragma warning restore 1591

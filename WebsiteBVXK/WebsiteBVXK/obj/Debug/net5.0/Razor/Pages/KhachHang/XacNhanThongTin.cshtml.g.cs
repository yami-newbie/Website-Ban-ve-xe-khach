#pragma checksum "D:\Website\Web Ban ve xe khach\BackEnd\WebsiteBVXK\WebsiteBVXK\Pages\KhachHang\XacNhanThongTin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "616bf983f96050b3151b04ae37aeba0a4b7ecb9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebsiteBVXK.Pages.KhachHang.Pages_KhachHang_XacNhanThongTin), @"mvc.1.0.razor-page", @"/Pages/KhachHang/XacNhanThongTin.cshtml")]
namespace WebsiteBVXK.Pages.KhachHang
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
#line 1 "D:\Website\Web Ban ve xe khach\BackEnd\WebsiteBVXK\WebsiteBVXK\Pages\_ViewImports.cshtml"
using WebsiteBVXK;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"616bf983f96050b3151b04ae37aeba0a4b7ecb9a", @"/Pages/KhachHang/XacNhanThongTin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a7e65950eb984363104a8fb7d73e67e545b5eb", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_KhachHang_XacNhanThongTin : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/KhachHang/ThongTinChuyenKhoan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Website\Web Ban ve xe khach\BackEnd\WebsiteBVXK\WebsiteBVXK\Pages\KhachHang\XacNhanThongTin.cshtml"
  
    Layout = "_Layout";
    ViewData["Tittle"] = "Xác Nhận Thông Tin";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""wrapper"">
    <div class=""title"">
        Xác nhận thông tin đặt vé
    </div>
    <div class=""form"">
        <div class=""input-field"">
            <label>Hành khách</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Số điện thoại</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Email</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>CMND/CCCD</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Chuyến</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Ngày khởi hành</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Loại xe</label>
            <");
            WriteLiteral(@"input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Số ghế</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Số lượng</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            <label>Tổng tiền</label>
            <input type=""text"" class=""input"">
        </div>
        <div class=""input-field"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "616bf983f96050b3151b04ae37aeba0a4b7ecb9a5250", async() => {
                WriteLiteral("<input type=\"submit\" value=\"Xác nhận\" class=\"btn\">");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebsiteBVXK.Pages.KhachHang.XacNhanThongTinModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebsiteBVXK.Pages.KhachHang.XacNhanThongTinModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebsiteBVXK.Pages.KhachHang.XacNhanThongTinModel>)PageContext?.ViewData;
        public WebsiteBVXK.Pages.KhachHang.XacNhanThongTinModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

#pragma checksum "D:\Github\Website-Ban-ve-xe-khach\WebsiteBVXK\WebsiteBVXK\Pages\Admin\QuanLyDonHang.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4416611dd350ef12e18e07e724f3410ff3eb992e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebsiteBVXK.Pages.Admin.Pages_Admin_QuanLyDonHang), @"mvc.1.0.razor-page", @"/Pages/Admin/QuanLyDonHang.cshtml")]
namespace WebsiteBVXK.Pages.Admin
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
#line 1 "D:\Github\Website-Ban-ve-xe-khach\WebsiteBVXK\WebsiteBVXK\Pages\_ViewImports.cshtml"
using WebsiteBVXK;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4416611dd350ef12e18e07e724f3410ff3eb992e", @"/Pages/Admin/QuanLyDonHang.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92a7e65950eb984363104a8fb7d73e67e545b5eb", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_QuanLyDonHang : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Github\Website-Ban-ve-xe-khach\WebsiteBVXK\WebsiteBVXK\Pages\Admin\QuanLyDonHang.cshtml"
  
    Layout = "_Layout";
    ViewData["Tittle"] = "Quản Lý Đơn hàng";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""head-title"">
    <div class=""left"">
        <h1>Trang Quản lý</h1>
        <ul class=""breadcrumb"">
            <li>
                <a href=""#"">Trang Quản lý</a>
            </li>
            <li><i class='bx bx-chevron-right'></i></li>
            <li>
                <a class=""active"" href=""#"">");
#nullable restore
#line 17 "D:\Github\Website-Ban-ve-xe-khach\WebsiteBVXK\WebsiteBVXK\Pages\Admin\QuanLyDonHang.cshtml"
                                      Write(ViewData["Tittle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
            </li>
        </ul>
    </div>
    <a href=""#"" class=""btn-download"">
        <i class='bx bxs-cloud-download'></i>
        <span class=""text"">Download PDF</span>
    </a>
</div>

<div class=""table-data"">

    <div class=""todo"">
        <div class=""head"">
            <h3>Thông tin đơn hàng</h3>

        </div>

        <ul class=""input-list"">
            <table class=""inputable"">
                <tr>
                    <td> Mã đơn hàng:</td>
                    <td>
                        <input type=""text"">
                    </td>
                </tr>
                <tr>

                    <td>Mã vé:  </td>
                    <td>
                        <input type=""text"">
                    </td>
                </tr>
                <td>Mã xe:  </td>
                <td>
                    <input type=""text"">
                </td>
                </tr>
                </tr>
                <td>Mã lịch trình:  </td>
                <td>
  ");
            WriteLiteral(@"                  <input type=""text"">
                </td>
                </tr>


            </table>
        </ul>
        <div class=""head"">
            <h3 style=""margin-top: 15px;"">Thông tin khách hàng</h3>

        </div>


        <ul class=""input-list"">
            <table class=""inputable"">
                <tr>
                    <td> Tên khách hàng:</td>
                    <td>
                        <input type=""text"">
                    </td>
                </tr>
                <tr>

                    <td>Số điện thoại: </td>
                    <td>
                        <input type=""tel"" name=""sodienthoai"">
                    </td>
                </tr>
                <tr>
                    <td> Thời gian đón: </td>
                    <td>
                        <input type=""time"" name=""thoigiandon"">
                    </td>
                </tr>

                <tr>
                    <td> Điểm đón </td>
                    <td>
        ");
            WriteLiteral("                <select name=\"diemdon\"");
            BeginWriteAttribute("id", " id=\"", 2561, "\"", 2566, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4416611dd350ef12e18e07e724f3410ff3eb992e6159", async() => {
                WriteLiteral("Đà Nẵng");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4416611dd350ef12e18e07e724f3410ff3eb992e7146", async() => {
                WriteLiteral("Hà Tĩnh");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </select>\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td> Điểm trả </td>\r\n                    <td>\r\n                        <select name=\"diemtra\"");
            BeginWriteAttribute("id", " id=\"", 2898, "\"", 2903, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4416611dd350ef12e18e07e724f3410ff3eb992e8508", async() => {
                WriteLiteral("Đà Nẵng");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4416611dd350ef12e18e07e724f3410ff3eb992e9495", async() => {
                WriteLiteral("Hà Tĩnh");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                    </td>
                </tr>
                <tr>
                    <td> Tổng tiền: </td>
                    <td>
                        <input type=""text"" name=""tongtien"">
                    </td>
                </tr>
                <tr>
                    <td> Tình trạng: </td>
                    <td>
                        <select name=""tinhtrang""");
            BeginWriteAttribute("id", " id=\"", 3442, "\"", 3447, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4416611dd350ef12e18e07e724f3410ff3eb992e11055", async() => {
                WriteLiteral("Đã thanh toán");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4416611dd350ef12e18e07e724f3410ff3eb992e12049", async() => {
                WriteLiteral("Chưa thành toán");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                    </td>
                </tr>

            </table>
        </ul>
        <table class=""table-buttoncn"">
            <tr>
                <td>

                    <button class=""buttontcn"">Cập nhật</button>

                </td>

            </tr>
        </table>

    </div>

    <div class=""order"">
        <div class=""head"">
            <h3>Danh sách đơn hàng</h3>
        </div>
        <table>
            <thead>
                <tr>

                    <th>Mã đơn hàng</th>
                    <th>Mã vé</th>
                    <th>Mã lịch trình</th>
                    <th>Mã xe</th>


                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><span class=""status pending""> DH0001</span></td>
                    <td>V0001</td>
                    <td>LT0001</td>
                    <td>X00001</td>



                </tr>
                <tr>
              ");
            WriteLiteral(@"      <td><span class=""status pending""> DH0002</span></td>
                    <td>V0002</td>
                    <td>LT0002</td>
                    <td>X00001</td>


                </tr>
                <tr>
                    <td><span class=""status pending""> DH0003</span></td>
                    <td>V0003</td>
                    <td>LT0003</td>
                    <td>X00001</td>


                </tr>
            </tbody>
        </table>

        <div class=""head"">
            <h3>Danh sách thông tin khách hàng</h3>
        </div>
        <table>
            <thead>
                <tr>

                    <th>Mã đơn hàng</th>
                    <th>Tên khách hàng</th>
                    <th>Số điện thoại</th>
                    <th>Thời gian đón</th>
                    <th>Điểm đón</th>
                    <th>Điểm trả</th>
                    <th>Tổng tiền</th>
                    <th>Tình trạng</th>

                </tr>
            </thead>
            ");
            WriteLiteral(@"<tbody>
                <tr>
                    <td><span class=""status pending""> DH0001</span></td>
                    <td>Nguyễn Thị Mai Linh</td>
                    <td>0708030580</td>
                    <td>13:00</td>
                    <td> Đà Nẵng</td>
                    <td>Hà Tĩnh</td>
                    <td>300000</td>
                    <td>Đã thanh toán</td>


                </tr>
                <tr>
                    <td><span class=""status pending""> DH0002</span></td>
                    <td>Trần Khánh Quỳnh</td>
                    <td>0366442978</td>
                    <td>13:00</td>
                    <td>Đà Nẵng</td>
                    <td>Hà Tĩnh</td>
                    <td>300000</td>
                    <td>Đã thanh toán</td>

                </tr>
                <tr>
                    <td><span class=""status pending""> DH0003</span></td>
                    <td>Trần Võ Thị Thùy Tiên</td>
                    <td>0366442978</td>
                ");
            WriteLiteral(@"    <td>13:00</td>
                    <td>Đà Nẵng</td>
                    <td>Hà Tĩnh</td>
                    <td>300000</td>
                    <td>Đã thanh toán</td>

                </tr>
            </tbody>
        </table>

    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebsiteBVXK.Pages.Admin.QuanLyDonHangModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebsiteBVXK.Pages.Admin.QuanLyDonHangModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebsiteBVXK.Pages.Admin.QuanLyDonHangModel>)PageContext?.ViewData;
        public WebsiteBVXK.Pages.Admin.QuanLyDonHangModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

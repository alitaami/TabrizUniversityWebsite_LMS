#pragma checksum "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfca16da966eeb0a1d91e025c553b9d00e944fe1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowLesson), @"mvc.1.0.view", @"/Views/Home/ShowLesson.cshtml")]
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
#line 1 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\_ViewImports.cshtml"
using InstitueProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\_ViewImports.cshtml"
using InstitueProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bfca16da966eeb0a1d91e025c553b9d00e944fe1", @"/Views/Home/ShowLesson.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a3d046dc64c5e27cc8e19c0ef9a5fe005755ef7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_ShowLesson : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Institue.DataLayer.Entities.Lesson.LessonDetail>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
   List<Institue.DataLayer.Entities.Lesson.LessonDetail> lesson = ViewData["Lesson"] as List<Institue.DataLayer.Entities.Lesson.LessonDetail>;

    ViewData["Title"] = "نمایش درس";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">اعلانات</h5><span class=\"message-item\"></span>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
         foreach (var l in lesson.Where(l => l.LessonAlert != null))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <img src=\"https://lms.tabrizu.ac.ir/theme/image.php/egkuro/forum/1663587418/icon\" class=\"iconlarge activityicon\"");
            BeginWriteAttribute("alt", " alt=\"", 648, "\"", 654, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"presentation\" aria-hidden=\"true\"><span>  ");
#nullable restore
#line 15 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
                                                                                                                                                                              Write(l.LessonAlert);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 16 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div><div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">جلسه های مجازی</h5>\r\n\r\n");
#nullable restore
#line 24 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
         foreach (var l in lesson.Where(l => l.LessonLink != null && l.LessonLinkDescription != null))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p><img src=\"https://lms.tabrizu.ac.ir/theme/image.php/egkuro/adobeconnect/1663587418/icon\" class=\"iconlarge activityicon\"");
            BeginWriteAttribute("alt", " alt=\"", 1113, "\"", 1119, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"presentation\" aria-hidden=\"true\"><a style=\"color:dimgrey;\"");
            BeginWriteAttribute("href", " href=\"", 1185, "\"", 1205, 1);
#nullable restore
#line 27 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue("", 1192, l.LessonLink, 1192, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1206, "\"", 1261, 6);
            WriteAttributeValue("", 1214, "برای", 1214, 4, true);
            WriteAttributeValue(" ", 1218, "شرکت", 1219, 5, true);
            WriteAttributeValue(" ", 1223, "در", 1224, 3, true);
#nullable restore
#line 27 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue(" ", 1226, l.LessonLinkDescription, 1227, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1251, "کلیک", 1252, 5, true);
            WriteAttributeValue(" ", 1256, "کنید", 1257, 5, true);
            EndWriteAttribute();
            WriteLiteral(">  ");
#nullable restore
#line 27 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
                                                                                                                                                                                                                                                                                         Write(l.LessonLinkDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n");
#nullable restore
#line 28 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">اسلاید ها</h5>\r\n");
#nullable restore
#line 37 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
         foreach (var l in lesson.Where(l => l.LessonPdfFile != null && l.LessonPdfFileDescription != null))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>  <img src=\"https://lms.tabrizu.ac.ir/theme/image.php/egkuro/core/1663587418/f/pdf-24\" class=\"iconlarge activityicon\"");
            BeginWriteAttribute("alt", " alt=\"", 1687, "\"", 1693, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"presentation\" aria-hidden=\"true\"> <a style=\"color:dimgrey;\"");
            BeginWriteAttribute("title", " title=\"", 1760, "\"", 1817, 5);
            WriteAttributeValue("", 1768, "برای", 1768, 4, true);
            WriteAttributeValue(" ", 1772, "دانلود", 1773, 7, true);
#nullable restore
#line 40 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue(" ", 1779, l.LessonPdfFileDescription, 1780, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1807, "کلیک", 1808, 5, true);
            WriteAttributeValue(" ", 1812, "کنید", 1813, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1818, "\"", 1856, 2);
            WriteAttributeValue("", 1825, "/DownloadFile/", 1825, 14, true);
#nullable restore
#line 40 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue("", 1839, l.LessonDetailId, 1839, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">  ");
#nullable restore
#line 40 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
                                                                                                                                                                                                                                                                                                            Write(l.LessonPdfFileDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n");
#nullable restore
#line 41 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">اسلاید ها</h5>\r\n");
#nullable restore
#line 47 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
         foreach (var l in lesson.Where(l => l.LessonVideoFile != null && l.LessonVideoFileDescription != null))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>  <img src=\"https://lms.tabrizu.ac.ir/theme/image.php/egkuro/core/1663587418/f/mpeg-24\" class=\"iconlarge activityicon\"");
            BeginWriteAttribute("alt", " alt=\"", 2284, "\"", 2290, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"presentation\" aria-hidden=\"true\"><a style=\"color:dimgrey;\"");
            BeginWriteAttribute("title", " title=\"", 2356, "\"", 2415, 5);
            WriteAttributeValue("", 2364, "برای", 2364, 4, true);
            WriteAttributeValue(" ", 2368, "دانلود", 2369, 7, true);
#nullable restore
#line 50 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue(" ", 2375, l.LessonVideoFileDescription, 2376, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2405, "کلیک", 2406, 5, true);
            WriteAttributeValue(" ", 2410, "کنید", 2411, 5, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 2416, "\"", 2455, 2);
            WriteAttributeValue("", 2423, "/DownloadVideo/", 2423, 15, true);
#nullable restore
#line 50 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue("", 2438, l.LessonDetailId, 2438, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">  ");
#nullable restore
#line 50 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
                                                                                                                                                                                                                                                                                                               Write(l.LessonVideoFileDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n");
#nullable restore
#line 51 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n<div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">تمرین ها</h5>\r\n");
#nullable restore
#line 57 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
         foreach (var l in lesson.Where(l => l.LessonPracticeFile != null && l.LessonPracticeFileDescription != null))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p>  <img src=\"https://lms.tabrizu.ac.ir/theme/image.php/egkuro/assign/1663587418/icon\" class=\"iconlarge activityicon\"");
            BeginWriteAttribute("alt", " alt=\"", 2887, "\"", 2893, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"presentation\" aria-hidden=\"true\"><a style=\"color:dimgrey;\"");
            BeginWriteAttribute("title", " title=\"", 2959, "\"", 3002, 2);
#nullable restore
#line 60 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue(" ", 2967, l.LessonPracticeFileDescription, 2968, 32, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("  ", 3000, "", 3002, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 3003, "\"", 3046, 2);
            WriteAttributeValue("", 3010, "/Home/SendPractice/", 3010, 19, true);
#nullable restore
#line 60 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue("", 3029, l.LessonDetailId, 3029, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">  ");
#nullable restore
#line 60 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
                                                                                                                                                                                                                                                                                                Write(l.LessonPracticeFileDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n");
#nullable restore
#line 61 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div><div class=\"card\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">پروژه ها</h5>\r\n");
#nullable restore
#line 66 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
         foreach (var l in lesson.Where(l => l.LessonProjectFile != null && l.LessonProjectFileDescription != null))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p><img src=\"https://lms.tabrizu.ac.ir/theme/image.php/egkuro/assign/1663587418/icon\" class=\"iconlarge activityicon\"");
            BeginWriteAttribute("alt", " alt=\"", 3475, "\"", 3481, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"presentation\" aria-hidden=\"true\"><a style=\"color:dimgrey;\"");
            BeginWriteAttribute("title", " title=\"", 3547, "\"", 3588, 2);
#nullable restore
#line 69 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue(" ", 3555, l.LessonProjectFileDescription, 3556, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3587, "", 3588, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 3589, "\"", 3631, 2);
            WriteAttributeValue("", 3596, "/Home/SendProject/", 3596, 18, true);
#nullable restore
#line 69 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
WriteAttributeValue("", 3614, l.LessonDetailId, 3614, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">  ");
#nullable restore
#line 69 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
                                                                                                                                                                                                                                                                                           Write(l.LessonProjectFileDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></p>\r\n");
#nullable restore
#line 70 "C:\Users\Sarv\source\repos\InstitueProject\InstitueProject\Views\Home\ShowLesson.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Institue.Core.Services.Interface.ILessonService _lesson { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Institue.DataLayer.Entities.Lesson.LessonDetail> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

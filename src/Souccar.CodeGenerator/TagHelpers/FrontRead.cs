using Microsoft.AspNetCore.Razor.TagHelpers;
using Souccar.hr.Personnel.Employees;
using System.Text;

namespace Souccar.CodeGenerator.TagHelpers
{
    public class FrontRead: TagHelper
    {
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "front-read-html"; 
            output.TagMode = TagMode.StartTagAndEndTag;
            var sb = new StringBuilder();
            sb.AppendFormat($"<pre><code>{Content}</code><pre/>");
            
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}

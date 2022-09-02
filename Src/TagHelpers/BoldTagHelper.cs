using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebCoreTest.TagHelpers
{
    [HtmlTargetElement("bold")]
    // only targets HTML markup that provides an attribute name of "bold"
    [HtmlTargetElement(Attributes = "bold")]
    public class BoldTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("bold");
            output.PreContent.SetHtmlContent("<strong>");
            output.PostContent.SetHtmlContent("</strong>");
        }
    }
}

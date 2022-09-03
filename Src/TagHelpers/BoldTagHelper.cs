using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebCoreTest.TagHelpers
{
    // target all "bold" HTML markup
    // <bold><strong> Is this bold?</strong></bold>
    [HtmlTargetElement("bold")]

    // only targets HTML markup that provides an attribute name of "bold"
    // Before: <p bold>Use this area to provide additional information.</p>
    // After: <p> <strong>Use this area to provide additional information.</strong></p>
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

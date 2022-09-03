using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebCoreTest.TagHelpers
{
    // Notes: nameof(Condition) = condition
    // The nameof operator will protect the code should it ever be refactored
    [HtmlTargetElement(Attributes = nameof(Condition))]
    public class ConditionTagHelper : TagHelper
    {
        public bool Condition { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Condition)
            {
                // does not show the HTML includes its children
                output.SuppressOutput();
            }
        }
    }
}

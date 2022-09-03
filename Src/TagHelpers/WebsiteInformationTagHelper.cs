using Microsoft.AspNetCore.Razor.TagHelpers;
using WebCoreTest.Models;

namespace WebCoreTest.TagHelpers
{
    // kebab case
    // <<website-information info="webInfo" />
    /// <summary>
    /// Razor knows the info attribute is a class, not a string, and you want to write C# code. Any non-string tag helper attribute should be written without the @ character.
    /// </summary>
    public class WebsiteInformationTagHelper : TagHelper
    {
        // define an attribute 
        public WebInfo Info { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            output.Content.SetHtmlContent(
$@"<ul><li><strong>Version:</strong> {Info.Version}</li>
<li><strong>Copyright Year:</strong> {Info.CopyrightYear}</li>
<li><strong>Approved:</strong> {Info.Approved}</li>
<li><strong>Number of tags to show:</strong> {Info.TagsToShow}</li></ul>");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}

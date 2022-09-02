using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebCoreTest.TagHelpers
{

    public class EmailTagHelper : TagHelper
	{
        private const string EmailDomain = "contoso.com";

        // Can be passed via <email mail-to="..." />. 
        // PascalCase(MailTo) gets translated into kebab-case(mail-to).
        public string MailTo { get; set; }
        public string CCTo { get; set; }

        //public override void Process(TagHelperContext context, TagHelperOutput output)
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Replaces <email> with <a> tag
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent();

            var address = MailTo + "@" + EmailDomain;

            // if href exists on html, then update it.
            output.Attributes.SetAttribute("href", "mailto:" + address);

            // if class exists on html, then it would not add this attribute
            output.Attributes.Add("class", "updateFromTagHelper");

            output.Content.SetContent(target);
            //base.Process(context, output);
        }
	}
}

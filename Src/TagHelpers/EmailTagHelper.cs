using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebCoreTest.TagHelpers
{
	public class EmailTagHelper : TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";
			//base.Process(context, output);
		}
	}
}

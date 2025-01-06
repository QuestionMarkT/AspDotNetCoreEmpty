namespace AspDotNetCoreEmpty.TagHelpers;

public class EmailTagHelper : TagHelper
{
    public string? Address { get; set; }
    public string? Content { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "a";
        output.Attributes.SetAttribute(new("href", $"mailto:{Address}", HtmlAttributeValueStyle.DoubleQuotes));
        output.Content.SetContent(Content);
    }
}
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ClimeiMvc.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        public string Mensagem { get; set; }

        public override void Process(
                   TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "alert alert-info");
            output.Content.AppendHtml("<i class=\"bi bi-info-circle-fill\"></i> ");
            output.Content.Append(Mensagem);
        }
    }
}

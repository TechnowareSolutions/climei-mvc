using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ClimeiMvc.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("a", Attributes = "asp-controller,asp-action,card-title,card-icon,card-bg-color,card-text")]
    public class CardTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("card-title")]
        public string CardTitle { get; set; }

        [HtmlAttributeName("card-icon")]
        public string CardIcon { get; set; }

        [HtmlAttributeName("card-bg-color")]
        public string CardBgColor { get; set; }

        [HtmlAttributeName("card-text")]
        public string CardText { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Adiciona a classe flex-fill ao elemento <a>
            output.Attributes.Add("class", "flex-fill");
            output.Attributes.Add("style", "max-width: 18rem; text-decoration: none;");

            // Gera a tag <div class="card text-white bg-success mb-3 flex-fill" style="max-width: 18rem;">
            var cardDiv = new TagBuilder("div");
            cardDiv.AddCssClass($"card text-white {CardBgColor} mb-3 flex-fill");
            cardDiv.Attributes.Add("style", "max-width: 18rem;");

            // Gera a tag <div class="card-body">
            var cardBodyDiv = new TagBuilder("div");
            cardBodyDiv.AddCssClass("card-body");

            // Gera a tag <h5 class="card-title"><i class="bi bi-people-fill"></i> Usuários</h5>
            var titleHeader = new TagBuilder("h5");
            titleHeader.AddCssClass("card-title");
            var icon = new TagBuilder("i");
            icon.AddCssClass($"bi {CardIcon}");
            titleHeader.InnerHtml.AppendHtml(icon);
            titleHeader.InnerHtml.Append($" {CardTitle}");

            // Gera a tag <p class="card-text">@ViewData["QntdUsers"]</p>
            var textParagraph = new TagBuilder("p");
            textParagraph.AddCssClass("card-text");
            textParagraph.InnerHtml.AppendHtml(CardText);

            // Monta a estrutura das tags
            cardBodyDiv.InnerHtml.AppendHtml(titleHeader);
            cardBodyDiv.InnerHtml.AppendHtml(textParagraph);
            cardDiv.InnerHtml.AppendHtml(cardBodyDiv);

            // Substitui a saída original pela nova estrutura
            output.Content.AppendHtml(cardDiv);

            // Adiciona os atributos asp-area, asp-controller e asp-action ao elemento <a>
            output.Attributes.Add("asp-area", "");
            output.Attributes.Add("asp-controller", Controller);
            output.Attributes.Add("asp-action", Action);
        }
    }
}

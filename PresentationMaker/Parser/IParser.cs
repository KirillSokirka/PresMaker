using AngleSharp.Html.Dom;

namespace PresentationMaker.Parser
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}

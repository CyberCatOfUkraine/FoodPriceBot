using HtmlAgilityPack;
using Parameters;

namespace DAL
{
    public class FullProductPage
    {
        private readonly HtmlWeb _web = new HtmlWeb();

        private HtmlNodeCollection getProductNodes(string product)
        {
            var htmlDoc = _web.LoadFromWebAsync(MainParameter.MainSite + MainParameter.Products + product);
            var docResult = htmlDoc.Result;
            return docResult.DocumentNode.SelectSingleNode("//div[@class='prodsview']").ChildNodes;
        }

        public string GetProductPageText(string product)
        {
            var result = "";
            foreach (var productChild in getProductNodes(product))
            {
                var html = productChild.ChildNodes;
                foreach (var node in html)
                    if (!node.HasChildNodes)
                        result += node.InnerText;
                    else
                        foreach (var nodeChild in node.ChildNodes)
                            result += " " + nodeChild.InnerText;

                result = result.Replace("&nbsp", " ").Replace(" ;", "").Replace("грн", " грн");
            }

            return result;
        }
    }
}
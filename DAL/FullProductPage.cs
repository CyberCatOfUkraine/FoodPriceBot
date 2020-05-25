using System.Linq;
using HtmlAgilityPack;
using Parameters;

namespace DAL
{
    public class FullProductPage
    {
        private readonly HtmlWeb _web = new HtmlWeb();

        private HtmlNodeCollection GetProductNodes(string product)
        {
            var htmlDoc = _web.LoadFromWebAsync(MainParameter.MainSite + MainParameter.Products + product);
            var docResult = htmlDoc.Result;
            return docResult.DocumentNode.SelectSingleNode("//div[@class='prodsview']").ChildNodes;
        }

        public string GetProductPageText(string product)
        {
            var result = "";
            foreach (var productChild in GetProductNodes(product))
            {
                var html = productChild.ChildNodes;
                foreach (var node in html)
                    if (!node.HasChildNodes)
                        result += node.InnerText;
                    else
                        for (var i = 0; i < node.ChildNodes.Count; i++)
                        {
                            var childNode = node.ChildNodes[i];
                            result += (" " + childNode.InnerText);
                        }

                result = result.Replace("&nbsp", " ").Replace(" ;", "").Replace("грн", " грн");
            }

            return result;
        }
    }
}
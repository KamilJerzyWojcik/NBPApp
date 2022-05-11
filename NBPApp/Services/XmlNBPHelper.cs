using NBPApp.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace NBPApp.Services
{
    public class XmlNBPHelper : INBPHelper
    {
        private XmlDocument xmlDoc;
        private string typeMedia => "application/xml";

        public void SetResult(string result)
        {
            xmlDoc = getXmlDocumentFromString(result);
        }

        public List<CurrencyDto> GetData()
        {
            List<CurrencyDto> data = new List<CurrencyDto>();
            string effectiveDate = getEffectiveDate();
            foreach (XmlNode node in xmlDoc.DocumentElement.LastChild.LastChild.ChildNodes)
            {
                data.Add(getCurrencyDto(node, effectiveDate));
            }
            return data;
        }

        public List<CurrencyDto> GetDataRange()
        {
            List<CurrencyDto> data = new List<CurrencyDto>();
            string effectiveDate = getEffectiveDate();
            foreach (XmlNode node in xmlDoc.DocumentElement.LastChild.LastChild.ChildNodes)
            {
                data.Add(getCurrencyDtoRange(node, effectiveDate));
            }
            return data;
        }

        public string GetTypeMedia() => typeMedia;

        private XmlDocument getXmlDocumentFromString(string result)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(result);
            return xmlDoc;
        }

        private CurrencyDto getCurrencyDto(XmlNode currencyNode, string effectiveDate)
        {
            decimal.TryParse(currencyNode.ChildNodes[2].InnerText, out decimal mid);
            return new CurrencyDto
            {
                Currency = currencyNode.ChildNodes[0].InnerText,
                Mid = mid,
                Code = currencyNode.ChildNodes[1].InnerText,
                EffectiveDate = DateTime.Parse(effectiveDate),
                Type = CurrencyType.Mid
            };
        }

        private CurrencyDto getCurrencyDtoRange(XmlNode currencyNode, string effectiveDate)
        {
            decimal.TryParse(currencyNode.ChildNodes[2].InnerText, out decimal bid);
            decimal.TryParse(currencyNode.ChildNodes[3].InnerText, out decimal ask);
            return new CurrencyDto
            {
                Currency = currencyNode.ChildNodes[0].InnerText,
                Bid = bid,
                Ask = ask,
                Code = currencyNode.ChildNodes[1].InnerText,
                EffectiveDate = DateTime.Parse(effectiveDate),
                Type = CurrencyType.AskBid
            };
        }

        private string getEffectiveDate() => xmlDoc.DocumentElement.LastChild.ChildNodes[2].InnerText;

        public string GetTableType() => xmlDoc.DocumentElement.LastChild.FirstChild.InnerText;
    }
}

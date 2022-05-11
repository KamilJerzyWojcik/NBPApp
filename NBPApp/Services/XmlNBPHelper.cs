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

        public void AddData(List<CurrencyDto> data)
        {
            string tableType = getTableType();
            string effectiveDate = getEffectiveDate();
            foreach (XmlNode node in xmlDoc.DocumentElement.LastChild.LastChild.ChildNodes)
            {
                if (tableType == "A" || tableType == "B")
                    data.Add(getCurrencyDto(node, effectiveDate));

                if (tableType == "C")
                    data.Add(getCurrencyDtoRange(node, effectiveDate));
            }
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

        private string getTableType() => xmlDoc.DocumentElement.LastChild.FirstChild.InnerText;
    }
}

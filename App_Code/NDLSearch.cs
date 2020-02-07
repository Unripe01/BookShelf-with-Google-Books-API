using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
/// <summary>
/// 国立国会図書館にリクエストを行うクラス
/// </summary>
public class NDLSearch
{
    const int ISBN_LENGTH10 = 10;
    const int ISBN_LENGTH13 = 13;

    public NDLSearch()
    {
        //
        // TODO: コンストラクター ロジックをここに追加します
        //
    }

    /// <summary>
    /// リクエストURL作成
    /// </summary>
    /// <param name="isbn"></param>
    /// <returns></returns>
    public string CreateRequestUrl(string isbn)
    {
        var isbnWithoutSign = isbn.Replace("-", "");
        if (isbnWithoutSign.Length != ISBN_LENGTH10
            && isbnWithoutSign.Length != ISBN_LENGTH13
            )
        {
            throw new ArgumentException("ISBNの長さ不正");
        }

        string requestUrl = string.Format(
            "http://iss.ndl.go.jp/api/sru?operation=searchRetrieve&query=isbn={0}"
            , isbn
            );
        return requestUrl;
    }



    /// <summary>
    /// リクエスト結果取得
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public XmlDocument GetResponse(string url)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(response.GetResponseStream());
        return xmlDocument;
    }

    /// <summary>
    /// リクエスト結果解析
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public Books ParseResponse(XmlDocument response, string isbn)
    {
        var bookTag = new Books();
        try
        {
            XmlNamespaceManager xmlNsManager = new XmlNamespaceManager(response.NameTable);
            xmlNsManager.AddNamespace("ns", "http://www.loc.gov/zing/srw/");

            //records
            XmlNodeList itemAttributes 
                = response.SelectNodes(
                    @"/ns:searchRetrieveResponse/ns:records/ns:record/ns:recordData"
                  , xmlNsManager);
            if (itemAttributes.Count < 1)
            {
                throw new HttpParseException("XMLノード解析：ISBN が存在しません。");
            }

            //dc まで取得して、XMLの展開をしたいが、ネームスペースとして不適切な文字が入っている事があり例外がでる。
            //ので、、、XMLとしての取得が怪しいので正規表現で全部取得する・・・
            var dcXmlstr = itemAttributes.Item(0).InnerText;
            var title = Regex.Match(dcXmlstr, @"(?<=<dc:title>).*(?=</dc:title>)").Value;
            var author = Regex.Match(dcXmlstr, @"(?<=<dc:creator>).*(?=</dc:creator>)").Value;
            var publisher = Regex.Match(dcXmlstr, @"(?<=<dc:publisher>).*(?=</dc:publisher>)").Value;

            bookTag.Author = author;
            bookTag.Disposal = false;
            bookTag.DetailPageURL = null;
            bookTag.ISBN = isbn;//取得不可なので引数をそのまま登録
            bookTag.EAN = isbn;//取得不可なので引数をそのまま登録
            bookTag.ListPrice = null;
            bookTag.Location = "";
            bookTag.PublicationDateString = "";
            bookTag.Publisher = publisher;
            bookTag.Title = title;

            bookTag.TinyImageURL = null;
            bookTag.MediumImageURL = null;

            bookTag.InsertDatetime = DateTime.Now;
            
            return bookTag;
        }
        catch ( Exception exp )
        {
            throw new HttpParseException("書籍情報が取得できない。\r\n" + exp.Message);
        }

    }

}
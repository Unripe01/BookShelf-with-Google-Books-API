using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

/// <summary>
/// GoogleBooks の概要の説明です
/// </summary>
public class GoogleBooksAPIs
{
    const int ISBN_LENGTH10 = 10;
    const int ISBN_LENGTH13 = 13;

    public GoogleBooksAPIs()
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
            "https://www.googleapis.com/books/v1/volumes?q=isbn:{0}"
            ,isbn
            );
        return requestUrl;
    }



    /// <summary>
    /// リクエスト結果取得
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public JObject GetResponse(string url)
    {
        var request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        var response_stream = response.GetResponseStream();
        var reader = new StreamReader(response_stream);
        var obj_from_json = JObject.Parse(reader.ReadToEnd());
        return obj_from_json;
    }

    /// <summary>
    /// リクエスト結果解析
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public Books ParseResponse(JObject obj_json)
    {
        Books books = new Books();

        //(arr)item の配列0個目 = object として取得
        JObject items = (JObject)obj_json["items"][0];
        books.Author = ((JArray)(items["volumeInfo"]["authors"]))[0].ToString();
        books.Disposal = false;
        books.DetailPageURL = ((JValue)(items["volumeInfo"]["infoLink"])).Value.ToString();
        books.EAN = "";
        books.ISBN = ((JValue)(items["volumeInfo"]["industryIdentifiers"][0]["identifier"])).Value.ToString();
        books.ListPrice = null;
        books.Location = "";
        books.MediumImageURL = ((JValue)(items["volumeInfo"]["imageLinks"]["thumbnail"])).Value.ToString();
        books.PublicationDateString = ((JValue)(items["volumeInfo"]["publishedDate"])).Value.ToString();
        books.Publisher = "";
        books.Title = ((JValue)(items["volumeInfo"]["title"])).Value.ToString();
        books.TinyImageURL = ((JValue)(items["volumeInfo"]["imageLinks"]["smallThumbnail"])).Value.ToString();
        
        books.InsertDatetime = DateTime.Now;

        return books;
    }


}
using System;
using System.Data.SqlClient;
using System.Web;
using System.Linq;

public partial class NDLRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        isbn.Focus();
    }

    protected void btnRegist_Click(object sender, EventArgs e)
    {
        if (this.isbn.Text.Trim().Length == 0)
        {
            return;
        }

        //DB登録用値取得
        var isbn = this.isbn.Text;
        var location = this.Location.Text;

        var ndl = new NDLSearch();
        string message;
        string status;
        try
        {
            var url = ndl.CreateRequestUrl(isbn);
            var response = ndl.GetResponse(url);
            Books booktag = ndl.ParseResponse(response, isbn);
            using (BookshelfDSDataContext db = new BookshelfDSDataContext())
            {
                var existsRecord = db.Books.FirstOrDefault(s => s.ISBN == booktag.ISBN);
                if (existsRecord == null)
                {
                    status = "新規：";
                    booktag.Location = location;
                    db.Books.InsertOnSubmit(booktag);
                }
                else
                {
                    status = "更新：";
                    //変更しそうなものだけ更新
                    existsRecord.ListPrice = booktag.ListPrice;
                    existsRecord.MediumImageURL = booktag.MediumImageURL;
                    existsRecord.TinyImageURL = booktag.TinyImageURL;
                    existsRecord.DetailPageURL = booktag.DetailPageURL;
                    existsRecord.Location = location;
                    existsRecord.Publisher = booktag.Publisher;
                    existsRecord.PublicationDateString = booktag.PublicationDateString;
                }
                db.SubmitChanges();
            }
            message = status + booktag.Title;
        }
        catch (ArgumentException ae)
        {
            this.isbn.Text = "";
            message = "◆◇◆◇エラー◆◇◆◇" + ae.Message;
        }
        catch (HttpParseException hpe)
        {
            message = "◆◇◆◇エラー◆◇◆◇" + hpe.Message;
        }
        catch (SqlException se)
        {
            message = "◆◇◆◇エラー◆◇◆◇" + se.Message;
        }
        this.isbn.Text = "";
        this.LabelMessage.Text += message + "</br>";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.LabelMessage.Text = "";
        this.isbn.Text = "";
    }
}

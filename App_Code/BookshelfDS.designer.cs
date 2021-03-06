﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Bookshelf")]
public partial class BookshelfDSDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region 拡張メソッドの定義
  partial void OnCreated();
  partial void InsertBooks(Books instance);
  partial void UpdateBooks(Books instance);
  partial void DeleteBooks(Books instance);
  #endregion
	
	public BookshelfDSDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BookshelfConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public BookshelfDSDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public BookshelfDSDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public BookshelfDSDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public BookshelfDSDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Books> Books
	{
		get
		{
			return this.GetTable<Books>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Books")]
public partial class Books : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _ISBN;
	
	private string _EAN;
	
	private string _Title;
	
	private string _PublicationDateString;
	
	private System.Nullable<decimal> _ListPrice;
	
	private string _Publisher;
	
	private string _Author;
	
	private string _DetailPageURL;
	
	private string _MediumImageURL;
	
	private string _TinyImageURL;
	
	private System.DateTime _InsertDatetime;
	
	private bool _Disposal;
	
	private string _Location;
	
    #region 拡張メソッドの定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnISBNChanging(string value);
    partial void OnISBNChanged();
    partial void OnEANChanging(string value);
    partial void OnEANChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnPublicationDateStringChanging(string value);
    partial void OnPublicationDateStringChanged();
    partial void OnListPriceChanging(System.Nullable<decimal> value);
    partial void OnListPriceChanged();
    partial void OnPublisherChanging(string value);
    partial void OnPublisherChanged();
    partial void OnAuthorChanging(string value);
    partial void OnAuthorChanged();
    partial void OnDetailPageURLChanging(string value);
    partial void OnDetailPageURLChanged();
    partial void OnMediumImageURLChanging(string value);
    partial void OnMediumImageURLChanged();
    partial void OnTinyImageURLChanging(string value);
    partial void OnTinyImageURLChanged();
    partial void OnInsertDatetimeChanging(System.DateTime value);
    partial void OnInsertDatetimeChanged();
    partial void OnDisposalChanging(bool value);
    partial void OnDisposalChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    #endregion
	
	public Books()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ISBN", DbType="NVarChar(13) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string ISBN
	{
		get
		{
			return this._ISBN;
		}
		set
		{
			if ((this._ISBN != value))
			{
				this.OnISBNChanging(value);
				this.SendPropertyChanging();
				this._ISBN = value;
				this.SendPropertyChanged("ISBN");
				this.OnISBNChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EAN", DbType="NVarChar(13)")]
	public string EAN
	{
		get
		{
			return this._EAN;
		}
		set
		{
			if ((this._EAN != value))
			{
				this.OnEANChanging(value);
				this.SendPropertyChanging();
				this._EAN = value;
				this.SendPropertyChanged("EAN");
				this.OnEANChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
	public string Title
	{
		get
		{
			return this._Title;
		}
		set
		{
			if ((this._Title != value))
			{
				this.OnTitleChanging(value);
				this.SendPropertyChanging();
				this._Title = value;
				this.SendPropertyChanged("Title");
				this.OnTitleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PublicationDateString", DbType="NVarChar(50)")]
	public string PublicationDateString
	{
		get
		{
			return this._PublicationDateString;
		}
		set
		{
			if ((this._PublicationDateString != value))
			{
				this.OnPublicationDateStringChanging(value);
				this.SendPropertyChanging();
				this._PublicationDateString = value;
				this.SendPropertyChanged("PublicationDateString");
				this.OnPublicationDateStringChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListPrice", DbType="Money")]
	public System.Nullable<decimal> ListPrice
	{
		get
		{
			return this._ListPrice;
		}
		set
		{
			if ((this._ListPrice != value))
			{
				this.OnListPriceChanging(value);
				this.SendPropertyChanging();
				this._ListPrice = value;
				this.SendPropertyChanged("ListPrice");
				this.OnListPriceChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Publisher", DbType="NVarChar(200)")]
	public string Publisher
	{
		get
		{
			return this._Publisher;
		}
		set
		{
			if ((this._Publisher != value))
			{
				this.OnPublisherChanging(value);
				this.SendPropertyChanging();
				this._Publisher = value;
				this.SendPropertyChanged("Publisher");
				this.OnPublisherChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="NVarChar(200)")]
	public string Author
	{
		get
		{
			return this._Author;
		}
		set
		{
			if ((this._Author != value))
			{
				this.OnAuthorChanging(value);
				this.SendPropertyChanging();
				this._Author = value;
				this.SendPropertyChanged("Author");
				this.OnAuthorChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DetailPageURL", DbType="NVarChar(MAX)")]
	public string DetailPageURL
	{
		get
		{
			return this._DetailPageURL;
		}
		set
		{
			if ((this._DetailPageURL != value))
			{
				this.OnDetailPageURLChanging(value);
				this.SendPropertyChanging();
				this._DetailPageURL = value;
				this.SendPropertyChanged("DetailPageURL");
				this.OnDetailPageURLChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MediumImageURL", DbType="NVarChar(MAX)")]
	public string MediumImageURL
	{
		get
		{
			return this._MediumImageURL;
		}
		set
		{
			if ((this._MediumImageURL != value))
			{
				this.OnMediumImageURLChanging(value);
				this.SendPropertyChanging();
				this._MediumImageURL = value;
				this.SendPropertyChanged("MediumImageURL");
				this.OnMediumImageURLChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TinyImageURL", DbType="NVarChar(MAX)")]
	public string TinyImageURL
	{
		get
		{
			return this._TinyImageURL;
		}
		set
		{
			if ((this._TinyImageURL != value))
			{
				this.OnTinyImageURLChanging(value);
				this.SendPropertyChanging();
				this._TinyImageURL = value;
				this.SendPropertyChanged("TinyImageURL");
				this.OnTinyImageURLChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InsertDatetime", DbType="DateTime NOT NULL")]
	public System.DateTime InsertDatetime
	{
		get
		{
			return this._InsertDatetime;
		}
		set
		{
			if ((this._InsertDatetime != value))
			{
				this.OnInsertDatetimeChanging(value);
				this.SendPropertyChanging();
				this._InsertDatetime = value;
				this.SendPropertyChanged("InsertDatetime");
				this.OnInsertDatetimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Disposal", DbType="Bit NOT NULL")]
	public bool Disposal
	{
		get
		{
			return this._Disposal;
		}
		set
		{
			if ((this._Disposal != value))
			{
				this.OnDisposalChanging(value);
				this.SendPropertyChanging();
				this._Disposal = value;
				this.SendPropertyChanged("Disposal");
				this.OnDisposalChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(50)")]
	public string Location
	{
		get
		{
			return this._Location;
		}
		set
		{
			if ((this._Location != value))
			{
				this.OnLocationChanging(value);
				this.SendPropertyChanging();
				this._Location = value;
				this.SendPropertyChanged("Location");
				this.OnLocationChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591

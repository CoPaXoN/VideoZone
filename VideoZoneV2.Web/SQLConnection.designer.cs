﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoZoneV2.Web
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="VideoZoneDB")]
	public partial class SQLConnectionDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertMessage(Message instance);
    partial void UpdateMessage(Message instance);
    partial void DeleteMessage(Message instance);
    partial void InsertSecurityQuestion(SecurityQuestion instance);
    partial void UpdateSecurityQuestion(SecurityQuestion instance);
    partial void DeleteSecurityQuestion(SecurityQuestion instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertVideoMessage(VideoMessage instance);
    partial void UpdateVideoMessage(VideoMessage instance);
    partial void DeleteVideoMessage(VideoMessage instance);
    partial void InsertVideo(Video instance);
    partial void UpdateVideo(Video instance);
    partial void DeleteVideo(Video instance);
    #endregion
		
		public SQLConnectionDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["VideoZoneDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SQLConnectionDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLConnectionDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLConnectionDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SQLConnectionDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Message> Messages
		{
			get
			{
				return this.GetTable<Message>();
			}
		}
		
		public System.Data.Linq.Table<SecurityQuestion> SecurityQuestions
		{
			get
			{
				return this.GetTable<SecurityQuestion>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<VideoMessage> VideoMessages
		{
			get
			{
				return this.GetTable<VideoMessage>();
			}
		}
		
		public System.Data.Linq.Table<viewMessage> viewMessages
		{
			get
			{
				return this.GetTable<viewMessage>();
			}
		}
		
		public System.Data.Linq.Table<vMessage> vMessages
		{
			get
			{
				return this.GetTable<vMessage>();
			}
		}
		
		public System.Data.Linq.Table<viewUsername> viewUsernames
		{
			get
			{
				return this.GetTable<viewUsername>();
			}
		}
		
		public System.Data.Linq.Table<Video> Videos
		{
			get
			{
				return this.GetTable<Video>();
			}
		}
		
		public System.Data.Linq.Table<viewSharedVideo> viewSharedVideos
		{
			get
			{
				return this.GetTable<viewSharedVideo>();
			}
		}
		
		public System.Data.Linq.Table<viewVideo> viewVideos
		{
			get
			{
				return this.GetTable<viewVideo>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Messages")]
	public partial class Message : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MsgID;
		
		private string _Subject;
		
		private string _MsgContent;
		
		private string _SentFrom;
		
		private string _SentTo;
		
		private System.Nullable<bool> _IsRead;
		
		private System.Nullable<bool> _IsDeleted;
		
		private string _SentDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMsgIDChanging(int value);
    partial void OnMsgIDChanged();
    partial void OnSubjectChanging(string value);
    partial void OnSubjectChanged();
    partial void OnMsgContentChanging(string value);
    partial void OnMsgContentChanged();
    partial void OnSentFromChanging(string value);
    partial void OnSentFromChanged();
    partial void OnSentToChanging(string value);
    partial void OnSentToChanged();
    partial void OnIsReadChanging(System.Nullable<bool> value);
    partial void OnIsReadChanged();
    partial void OnIsDeletedChanging(System.Nullable<bool> value);
    partial void OnIsDeletedChanged();
    partial void OnSentDateChanging(string value);
    partial void OnSentDateChanged();
    #endregion
		
		public Message()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MsgID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MsgID
		{
			get
			{
				return this._MsgID;
			}
			set
			{
				if ((this._MsgID != value))
				{
					this.OnMsgIDChanging(value);
					this.SendPropertyChanging();
					this._MsgID = value;
					this.SendPropertyChanged("MsgID");
					this.OnMsgIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="NChar(30)")]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this.OnSubjectChanging(value);
					this.SendPropertyChanging();
					this._Subject = value;
					this.SendPropertyChanged("Subject");
					this.OnSubjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MsgContent", DbType="NChar(900)")]
		public string MsgContent
		{
			get
			{
				return this._MsgContent;
			}
			set
			{
				if ((this._MsgContent != value))
				{
					this.OnMsgContentChanging(value);
					this.SendPropertyChanging();
					this._MsgContent = value;
					this.SendPropertyChanged("MsgContent");
					this.OnMsgContentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SentFrom", DbType="NChar(25)")]
		public string SentFrom
		{
			get
			{
				return this._SentFrom;
			}
			set
			{
				if ((this._SentFrom != value))
				{
					this.OnSentFromChanging(value);
					this.SendPropertyChanging();
					this._SentFrom = value;
					this.SendPropertyChanged("SentFrom");
					this.OnSentFromChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SentTo", DbType="NChar(25)")]
		public string SentTo
		{
			get
			{
				return this._SentTo;
			}
			set
			{
				if ((this._SentTo != value))
				{
					this.OnSentToChanging(value);
					this.SendPropertyChanging();
					this._SentTo = value;
					this.SendPropertyChanged("SentTo");
					this.OnSentToChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsRead", DbType="Bit")]
		public System.Nullable<bool> IsRead
		{
			get
			{
				return this._IsRead;
			}
			set
			{
				if ((this._IsRead != value))
				{
					this.OnIsReadChanging(value);
					this.SendPropertyChanging();
					this._IsRead = value;
					this.SendPropertyChanged("IsRead");
					this.OnIsReadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit")]
		public System.Nullable<bool> IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SentDate", DbType="NChar(25)")]
		public string SentDate
		{
			get
			{
				return this._SentDate;
			}
			set
			{
				if ((this._SentDate != value))
				{
					this.OnSentDateChanging(value);
					this.SendPropertyChanging();
					this._SentDate = value;
					this.SendPropertyChanged("SentDate");
					this.OnSentDateChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SecurityQuestions")]
	public partial class SecurityQuestion : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _SecurityQuestion1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnSecurityQuestion1Changing(string value);
    partial void OnSecurityQuestion1Changed();
    #endregion
		
		public SecurityQuestion()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="SecurityQuestion", Storage="_SecurityQuestion1", DbType="NChar(50)")]
		public string SecurityQuestion1
		{
			get
			{
				return this._SecurityQuestion1;
			}
			set
			{
				if ((this._SecurityQuestion1 != value))
				{
					this.OnSecurityQuestion1Changing(value);
					this.SendPropertyChanging();
					this._SecurityQuestion1 = value;
					this.SendPropertyChanged("SecurityQuestion1");
					this.OnSecurityQuestion1Changed();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Username;
		
		private string _Email;
		
		private string _Password;
		
		private string _DateOfBirth;
		
		private string _Address;
		
		private string _PhoneNumber;
		
		private System.Nullable<int> _SecurityQuestionId;
		
		private string _Answer;
		
		private System.Nullable<bool> _IsAdmin;
		
		private System.Nullable<bool> _IsBanned;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnDateOfBirthChanging(string value);
    partial void OnDateOfBirthChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnPhoneNumberChanging(string value);
    partial void OnPhoneNumberChanged();
    partial void OnSecurityQuestionIdChanging(System.Nullable<int> value);
    partial void OnSecurityQuestionIdChanged();
    partial void OnAnswerChanging(string value);
    partial void OnAnswerChanged();
    partial void OnIsAdminChanging(System.Nullable<bool> value);
    partial void OnIsAdminChanged();
    partial void OnIsBannedChanging(System.Nullable<bool> value);
    partial void OnIsBannedChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NChar(25) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOfBirth", DbType="NChar(15)")]
		public string DateOfBirth
		{
			get
			{
				return this._DateOfBirth;
			}
			set
			{
				if ((this._DateOfBirth != value))
				{
					this.OnDateOfBirthChanging(value);
					this.SendPropertyChanging();
					this._DateOfBirth = value;
					this.SendPropertyChanged("DateOfBirth");
					this.OnDateOfBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NChar(100)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="NChar(11)")]
		public string PhoneNumber
		{
			get
			{
				return this._PhoneNumber;
			}
			set
			{
				if ((this._PhoneNumber != value))
				{
					this.OnPhoneNumberChanging(value);
					this.SendPropertyChanging();
					this._PhoneNumber = value;
					this.SendPropertyChanged("PhoneNumber");
					this.OnPhoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SecurityQuestionId", DbType="Int")]
		public System.Nullable<int> SecurityQuestionId
		{
			get
			{
				return this._SecurityQuestionId;
			}
			set
			{
				if ((this._SecurityQuestionId != value))
				{
					this.OnSecurityQuestionIdChanging(value);
					this.SendPropertyChanging();
					this._SecurityQuestionId = value;
					this.SendPropertyChanged("SecurityQuestionId");
					this.OnSecurityQuestionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Answer", DbType="NChar(50)")]
		public string Answer
		{
			get
			{
				return this._Answer;
			}
			set
			{
				if ((this._Answer != value))
				{
					this.OnAnswerChanging(value);
					this.SendPropertyChanging();
					this._Answer = value;
					this.SendPropertyChanged("Answer");
					this.OnAnswerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAdmin", DbType="Bit")]
		public System.Nullable<bool> IsAdmin
		{
			get
			{
				return this._IsAdmin;
			}
			set
			{
				if ((this._IsAdmin != value))
				{
					this.OnIsAdminChanging(value);
					this.SendPropertyChanging();
					this._IsAdmin = value;
					this.SendPropertyChanged("IsAdmin");
					this.OnIsAdminChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsBanned", DbType="Bit")]
		public System.Nullable<bool> IsBanned
		{
			get
			{
				return this._IsBanned;
			}
			set
			{
				if ((this._IsBanned != value))
				{
					this.OnIsBannedChanging(value);
					this.SendPropertyChanging();
					this._IsBanned = value;
					this.SendPropertyChanged("IsBanned");
					this.OnIsBannedChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VideoMessages")]
	public partial class VideoMessage : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _VideoName;
		
		private string _UserUploaded;
		
		private string _Publisher;
		
		private string _PostContent;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnVideoNameChanging(string value);
    partial void OnVideoNameChanged();
    partial void OnUserUploadedChanging(string value);
    partial void OnUserUploadedChanged();
    partial void OnPublisherChanging(string value);
    partial void OnPublisherChanged();
    partial void OnPostContentChanging(string value);
    partial void OnPostContentChanged();
    #endregion
		
		public VideoMessage()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VideoName", DbType="NChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string VideoName
		{
			get
			{
				return this._VideoName;
			}
			set
			{
				if ((this._VideoName != value))
				{
					this.OnVideoNameChanging(value);
					this.SendPropertyChanging();
					this._VideoName = value;
					this.SendPropertyChanged("VideoName");
					this.OnVideoNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserUploaded", DbType="NChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string UserUploaded
		{
			get
			{
				return this._UserUploaded;
			}
			set
			{
				if ((this._UserUploaded != value))
				{
					this.OnUserUploadedChanging(value);
					this.SendPropertyChanging();
					this._UserUploaded = value;
					this.SendPropertyChanged("UserUploaded");
					this.OnUserUploadedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Publisher", DbType="NChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostContent", DbType="NChar(999)")]
		public string PostContent
		{
			get
			{
				return this._PostContent;
			}
			set
			{
				if ((this._PostContent != value))
				{
					this.OnPostContentChanging(value);
					this.SendPropertyChanging();
					this._PostContent = value;
					this.SendPropertyChanged("PostContent");
					this.OnPostContentChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.viewMessage")]
	public partial class viewMessage
	{
		
		private int _MsgID;
		
		private string _Subject;
		
		private string _MsgContent;
		
		private string _SentFrom;
		
		public viewMessage()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MsgID", DbType="Int NOT NULL")]
		public int MsgID
		{
			get
			{
				return this._MsgID;
			}
			set
			{
				if ((this._MsgID != value))
				{
					this._MsgID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="NChar(30)")]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this._Subject = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MsgContent", DbType="NChar(900)")]
		public string MsgContent
		{
			get
			{
				return this._MsgContent;
			}
			set
			{
				if ((this._MsgContent != value))
				{
					this._MsgContent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SentFrom", DbType="NChar(25)")]
		public string SentFrom
		{
			get
			{
				return this._SentFrom;
			}
			set
			{
				if ((this._SentFrom != value))
				{
					this._SentFrom = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vMessages")]
	public partial class vMessage
	{
		
		private int _MsgID;
		
		private string _Subject;
		
		private string _SentFrom;
		
		private string _SentTo;
		
		private string _SentDate;
		
		public vMessage()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MsgID", DbType="Int NOT NULL")]
		public int MsgID
		{
			get
			{
				return this._MsgID;
			}
			set
			{
				if ((this._MsgID != value))
				{
					this._MsgID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subject", DbType="NChar(30)")]
		public string Subject
		{
			get
			{
				return this._Subject;
			}
			set
			{
				if ((this._Subject != value))
				{
					this._Subject = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SentFrom", DbType="NChar(25)")]
		public string SentFrom
		{
			get
			{
				return this._SentFrom;
			}
			set
			{
				if ((this._SentFrom != value))
				{
					this._SentFrom = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SentTo", DbType="NChar(25)")]
		public string SentTo
		{
			get
			{
				return this._SentTo;
			}
			set
			{
				if ((this._SentTo != value))
				{
					this._SentTo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SentDate", DbType="NChar(25)")]
		public string SentDate
		{
			get
			{
				return this._SentDate;
			}
			set
			{
				if ((this._SentDate != value))
				{
					this._SentDate = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.viewUsernames")]
	public partial class viewUsername
	{
		
		private string _Username;
		
		public viewUsername()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NChar(25) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this._Username = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Videos")]
	public partial class Video : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _VideoName;
		
		private string _Username;
		
		private string _FilePath;
		
		private string _Category;
		
		private string _SharedTo;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnVideoNameChanging(string value);
    partial void OnVideoNameChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnFilePathChanging(string value);
    partial void OnFilePathChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnSharedToChanging(string value);
    partial void OnSharedToChanged();
    #endregion
		
		public Video()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VideoName", DbType="NChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string VideoName
		{
			get
			{
				return this._VideoName;
			}
			set
			{
				if ((this._VideoName != value))
				{
					this.OnVideoNameChanging(value);
					this.SendPropertyChanging();
					this._VideoName = value;
					this.SendPropertyChanged("VideoName");
					this.OnVideoNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NChar(25) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FilePath", DbType="NChar(50)")]
		public string FilePath
		{
			get
			{
				return this._FilePath;
			}
			set
			{
				if ((this._FilePath != value))
				{
					this.OnFilePathChanging(value);
					this.SendPropertyChanging();
					this._FilePath = value;
					this.SendPropertyChanged("FilePath");
					this.OnFilePathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NChar(30)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SharedTo", DbType="NChar(999)")]
		public string SharedTo
		{
			get
			{
				return this._SharedTo;
			}
			set
			{
				if ((this._SharedTo != value))
				{
					this.OnSharedToChanging(value);
					this.SendPropertyChanging();
					this._SharedTo = value;
					this.SendPropertyChanged("SharedTo");
					this.OnSharedToChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.viewSharedVideos")]
	public partial class viewSharedVideo
	{
		
		private string _VideoName;
		
		private string _Username;
		
		private string _Category;
		
		private string _SharedTo;
		
		public viewSharedVideo()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VideoName", DbType="NChar(25) NOT NULL", CanBeNull=false)]
		public string VideoName
		{
			get
			{
				return this._VideoName;
			}
			set
			{
				if ((this._VideoName != value))
				{
					this._VideoName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NChar(25) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this._Username = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NChar(30)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this._Category = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SharedTo", DbType="NChar(999)")]
		public string SharedTo
		{
			get
			{
				return this._SharedTo;
			}
			set
			{
				if ((this._SharedTo != value))
				{
					this._SharedTo = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.viewVideos")]
	public partial class viewVideo
	{
		
		private string _VideoName;
		
		private string _Username;
		
		private string _Category;
		
		private string _SharedTo;
		
		public viewVideo()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VideoName", DbType="NChar(25) NOT NULL", CanBeNull=false)]
		public string VideoName
		{
			get
			{
				return this._VideoName;
			}
			set
			{
				if ((this._VideoName != value))
				{
					this._VideoName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NChar(25) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this._Username = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NChar(30)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this._Category = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SharedTo", DbType="NChar(999)")]
		public string SharedTo
		{
			get
			{
				return this._SharedTo;
			}
			set
			{
				if ((this._SharedTo != value))
				{
					this._SharedTo = value;
				}
			}
		}
	}
}
#pragma warning restore 1591

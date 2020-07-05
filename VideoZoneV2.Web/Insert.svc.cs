using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;

namespace VideoZoneV2.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Insert" in code, svc and config file together.
    [ServiceContract]
    public class Insert
    {
        [OperationContract]
        public void InsertData(string user, string pass, string email, string dob, string address, string phoneNumber, int securityQuestionId, string answer)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User row = new User()
            {
                Username = user,
                Password = pass,
                Email = email,
                DateOfBirth = dob,
                Address = address,
                PhoneNumber = phoneNumber,
                SecurityQuestionId = securityQuestionId,
                Answer = answer,
                IsAdmin = false,
                IsBanned = false,
            };
            db.Users.InsertOnSubmit(row);
            try
            {
                db.SubmitChanges();
            }
            catch{ }
        }
        [OperationContract]
        public int findUsername(string str)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            var flag = from usr in db.Users
                       where usr.Username == str
                       select usr;
            return flag.Count();
        }
        [OperationContract]
        public int findEmail(string str)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            var flag = from usr in db.Users
                       where usr.Email == str
                       select usr;
            return flag.Count();
        }
        [OperationContract]
        public int findVideoName(string videoName)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            var flag = from usr in db.Videos
                       where usr.VideoName == videoName
                       select usr;
            return flag.Count();
        }
        [OperationContract]
        public bool UpdData(string email, string username, string password, string dob, string address, string phoneNumber)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User row = db.Users.Single(p => p.Email == email);
            row.Username = username;
            row.Password = password;
            row.DateOfBirth = dob;
            row.Address = address;
            row.PhoneNumber = phoneNumber;
            db.SubmitChanges();
            return true;
        }
        [OperationContract]

        public string Select(string email)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User row;
            try
            {
                row = db.Users.Select(e => e).Where(user => user.Email == email).First();
                string aa = row.Username.ToString();
                aa += "," + row.Email.Trim().ToString();
                aa += "," + row.Password.Trim().ToString();
                aa += "," + row.DateOfBirth.Trim().ToString();
                aa += "," + row.Address.Trim().ToString();
                aa += "," + row.PhoneNumber.Trim().ToString();
                return aa;
            }
            catch{ return "Wrong email"; }
        }
        [OperationContract]
        public string SelectAnswer(string email)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User usr;
            SecurityQuestion sq;
            try
            {
                usr = db.Users.Select(e => e).Where(user => user.Email == email).First();
                string usrAns = usr.Answer.TrimEnd().ToString();
                int usrSq = int.Parse(usr.SecurityQuestionId.ToString());
                sq = db.SecurityQuestions.Select(e => e).Where(d => d.Id == usrSq).First();
                string SqSq = sq.SecurityQuestion1.Trim().ToString();
                return usrAns.TrimEnd()+","+SqSq.TrimEnd();
            }
            catch { return "Wrong email"; }
        }
        [OperationContract]
        public void ResetPassword(string email, string newPass)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User usr;
            usr = db.Users.Select(e => e).Where(user => user.Email == email).First();
            usr.Password = newPass.ToString();
            db.SubmitChanges();
        }
        [OperationContract]
        public string SelectByUsername(string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User row;
            try
            {
                row = db.Users.Select(e => e).Where(user => user.Username == username).First();
                string aa = row.Username.ToString();
                aa += "," + row.Email.Trim().ToString();
                aa += "," + row.Password.Trim().ToString();
                aa += "," + row.DateOfBirth.Trim().ToString();
                aa += "," + row.Address.Trim().ToString();
                aa += "," + row.PhoneNumber.Trim().ToString();
                return aa;
            }
            catch{ return "Wrong email"; }
        }
        [OperationContract]
        public bool SignIn(string email, string password)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User row;
            try
            {
                row = db.Users.Select(e => e).Where(user => user.Email == email).First();
                if (row.Password.Trim().ToString() == password.Trim().ToString())
                    return true;
                return false;
            }
            catch{ return false; }
        }
        [OperationContract]
        public bool Delete(string email)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            var query = from p in db.Users
                        where p.Email.Contains(email)
                        select p;
            db.Users.DeleteAllOnSubmit(query);
            db.SubmitChanges();
            return true;
        }
        [OperationContract]
        public List<Message> SelectMsgs(string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            List<Message> row;
            row = (db.Messages.Select(e => e).Where(p => (p.SentFrom == username || p.SentTo == username) && p.IsDeleted == false)).ToList();
            return row;
        }
        [OperationContract]
        public List<vMessage> SelectViewMsgs(string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            List<vMessage> row;
            row = (db.vMessages.Select(e => e).Where(p => (p.SentFrom == username || p.SentTo == username))).ToList();
            return row;
        }
        [OperationContract]
        public int SelectLastMsgId()
        {

            SQLConnectionDataContext db = new SQLConnectionDataContext();
            Message row;
            try
            {
                row = db.Messages.Select(e => e).Where(p => p.MsgID == p.MsgID).First();
                int aa = row.MsgID;
                return aa - 1;
            }
            catch{ return 0; }
        }
        [OperationContract]
        public void SendMsg(string subject, string msgContent,
            string sentFrom, string sentTo, string SentDate)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            Message row = new Message()
            {
                MsgID = SelectLastMsgId(),
                Subject = subject,
                MsgContent = msgContent,
                SentFrom = sentFrom,
                SentTo = sentTo,
                SentDate = SentDate,
                IsDeleted = false,
                IsRead = false,
            };

            db.Messages.InsertOnSubmit(row);
            try
            {
                db.SubmitChanges();
            }
            catch{ }
        }
        [OperationContract]
        public void DeleteMsg(int msgID)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            var query = from p in db.Messages
                        where p.MsgID == msgID
                        select p;
            db.Messages.DeleteAllOnSubmit(query);
            db.SubmitChanges();
        }
        [OperationContract]
        public void DeleteMsgs(string selectedItemsToDelete)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            string d = selectedItemsToDelete;
            int count = 0;
            foreach (char c in d)
            {
                if (c == ',')
                    count++;
            }
            for (int i = 0; i < count; i++)
            {
                DeleteMsg(int.Parse(d.Substring(0, d.IndexOf(","))));
                d = d.Remove(0, d.IndexOf(",") + 1);
            }
        }
        [OperationContract]
        public string SelectMsg(int msgID)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();

            viewMessage row;
            row = db.viewMessages.Select(e => e).Where(e => e.MsgID == msgID).First();
            Message r = db.Messages.Single(p => p.MsgID == msgID);
            r.IsRead = true;
            db.SubmitChanges();
            return row.SentFrom.ToString().Trim() + ","
                + row.Subject.ToString().Trim() + "," + row.MsgContent.ToString().Trim();
        }
        [OperationContract]
        public int CountUnreadedMsgs(string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            List<Message> row;
            row = (db.Messages.Select(e => e).Where(p => p.SentTo == username && p.IsRead == false)).ToList();
            return row.Count();
        }
        [OperationContract]
        public string isUsernamesExist(string usernames) 
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            User row = null;
            string u = usernames;
            string s = "";
            if (u[u.Length - 1] != ',')
            {
                u += ',';
            }
            int j = u.Count(p => p == ',');
            for (int i = 0; i < j; i++)
            {
                try
                {
                    row = db.Users.Select(e => e).Where(p => p.Username == u.Substring(0, u.IndexOf(',')).Trim()).First();
                }
                catch{ }
                if (row != null)
                {
                    u = u.Remove(0, u.IndexOf(",") +1);
                }
                else
                {
                    s += u.Substring(0, u.IndexOf(","))+", ";
                    u = u.Remove(0, u.IndexOf(",")+1);
                }
                row = null;
            }
            return s; 
        }
        [OperationContract]
        public bool findVideo(string videoname, string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            Video row = null;
            try
            {
                row = db.Videos.Select(e => e).Where(p => p.VideoName.Trim() == videoname && p.Username.Trim() == username).First();
            }
            catch { }
            if (row != null)
                return true;
            return false;
        }
        [OperationContract]
        public string SelectVideo(string videoname, string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            Video row;
            row = (db.Videos.Select(e => e).Where(p => p.VideoName == videoname && p.Username == username)).First();
            string result = "";
            result = row.FilePath.Trim() + "," + row.Category.Trim() + "," + row.SharedTo.Trim();
            return result;
        }
        [OperationContract]
        public void DeleteVideo(string videoname, string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            var query = from p in db.Videos
                        where p.VideoName.Contains(videoname) && p.Username.Contains(username)
                        select p;
            db.Videos.DeleteAllOnSubmit(query);
            db.SubmitChanges();     
        }
        [OperationContract]
        public List<viewSharedVideo> SelectSharedVideos(string username)
        {
            List<viewSharedVideo> rows;
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            rows = (db.viewSharedVideos.Select(e=>e).Where(p=>p.SharedTo.Contains(username))).ToList();
            foreach (viewSharedVideo row in rows.ToList())
            {
                row.SharedTo = row.SharedTo.Trim();
                row.Category = row.Category.Trim();
                row.Username = row.Username.Trim();
                row.VideoName = row.VideoName.Trim();
            }
            return rows;
        }
        [OperationContract]
        public List<viewVideo> SelectVideos(string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            List<viewVideo> rows;
            rows = (db.viewVideos.Select(e => e).Where(p => p.Username == username)).ToList();
            foreach (viewVideo row in rows.ToList())
            {
                row.SharedTo = row.SharedTo.Trim();
                row.Category = row.Category.Trim();
                row.Username = row.Username.Trim();
                row.VideoName = row.VideoName.Trim();
            }
            return rows;
        }
        [OperationContract]
        public void UpdateVideo(string videoname, string username, string category, string sharedTo)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            Video row;
            row = (db.Videos.Select(e => e).Where(p => p.VideoName == videoname && p.Username == username)).First();
            row.VideoName = videoname;
            row.Category = category;
            row.SharedTo = sharedTo;
            db.SubmitChanges();
        }
        
        [OperationContract]
        public List<viewVideo> SearchVideos(string videoname)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            List<viewVideo> rows;
            rows = (db.viewVideos.Select(e => e).Where(p => (p.VideoName == videoname || 
                p.VideoName.Contains(videoname) || p.VideoName.StartsWith(videoname) || 
                p.VideoName.EndsWith(videoname))&& p.SharedTo.Trim() == "everyone" )).ToList();
            foreach(viewVideo row in rows.ToList())
            {
                row.SharedTo = row.SharedTo.Trim();
                row.Category = row.Category.Trim();
                row.Username = row.Username.Trim();
                row.VideoName = row.VideoName.Trim();
            }
            return rows;
        }
        [OperationContract]
        public List<viewUsername> SearchUsers(string username)
        {
            SQLConnectionDataContext db = new SQLConnectionDataContext();
            List<viewUsername> rows;
            rows = (db.viewUsernames.Select(e => e).Where(p => p.Username == username ||
                p.Username.Contains(username) || p.Username.StartsWith(username) ||
                p.Username.EndsWith(username))).ToList();
            return rows;
        }   
    }
}

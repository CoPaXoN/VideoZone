using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using VideoZoneV2.Validations;

namespace VideoZoneV2.Validations
{
    public class BindingModel : BindingModelBase<BindingModel>
    {
        private string _newPassword;
        private string _newPasswordConfirmation;
        private string username;
        

        public DelegeteCommand ChangePasswordCommand { get; private set; }

        public BindingModel()
        {
            ChangePasswordCommand = new DelegeteCommand(ChangePassword);

            AddAllAttributeValidators();

            AddValidationFor(() => NewPasswordConfirmation)
                .When(x => !string.IsNullOrEmpty(x._newPassword) && string.CompareOrdinal(x._newPassword, x._newPasswordConfirmation) != 0)
                .Show("Password confirmation not equal to password.");
        }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Password must be between 3-15.", MinimumLength = 3)]
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnCurrentPropertyChanged();
            }
        }

        [Display(Name = "Username: ")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, ErrorMessage = "Username must be between 3-15.", MinimumLength = 3)]
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnCurrentPropertyChanged();
            }
        }

        string fname;
        [Display(Name = "First name: ")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(15, ErrorMessage = "First name must be between 3-15.", MinimumLength = 3)]
        public string Firstname
        {
            get { return fname; }
            set
            {
                fname = value;
                OnCurrentPropertyChanged();
            }
        }

        string subject;
        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(30, ErrorMessage = "Subject must be between 3-30.", MinimumLength = 3)]
        public string Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                OnCurrentPropertyChanged();
            }
        }

        string content;
        [Display(Name = "Content")]
        [Required(ErrorMessage = "Content is required")]
        [StringLength(500, ErrorMessage = "Content must be between 5-500.", MinimumLength = 5)]
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnCurrentPropertyChanged();
            }
        }

        [Display(Name = "New password confirmation")]
        public string NewPasswordConfirmation
        {
            get { return _newPasswordConfirmation; }
            set
            {
                _newPasswordConfirmation = value;
                OnCurrentPropertyChanged();
            }
        }

        string email;
        //string pat = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"+@"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"+ @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", ErrorMessage = "Wrong email")]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnCurrentPropertyChanged();
            }
        }

        private void ChangePassword(object obj)
        {
            ValidateAll();

            if (!HasErrors)
            {
                System.Windows.MessageBox.Show("Bingo!");
            }
        }
        string dob;
        [Display(Name = "dob")]
        [Required(ErrorMessage = "Date of birth is required")]      
        public string Dob
        {
            get { return dob; }
            set
            {
                dob = value;
                OnCurrentPropertyChanged();
            }
        }
        string address;
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50,ErrorMessage = "Adress must be between 5-50.",MinimumLength = 5)]

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnCurrentPropertyChanged();
            }
        }
        string phoneNumber;
        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(7, ErrorMessage = "Phone Number must be 7 characters length.", MinimumLength = 7)]
        [RegularExpression("[0-9]+", ErrorMessage = "Numbers Only")]

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnCurrentPropertyChanged();
            }
        }
        string answer;
        [Display(Name = "Answer")]
        [Required(ErrorMessage = "Answer is required")]
        [StringLength(50, ErrorMessage = "answer must be between 3-50.", MinimumLength = 3)]

        public string Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                OnCurrentPropertyChanged();
            }
        }
        string videoName;
        [Display(Name = "Video Name: ")]
        [Required(ErrorMessage = " is required")]
        [StringLength(25, ErrorMessage = " must be between 3-25.", MinimumLength = 3)]

        public string VideoName
        {
            get { return videoName; }
            set
            {
                videoName = value;
                OnCurrentPropertyChanged();
            }
        }   
    }
}


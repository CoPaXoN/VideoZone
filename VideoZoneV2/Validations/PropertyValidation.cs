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

namespace VideoZoneV2.Validations
{
    public class PropertyValidation<TBindingModel>
        where TBindingModel : BindingModelBase<TBindingModel>
    {
        private Func<TBindingModel, bool> _validationCriteria;
        private string _errorMessage;
        private readonly string _propertyName;

        public PropertyValidation(string propertyName)
        {
            _propertyName = propertyName;
        }

        public PropertyValidation<TBindingModel> When(Func<TBindingModel, bool> validationCriteria)
        {
            if (_validationCriteria != null)
                throw new InvalidOperationException("You can only set the validation criteria once.");

            _validationCriteria = validationCriteria;
            return this;
        }

        public PropertyValidation<TBindingModel> Show(string errorMessage)
        {
            if (_errorMessage != null)
                throw new InvalidOperationException("You can only set the message once.");

            _errorMessage = errorMessage;
            return this;
        }

        public bool IsInvalid(TBindingModel presentationModel)
        {
            if (_validationCriteria == null)
                throw new InvalidOperationException(
                    "No criteria have been provided for this validation. (Use the 'When(..)' method.)");

            return _validationCriteria(presentationModel);
        }

        public string GetErrorMessage()
        {
            if (_errorMessage == null)
                throw new InvalidOperationException(
                    "No error message has been set for this validation. (Use the 'Show(..)' method.)");

            return _errorMessage;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
}
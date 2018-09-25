using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace Carsale.DAO.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfOtherEquals : ValidationAttribute
    {
        public string OtherProperty { get; private set; }
        public string OtherPropertyDisplayName { get; set; }
        public object OtherPropertyValue { get; private set; }
        public bool IsInverted { get; set; }

        public override bool RequiresValidationContext => true;

        public RequiredIfOtherEquals(string otherProperty, object otherPropertyValue) : base("'{0}' is required because '{1}' has a value {3}'{2}'.")
        {
            OtherProperty = otherProperty;
            OtherPropertyValue = otherPropertyValue;
            IsInverted = false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            PropertyInfo otherProperty = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherProperty == null)
            {
                return new ValidationResult(
                    string.Format(CultureInfo.CurrentCulture, "Could not find a property named '{0}'.", OtherProperty));
            }

            object otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

            // check if this value is actually required and validate it
            if (!IsInverted && object.Equals(otherValue, this.OtherPropertyValue) ||
                IsInverted && !object.Equals(otherValue, this.OtherPropertyValue))
            {
                if (value == null)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }

                // additional check for strings so they're not empty
                string val = value as string;
                if (val != null && val.Trim().Length == 0)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                base.ErrorMessageString,
                name,
                this.OtherPropertyDisplayName ?? this.OtherProperty,
                this.OtherPropertyValue,
                this.IsInverted ? "other than " : "of ");
        }
    }
}

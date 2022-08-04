using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 建议65_Win
{
    public class UIModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            OnPropertyChanged(propertyName);
        }

        public virtual void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>
        /// True if the property was set.
        /// </returns>
        /// <remarks>This method uses the CallerMemberNameAttribute to determine the property name.</remarks>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            // ReSharper disable once RedundantNameQualifier
            if (Equals(field, value))
            {
                return false;
            }
            VerifyProperty(propertyName);
            //// this.OnPropertyChanging(propertyName, field, value);
            var oldValue = field;
            field = value;
            OnPropertyChanged(propertyName, oldValue, value);
            return true;
        }

        /// <summary>
        /// Verifies the property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [Conditional("DEBUG")]
        private void VerifyProperty(string propertyName)
        {
            var type = GetType();

            // Look for a public property with the specified name.
            var propertyInfo = type.GetTypeInfo().GetDeclaredProperty(propertyName);

            Debug.Assert(propertyInfo != null, string.Format(CultureInfo.InvariantCulture, "{0} is not a property of {1}", propertyName, type.FullName));
        }
    }
}
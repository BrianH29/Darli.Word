﻿using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Darli.Word
{
    /// <summary>
    /// A base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">the type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        #region Private Members
        /// <summary>
        /// A single static instance of this value converter
        /// </summary>
        private static T mConverter = null; 
        #endregion

        #region Markup Extension Methods

        /// <summary>
        /// Provides static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The Service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        } 
        #endregion

        #region Value Converter Methods
        /// <summary>
        /// The method to converter one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        /// <summary>
        /// The method to convert a value back to its source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture); 
        #endregion
    }
}

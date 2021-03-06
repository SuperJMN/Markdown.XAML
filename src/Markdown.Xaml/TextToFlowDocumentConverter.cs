﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Markdown.Xaml
{
    public class TextToFlowDocumentConverter : DependencyObject, IValueConverter
    {
        public MarkdownEngine MarkdownEngine
        {
            get { return (MarkdownEngine)GetValue(MarkdownEngineProperty); }
            set { SetValue(MarkdownEngineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Markdown.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarkdownEngineProperty =
            DependencyProperty.Register("MarkdownEngine", typeof(MarkdownEngine), typeof(TextToFlowDocumentConverter), new PropertyMetadata(null));

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }

            var text = (string)value;

            var engine = MarkdownEngine ?? mMarkdown.Value;

            return engine.Transform(text);
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private readonly Lazy<MarkdownEngine> mMarkdown
            = new Lazy<MarkdownEngine>(() => new MarkdownEngine());
    }
}

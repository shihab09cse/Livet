﻿//このコードはT4 Templateによって自動生成されています。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Windows.Interop;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Annotations;
using System.Windows.Ink;
using System.Windows.Automation.Peers;
using System.Windows.Markup.Localizer;
using System.Windows.Media.Imaging;
using System.IO.Packaging;
using System.Security.RightsManagement;
using System.Windows.Threading;
using System.Windows.Media.Effects;
using System.Windows.Shell;
using System.Security.Permissions;
using System.Windows.Annotations.Storage;
using System.Diagnostics;

namespace Livet.Converters
{
	/// <summary>
    /// TextCollapsingStyle列挙体とbool値の相互変換を行うIValueConverterです。
    /// </summary>
    public class TextCollapsingStyleAndBooleanConverter : IValueConverter
    {
        //VM→View
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool)) throw new ArgumentException();

            if ((bool)value)
            {
                if (_isConvertWhenTrueSet)
                {
                    return ConvertWhenTrue;
                }
            }
            else
            {
                if (_isConvertWhenFalseSet)
                {
                    return ConvertWhenFalse;
                }
            }

            return DependencyProperty.UnsetValue;
        }

        private bool _isConvertWhenTrueSet;
        private TextCollapsingStyle _convertWhenTrue;
		/// <summary>
        /// ソース値がTrueの際にどのTextCollapsingStyle列挙体メンバーに変換するかを指定、または取得します。
        /// </summary>
        public TextCollapsingStyle ConvertWhenTrue
        {
            get
            {
                return _convertWhenTrue;
            }
            set
            {
                _convertWhenTrue = value;
                _isConvertWhenTrueSet = true;
            }
        }

        private bool _isConvertWhenFalseSet;
        private TextCollapsingStyle _convertWhenFalse;
		/// <summary>
        /// ソース値がFalseの際にどのTextCollapsingStyle列挙体メンバーに変換するかを指定、または取得します。
        /// </summary>
        public TextCollapsingStyle ConvertWhenFalse
        {
            get
            {
                return _convertWhenFalse;
            }
            set
            {
                _convertWhenFalse = value;
                _isConvertWhenFalseSet = true;
            }
        }

        //View→VM
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is TextCollapsingStyle)) throw new ArgumentException();

            var enumValue = (TextCollapsingStyle)value;

			switch(enumValue.ToString())
			{
				case "TrailingCharacter":
					if (_isConvertBackWhenTrailingCharacterSet)
					{
						return ConvertBackWhenTrailingCharacter;
					}
					break;
				case "TrailingWord":
					if (_isConvertBackWhenTrailingWordSet)
					{
						return ConvertBackWhenTrailingWord;
					}
					break;
				default:
					throw new ArgumentException();
			}

            if (_isConvertBackDefaultBooleanValueSet)
            {
                return ConvertBackDefaultBooleanValue;
            }

            return DependencyProperty.UnsetValue;
        }

        private bool _isConvertBackDefaultBooleanValueSet;
        private bool _convertBackDefaultBooleanValue;
		/// <summary>
        /// TextCollapsingStyleの値をbool値に変換する際のデフォルト値を指定、または取得します。
        /// </summary>
        public bool ConvertBackDefaultBooleanValue
        {
            get
            {
                return _convertBackDefaultBooleanValue;
            }
            set
            {
                _convertBackDefaultBooleanValue = value;
				_isConvertBackDefaultBooleanValueSet = true;
            }
        }

        private bool _isConvertBackWhenTrailingCharacterSet;
        private bool _convertBackWhenTrailingCharacter;
		/// <summary>
        /// TextCollapsingStyleの値がTrailingCharacterの際True/Falseいずれに変換するのかを指定、または取得します。<br/>
        /// この値が設定されておらず、ConvertBackDefaultBooleanValueが設定されている場合はConvertBackDefaultBooleanValueに従います。
        /// </summary>
        public bool ConvertBackWhenTrailingCharacter
        {
            get
            {
                return _convertBackWhenTrailingCharacter;
            }
            set
            {
                _convertBackWhenTrailingCharacter = value;
                _isConvertBackWhenTrailingCharacterSet = true;
            }
        }
        private bool _isConvertBackWhenTrailingWordSet;
        private bool _convertBackWhenTrailingWord;
		/// <summary>
        /// TextCollapsingStyleの値がTrailingWordの際True/Falseいずれに変換するのかを指定、または取得します。<br/>
        /// この値が設定されておらず、ConvertBackDefaultBooleanValueが設定されている場合はConvertBackDefaultBooleanValueに従います。
        /// </summary>
        public bool ConvertBackWhenTrailingWord
        {
            get
            {
                return _convertBackWhenTrailingWord;
            }
            set
            {
                _convertBackWhenTrailingWord = value;
                _isConvertBackWhenTrailingWordSet = true;
            }
        }
    }
}
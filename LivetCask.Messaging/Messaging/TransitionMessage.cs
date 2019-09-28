﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using Livet.Annotations;

namespace Livet.Messaging
{
    /// <summary>
    ///     画面遷移アクション用の相互作用メッセージです。
    /// </summary>
    [ContentProperty("TransitionViewModel")]
    public class TransitionMessage : ResponsiveInteractionMessage<bool?>
    {
        // Using a DependencyProperty as the backing store for TransitionViewModel.  This enables animation, styling, binding, etc...
        [NotNull] public static readonly DependencyProperty TransitionViewModelProperty =
            DependencyProperty.Register("TransitionViewModel", typeof(INotifyPropertyChanged), typeof(TransitionMessage),
                new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for Mode.  This enables animation, styling, binding, etc...
        [NotNull] public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(TransitionMode), typeof(TransitionMessage),
                new PropertyMetadata(TransitionMode.UnKnown));

        // Using a DependencyProperty as the backing store for WindowType.  This enables animation, styling, binding, etc...
        [NotNull] public static readonly DependencyProperty WindowTypeProperty =
            DependencyProperty.Register("WindowType", typeof(Type), typeof(TransitionMessage),
                new PropertyMetadata(null));

        public TransitionMessage() { }

        /// <summary>
        ///     メッセージキーを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="messageKey">メッセージキー</param>
        public TransitionMessage(string messageKey) : base(messageKey) { }

        /// <summary>
        ///     新しいWindowのDataContextに設定するViewModelとメッセージキーを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="transitionViewModel">新しいWindowのDataContextに設定するViewModel</param>
        /// <param name="messageKey">メッセージキー</param>
        public TransitionMessage(INotifyPropertyChanged transitionViewModel, string messageKey)
            : this(null, transitionViewModel, TransitionMode.UnKnown, messageKey) { }

        /// <summary>
        ///     新しいWindowのDataContextに設定するViewModelと画面遷移モードとメッセージキーを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="transitionViewModel">新しいWindowのDataContextに設定するViewModel</param>
        /// <param name="mode">画面遷移の方法を決定するTransitionMode列挙体。初期値はUnKnownです。</param>
        /// <param name="messageKey">メッセージキー</param>
        public TransitionMessage(INotifyPropertyChanged transitionViewModel, TransitionMode mode, string messageKey)
            : this(null, transitionViewModel, mode, messageKey) { }

        /// <summary>
        ///     新しいWindowの型と新しいWindowに設定するViewModel、画面遷移モードとメッセージキーを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="windowType">新しいWindowの型</param>
        /// <param name="transitionViewModel">新しいWindowのDataContextに設定するViewModel</param>
        /// <param name="mode">画面遷移の方法を決定するTransitionMode列挙体。初期値はUnKnownです。</param>
        /// <param name="messageKey">メッセージキー</param>
        public TransitionMessage(Type windowType, INotifyPropertyChanged transitionViewModel, TransitionMode mode, string messageKey)
            : base(messageKey)
        {
            Mode = mode;
            TransitionViewModel = transitionViewModel;

            if (windowType != null)
            {
                if (!windowType.IsSubclassOf(typeof(Window)))
                    throw new ArgumentException("Windowの派生クラスを指定してください。", nameof(windowType));
            }

            WindowType = windowType;
        }

        /// <summary>
        ///     新しいWindowのDataContextに設定するViewModelを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="transitionViewModel">新しいWindowのDataContextに設定するViewModel</param>
        public TransitionMessage(INotifyPropertyChanged transitionViewModel)
            : this(null, transitionViewModel, TransitionMode.UnKnown, null) { }

        /// <summary>
        ///     新しいWindowのDataContextに設定するViewModelと画面遷移モードを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="transitionViewModel">新しいWindowのDataContextに設定するViewModel</param>
        /// <param name="mode">画面遷移の方法を決定するTransitionMode列挙体。初期値はUnKnownです。</param>
        public TransitionMessage(INotifyPropertyChanged transitionViewModel, TransitionMode mode)
            : this(null, transitionViewModel, mode, null) { }

        /// <summary>
        ///     新しいWindowの型と新しいWindowに設定するViewModel、画面遷移モードとメッセージキーを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="windowType">新しいWindowの型</param>
        /// <param name="transitionViewModel">新しいWindowのDataContextに設定するViewModel</param>
        /// <param name="mode">画面遷移の方法を決定するTransitionMode列挙体。初期値はUnKnownです。</param>
        public TransitionMessage(Type windowType, INotifyPropertyChanged transitionViewModel, TransitionMode mode)
            : this(windowType, transitionViewModel, mode, null) { }

        /// <summary>
        ///     新しいWindowのDataContextに設定するViewModelを指定、または取得します。
        /// </summary>
        public INotifyPropertyChanged TransitionViewModel
        {
            get { return (INotifyPropertyChanged) GetValue(TransitionViewModelProperty); }
            set { SetValue(TransitionViewModelProperty, value); }
        }

        /// <summary>
        ///     新しいWindowの表示方法を決定するTransitionModeを指定、または取得します。<br />
        ///     初期値はUnKnownです。
        /// </summary>
        public TransitionMode Mode
        {
            get { return (TransitionMode) (GetValue(ModeProperty) ?? default(TransitionMode)); }
            set { SetValue(ModeProperty, value); }
        }

        /// <summary>
        ///     新しいWindowの型を指定、または取得します。
        /// </summary>
        public Type WindowType
        {
            get { return (Type) GetValue(WindowTypeProperty); }
            set { SetValue(WindowTypeProperty, value); }
        }

        /// <summary>
        ///     派生クラスでは必ずオーバーライドしてください。Freezableオブジェクトとして必要な実装です。<br />
        ///     通常このメソッドは、自身の新しいインスタンスを返すように実装します。
        /// </summary>
        /// <returns>自身の新しいインスタンス</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new TransitionMessage(TransitionViewModel, MessageKey);
        }
    }
}
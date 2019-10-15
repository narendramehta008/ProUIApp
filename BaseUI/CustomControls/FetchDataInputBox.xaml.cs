using BaseUI.EnumsPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseUI.CustomControls
{
    /// <summary>
    /// Interaction logic for FetchDataInputBox.xaml
    /// </summary>
    public partial class FetchDataInputBox : UserControl
    {
        public FetchDataInputBox()
        {
            InitializeComponent();
            MainGrid.DataContext = this;
            PatternType = new List<string>
            {
                PattenTypes.Regex.ToString(),
                PattenTypes.GetBetween.ToString(),
                PattenTypes.HtmlAgility.ToString()
            };
            // ExecutePatternCommand = new RelayCommand(ExecutePattern, (sender) => true);
        }

        private void ExecutePattern(object obj)
        {
            // PageResponseParam
        }

        public bool IsValidate
        {
            get { return (bool)GetValue(IsValidateProperty); }
            set { SetValue(IsValidateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsValidate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsValidateProperty =
            DependencyProperty.Register("IsValidate", typeof(bool), typeof(FetchDataInputBox), new FrameworkPropertyMetadata(OnPropertyChanged) { BindsTwoWayByDefault = true });

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var val = e.NewValue;
        }

        public List<string> PatternType
        {
            get { return (List<string>)GetValue(PatternTypeProperty); }
            set { SetValue(PatternTypeProperty, value); }
        }

        public static readonly DependencyProperty PatternTypeProperty =
            DependencyProperty.Register("PatternType", typeof(List<string>), typeof(FetchDataInputBox), new PropertyMetadata(new List<string>()));


        public string FirstPattern
        {
            get { return (string)GetValue(FirstPatternProperty); }
            set { SetValue(FirstPatternProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstPattern.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstPatternProperty =
            DependencyProperty.Register("FirstPattern", typeof(string), typeof(FetchDataInputBox), new FrameworkPropertyMetadata(OnPropertyChanged) { BindsTwoWayByDefault = true });


        public string SecondPattern
        {
            get { return (string)GetValue(SecondPatternProperty); }
            set { SetValue(SecondPatternProperty, value); }
        }


        // Using a DependencyProperty as the backing store for SecondPattern.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondPatternProperty =
            DependencyProperty.Register("SecondPattern", typeof(string), typeof(FetchDataInputBox), new FrameworkPropertyMetadata(OnPropertyChanged) { BindsTwoWayByDefault = true });


        public string SelectedPatternType
        {
            get { return (string)GetValue(SelectedPatternTypeProperty); }
            set { SetValue(SelectedPatternTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPatternType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPatternTypeProperty =
            DependencyProperty.Register("SelectedPatternType", typeof(string), typeof(FetchDataInputBox), new FrameworkPropertyMetadata(OnPropertyChanged));

        public ICommand ExecutePatternCommand
        {
            get { return (ICommand)GetValue(ExecutePatternCommandProperty); }
            set { SetValue(ExecutePatternCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExecutePatternCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExecutePatternCommandProperty =
            DependencyProperty.Register("ExecutePatternCommand", typeof(ICommand), typeof(FetchDataInputBox), new PropertyMetadata(default(ICommand)));

        public string PageResponseParam
        {
            get { return (string)GetValue(PageResponseParamProperty); }
            set { SetValue(PageResponseParamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageResponseParam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageResponseParamProperty =
            DependencyProperty.Register("PageResponseParam", typeof(string), typeof(FetchDataInputBox), new PropertyMetadata(OnPropertyChanged));

        public List<MatchCollection> RegexResult
        {
            get { return (List<MatchCollection>)GetValue(RegexResultProperty); }
            set { SetValue(RegexResultProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RegexResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegexResultProperty =
            DependencyProperty.Register("RegexResult", typeof(List<MatchCollection>), typeof(FetchDataInputBox), new PropertyMetadata(new List<MatchCollection>()));

        public List<string> InnerHtml
        {
            get { return (List<string>)GetValue(InnerHtmlProperty); }
            set { SetValue(InnerHtmlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InnerHtml.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InnerHtmlProperty =
            DependencyProperty.Register("InnerHtml", typeof(List<string>), typeof(FetchDataInputBox), new PropertyMetadata(OnPropertyChanged));



        public int ParentWidth
        {
            get { return (int)GetValue(ParentWidthProperty); }
            set { SetValue(ParentWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParentWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParentWidthProperty =
            DependencyProperty.Register("ParentWidth", typeof(int), typeof(FetchDataInputBox), new PropertyMetadata(OnPropertyChanged));




        public int SNo
        {
            get { return (int)GetValue(SNoProperty); }
            set { SetValue(SNoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SNo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SNoProperty =
            DependencyProperty.Register("SNo", typeof(int), typeof(FetchDataInputBox), new FrameworkPropertyMetadata(OnPropertyChanged) { BindsTwoWayByDefault = true });


    }
}

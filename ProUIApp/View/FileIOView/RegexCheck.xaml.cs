using BaseUI.FileIOViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace ProUIApp.View.FileIOView
{
    /// <summary>
    /// Interaction logic for RegexCheck.xaml
    /// </summary>
    public partial class RegexCheck : UserControl
    {

        RegexCheckView regexView = new RegexCheckView();
        public RegexCheck()
        {
            Initializing();
            DataContext = regexView;
            InitializeComponent();
        }

        private void Initializing()
        {

        }

        private static RegexCheck obj;

        public static RegexCheck getObj()
        {
            if (obj == null)
                return obj = new RegexCheck();
            return obj;
        }

        public static int LineNo = 0;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread th = new Thread(Submit_Click);
                th.IsBackground = true;
                th.Start();
            }
            catch
            {
            }
        }

        private void Submit_2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Thread th = new Thread(Submit_2_Click);
                th.IsBackground = true;
                th.Start();
            }
            catch
            {
            }
        }

        private void Submit_Click()
        {
            int groupNo = 0;
            try
            {

                try
                {
                    TextBox_Group_1.Dispatcher.Invoke(new Action(delegate
                    {
                        int.TryParse(TextBox_Group_1.Text, out groupNo);

                    }));
                }
                catch (Exception ex)
                {
                }

                try
                {
                    if (!string.IsNullOrEmpty(regexView.RegexExpression) && !string.IsNullOrEmpty(regexView.FileData))
                    {

                        try
                        {
                            MatchCollection obj_MatchCollection = Regex.Matches(regexView.FileData.Replace("\n", " "), regexView.RegexExpression);
                            foreach (Match match in obj_MatchCollection)
                            {
                                if (!string.IsNullOrEmpty(match.Groups[groupNo].ToString().Trim()))
                                    ListAdder(match.Groups[groupNo].ToString());
                            }
                            string json = Newtonsoft.Json.JsonConvert.SerializeObject(regexView.ListBoxResult);
                        }
                        catch (Exception ex)
                        {

                        }
                        // string des=new
                    }
                }
                catch (Exception ex)
                {

                }
            }
            catch
            {

            }
        }

        private void Submit_2_Click()
        {

        }

        public static string GetText(RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd).Text;
        }

        public void ListAdder(string groupData)
        {
            try
            {
                Dispatcher.Invoke(new Action(delegate {
                    if (regexView.ListBoxResult.Where(x => x.Contains(groupData)).Count() == 0)
                    {
                        regexView.Current++;
                        regexView.ListBoxResult.Add(regexView.Current + " : " + groupData);
                    }
                }));

            }
            catch (Exception x)
            {
            }
        }


        public void ListClear()
        {
            try
            {
                regexView.ListBoxResult.Clear();
                ListBox_Result.Dispatcher.Invoke(new Action(delegate
                {
                    LineNo = 0;
                    regexView.Current = 0;
                    ListBox_Result.Items.Clear();
                }));
            }
            catch
            {
            }
        }

        public List<string> GetListData()
        {
            List<string> listData = new List<string>();
            try
            {
                ListBox_Result.Dispatcher.Invoke(new Action(delegate
                {
                    foreach (string item in ListBox_Result.Items)
                    {
                        listData.Add(item);
                    }
                }));
            }
            catch
            {
            }
            return listData;
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            ListClear();
        }

        private void Button_ExportCSV_Click(object sender, RoutedEventArgs e)
        {
            string csvHeader = "SearchData";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\AllScrap";
            string fileName = filePath + "\\CsvList(" + (DateTime.Now.ToString("dd-MM-yy")) + ").csv";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            //GetListData().ForEach(x => FileHelper.ExportDataCSVFile(csvHeader, x.ToString().Substring(x.ToString().IndexOf(':') + 1).Replace(",", ""), fileName));
        }

        private void ButtonBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                if (opf.ShowDialog() == true)
                    regexView.FilePath = opf.FileName;

                regexView.FileData = (new StreamReader(opf.FileName).ReadToEnd());
            }
            catch (Exception ex)
            {
            }
        }
    }
}

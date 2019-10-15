using BaseLib.Handlers.WebHandlers;
using BaseLibs.Handlers.DataHandlers;
using BaseUI.AccountViewModel;
using ProUIApp.Functions;
using ProUIApp.View.AccountView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace ProUIApp.View.DemoView
{
    /// <summary>
    /// Interaction logic for SimpleMaterial.xaml
    /// </summary>
    public partial class SimpleMaterial : UserControl
    {
        public SimpleMaterial()
        {
            InitializeComponent();
        }

        private static SimpleMaterial obj;
        public static SimpleMaterial GetObj()
        {
            return obj ?? (obj = new SimpleMaterial());
        }
        EmbedBrowser EmbedBrowser;

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => Initialize());
        }

        public void Initialize()
        {
            try
            {
                var accountModel = new AccountModel();
                accountModel.Session = File.ReadAllText(@"D:\Programming\Programs\GitHub Repositories\System\ProUIApp\ProUIApp\View\AccountView\CookieFile.json");
                if (EmbedBrowser == null)
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        EmbedBrowser = new EmbedBrowser(accountModel);
                        EmbedBrowser.Visibility = Visibility;

                        EmbedBrowser.Show();
                    });
               
                EmbedBrowser.SetCookie();
                System.Threading.Thread.Sleep(5000);
                TestMethod();
            }
            catch (Exception ex)
            {
            }
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAirplane_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("By Plane");
        }

        private void ButtonTrain_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("By Train");
        }

        public void TestMethod()
        {
            try
            {
                //course-body__info-tab-name course-body__info-tab-name-content active ember-view
                var automation = new Automation(EmbedBrowser);
                automation.LoadPageUrlAndWait("https://www.linkedin.com/learning/building-applications-with-angular-asp-dot-net-core-and-entity-framework-core/welcome", 15);
                automation.ExecuteScript($"document.getElementsByClassName('course-body__info-tab-name course-body__info-tab-name-content ember-view')[0].click()", delayInSec: 5);
                var pageResponse = EmbedBrowser.GetPageSource();
                var name = Utils.RemoveHtmlTags(HtmlAgilityHelper.GetStringTextFromClassName(pageResponse, "li-i18n-linkto t-16 t-white"));

                var divList = HtmlAgilityHelper.GetListNodesFromClassName(pageResponse, "course-toc__item video-item ember-view");
                var chapterList = HtmlAgilityHelper.GetListNodesFromAttribute(pageResponse, "li", AttributeIdentifierType.ClassName, null, "course-chapter chapter");

                var csvName = new CsvName(name);
                foreach (var div in divList)
                {
                    var learning = new Learning();
                    learning.SNo = divList.IndexOf(div) + 1;

                    var chapter = chapterList.Where(x => x.OuterHtml.Contains(div.OuterHtml)).FirstOrDefault();
                    var chapterName = HtmlAgilityHelper.GetStringTextFromClassName(chapter.OuterHtml, "course-chapter__title-text t-16 t-bold");
                    learning.ChapterTitle = chapterName;
                    learning.Duration = Utils.RemoveHtmlTags(HtmlAgilityHelper.GetStringTextFromClassName(div.OuterHtml, "duration"));
                    learning.VideoName = Utils.RemoveHtmlTags(HtmlAgilityHelper.GetStringTextFromClassName(div.OuterHtml, "course-toc__item-content t-14 t-black t-normal")?.Replace(learning.Duration, "")?.Trim());
                    pageResponse = EmbedBrowser.GetPageSource();
                    learning.VideoUrl = Utils.GetBetween(HtmlAgilityHelper.GetStringFromClassName(pageResponse, "vjs-tech"), "src=\"", "\"");

                    automation.ExecuteScript($"document.getElementsByClassName('course-body__info-tab-name course-body__info-tab-name-transcripts ember-view')[0].click()", delayInSec: 5);
                    try
                    {
                        var datas = HtmlAgilityHelper.GetListInnerHtmlFromClassName(EmbedBrowser.GetPageSource(), "transcripts-component__line").Skip(1);
                        foreach (var data in datas)
                            learning.TransScript += Utils.RemoveHtmlTags(data);
                    }
                    catch (Exception ex)
                    {
                    }

                    csvName.Learnings.Add(learning);
                    automation.ExecuteScript($"document.getElementsByClassName('course-body__info-tab-name course-body__info-tab-name-content ember-view')[0].click()", delayInSec: 5);
                    automation.ExecuteScript($"document.getElementsByClassName('course-toc__item-content t-14 t-black t-normal')[{learning.SNo}].click()", delayInSec: 5);
                    automation.WhileLoad();

                }

                var csv = new System.Text.StringBuilder();
                csvName.Learnings.ForEach(line =>
                {
                    csv.AppendLine(string.Join(",", line.SNo, $"\"{line.ChapterTitle}\"", $"\"{line.VideoName}\"", line.Duration, line.VideoUrl, $"\"{line.TransScript}\""));
                });

                File.WriteAllText($@"D:\Csv Data\{name.Replace(".","").Replace(":","")}.csv", csv.ToString());
            }
            catch (Exception ex)
            {
            }
        }
    }

    public class CsvName
    {
        public CsvName(string csvName)
        {
            CsvFileName = csvName;
        }
        public string CsvFileName { get; set; }
        public List<Learning> Learnings { get; set; } = new List<Learning>();
    }
    public class Learning
    {
        public string VideoName { get; set; }
        public string ChapterTitle { get; set; }
        public string TransScript { get; set; }
        public int SNo { get; set; }
        public string VideoUrl { get; set; }
        public string Duration { get; set; }
    }
}

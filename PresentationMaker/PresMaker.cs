using NetOffice.OfficeApi.Enums;
using NetOffice.PowerPointApi;
using NetOffice.PowerPointApi.Enums;
using NetOffice.PowerPointApi.Tools;
using System;
using PowerPoint = NetOffice.PowerPointApi;

namespace PresentationMaker
{
    class PresMaker
    {
        private Presentation Presentation;
        private PowerPoint.Application application;
        private CommonUtils utils;
        public PresMaker()
        {
            application = new PowerPoint.Application();
            utils = new CommonUtils(application);
            Presentation = application.Presentations.Add();
        }
        public void Create(string fileRoad, string[] sentances)
        {
            try
            {
                for (int i = 0; i < sentances.Length; i++)
                {
                    var slide = Presentation.Slides.Add(i + 1, PpSlideLayout.ppLayoutBlank);
                    var textBox = slide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 300, 250, 600, 100);
                    textBox.TextFrame.TextRange.Text = sentances[i];
                }
                SavePres(fileRoad);
            }
            catch (Exception)
            {
                throw new Exception("Під час створення презентації\n виникла помилка");
            }
        }
        private void SavePres(string fileRoad)
        {
            var File = GetRoots(fileRoad);
            string document = utils.File.Combine(File[0], File[1], DocumentFormat.Normal);
            Presentation.SaveAs(document);
            application.Quit();
            application.Dispose();
        }
        private string[] GetRoots(string fileRoad)
        {
            var file = fileRoad.Replace(".pptx", "").Split("\\");
            string[] info = new string[2];
            string temp = null;
            for (int i = 0; i < file.Length - 1; i++)
            {
                temp += file[i] + "\\";
            }
            info[0] = temp;
            info[1] = file[^1];
            return info;
        }
    }
}

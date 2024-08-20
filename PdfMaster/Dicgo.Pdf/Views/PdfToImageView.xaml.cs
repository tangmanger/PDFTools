using Dicgo.Domain.Attributes;
using Dicgo.Domain.Enums;
using Dicgo.Pdf.Common;
using Dicgo.Pdf.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Dicgo.Pdf.Views
{
    /// <summary>
    /// PdfToImage.xaml 的交互逻辑
    /// </summary>
    [Tool("Pdf转图片", CommonSetting.PDFTOPICTURE, CommonSetting.PDF, typeof(PdfToImageView), typeof(PdfToImageViewModel), "\ue617")]
    public partial class PdfToImageView : UserControl
    {
        public PdfToImageView()
        {
            InitializeComponent();
        }
    }
}

using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Master.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Ioc.Default.ConfigureServices(
            new ServiceCollection()
            .AddSingleton<MainViewModel>()
            .BuildServiceProvider()
             );
        }
        public MainViewModel Main
        {
            get
            {

                return Ioc.Default.GetService<MainViewModel>() ?? new MainViewModel();
            }
        }
    }
}

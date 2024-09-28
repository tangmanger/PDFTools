using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dicgo.Common.Helpers;
using Dicgo.Domain.Models;
using Master.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Master.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private List<ToolModel>? tools;
        private FrameworkElement workView;

        #region 属性

        /// <summary>
        /// 列表
        /// </summary>
        public List<ToolModel> Tools
        {
            get => tools;

            set
            {
                tools = value;
                OnPropertyChanged();
            }
        }

        public FrameworkElement WorkView
        {
            get => workView;
            set
            {
                workView = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        internal async void Init()
        {
            await Task.Run(() =>
              {
                  PdfMaestroLoader pdfMaestroLoader = new PdfMaestroLoader();
                  Tools = pdfMaestroLoader.Tools;
                  NavigationHelper.SetTools(Tools);
                  NavigationHelper.SetUseCache(true);
                  NavigationHelper.SetWorkView(WorkView);
              });
            var first = Tools.FirstOrDefault();
            if (first != null)
            {
                first.IsSelected = true;
                var result = NavigationHelper.GetView<string>(first.ToolType, null);
                if (result != null)
                {
                    WorkView = result.View ?? new FrameworkElement();
                }
            }

        }

        #endregion


        #region 命令

        /// <summary>
        /// 导入
        /// </summary>
        public RelayCommand ImportFilesCommand => new RelayCommand(() => { });

        /// <summary>
        /// 退出
        /// </summary>
        public RelayCommand ExitCommand => new RelayCommand(() =>
        {
            Environment.Exit(0);
        });

        #endregion
    }
}

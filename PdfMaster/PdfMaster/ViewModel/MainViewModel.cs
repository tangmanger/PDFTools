using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dicgo.Common.Helpers;
using Dicgo.Domain.Interfaces;
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
        public RelayCommand ImportFilesCommand => new RelayCommand(() =>
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.DefaultExt = ".pdf"; // Default file extension
            openFileDialog.Filter = "pdf documents|*.pdf"; // Filter files by extension
            openFileDialog.Multiselect = true;
            var result = openFileDialog.ShowDialog();
            ///用户点了关闭按钮,未选择路径
            if (result != true)
            {
                return;
            }
            var files = openFileDialog.FileNames;
            if (files != null && WorkView.DataContext != null)
            {
                IOpen open = WorkView.DataContext as IOpen;
                if (open != null)
                {
                    open.OpenFile(files);
                }
            }
        });

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

using Dicgo.Common.Helpers;
using Dicgo.Domain.Attributes;
using Dicgo.Domain.Enums;
using Dicgo.Domain.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Master.Models
{
    internal class PdfMaestroLoader : BaseToolLoader
    {
        public PdfMaestroLoader() : base() { }
        public override Dictionary<string, string> ColorDic => null;
        public override string GetLangText(string name)
        {
            return name.GetLangText();
        }
        public override Type[] GetTypes()
        {
            List<Type> types = new List<Type>();
            List<string> dllNames = new List<string>() { "Dicgo.Pdf.dll" };

            foreach (var item in dllNames)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, item);
                Assembly assembly = Assembly.LoadFile(path);
                var allTypes = assembly.GetTypes().Where(t => t.GetCustomAttributes(false).ToList().Exists(m => m is ToolAttribute)).ToArray();
                if (allTypes != null && allTypes.Length > 0)
                    types.AddRange(allTypes);
            }

            return types.ToArray();
        }
    }
}

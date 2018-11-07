using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Wizard.Cinema.Admin.Helpers
{
    public static class ExcelHelper
    {
        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="file">导入文件</param>
        /// <returns>List<T></returns>
        public static List<T> InputExcel<T>(IFormFile file) where T : new()
        {
            List<T> list = new List<T> { };

            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);

            IWorkbook workbook = new XSSFWorkbook(ms);
            ISheet sheet = workbook.GetSheetAt(0);
            IRow cellNum = sheet.GetRow(0);
            var propertys = typeof(T).GetProperties();
            string value = null;
            int num = cellNum.LastCellNum;

            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                var obj = new T();
                for (int j = 0; j < num; j++)
                {
                    value = row.GetCell(j).ToString();
                    string str = (propertys[j].PropertyType).FullName;
                    if (str == "System.String")
                    {
                        propertys[j].SetValue(obj, value, null);
                    }
                    else if (str == "System.DateTime")
                    {
                        DateTime pdt = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                        propertys[j].SetValue(obj, pdt, null);
                    }
                    else if (str == "System.Boolean")
                    {
                        bool pb = Convert.ToBoolean(value);
                        propertys[j].SetValue(obj, pb, null);
                    }
                    else if (str == "System.Int16")
                    {
                        short pi16 = Convert.ToInt16(value);
                        propertys[j].SetValue(obj, pi16, null);
                    }
                    else if (str == "System.Int32")
                    {
                        int pi32 = Convert.ToInt32(value);
                        propertys[j].SetValue(obj, pi32, null);
                    }
                    else if (str == "System.Int64")
                    {
                        long pi64 = Convert.ToInt64(value);
                        propertys[j].SetValue(obj, pi64, null);
                    }
                    else if (str == "System.Byte")
                    {
                        byte pb = Convert.ToByte(value);
                        propertys[j].SetValue(obj, pb, null);
                    }
                    else
                    {
                        propertys[j].SetValue(obj, null, null);
                    }
                }

                list.Add(obj);
            }

            return list;
        }
    }
}

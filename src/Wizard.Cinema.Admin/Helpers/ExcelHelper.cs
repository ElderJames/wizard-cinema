using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Wizard.Cinema.Admin.Helpers
{
    public static class ExcelHelper
    {
        /// <summary> 导入Excel </summary>
        /// <param name="file">导入文件</param>
        /// <returns> </returns>
        public static List<T> InputExcel<T>(IFormFile file) where T : new()
        {
            var list = new List<T>();

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var ext = Path.GetExtension(file.Name);

                IWorkbook workbook;
                try
                {
                    workbook = new XSSFWorkbook(ms);
                }
                catch (Exception ex)
                {
                    workbook = new HSSFWorkbook(ms);
                }

                ISheet sheet = workbook.GetSheetAt(0);

                PropertyInfo[] propertyList = typeof(T).GetProperties();

                IRow headRow = sheet.GetRow(0);

                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    var obj = new T();
                    foreach (PropertyInfo property in propertyList)
                    {
                        string column = property.GetCustomAttribute<ColumnAttribute>()?.Name ?? property.Name;

                        int cellIndex = headRow.Cells.FindIndex(x => x.StringCellValue == column);
                        if (cellIndex < 0)
                            continue;

                        string value = row.GetCell(cellIndex)?.ToString();
                        Type propertyType = property.PropertyType;

                        if (propertyType == typeof(string))
                        {
                            property.SetValue(obj, value, null);
                        }
                        else if (propertyType == typeof(DateTime))
                        {
                            var pdt = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                            property.SetValue(obj, pdt, null);
                        }
                        else if (propertyType == typeof(bool))
                        {
                            bool pb = Convert.ToBoolean(value);
                            property.SetValue(obj, pb, null);
                        }
                        else if (propertyType == typeof(short))
                        {
                            short pi16 = Convert.ToInt16(value);
                            property.SetValue(obj, pi16, null);
                        }
                        else if (propertyType == typeof(int))
                        {
                            int pi32 = Convert.ToInt32(value);
                            property.SetValue(obj, pi32, null);
                        }
                        else if (propertyType == typeof(long))
                        {
                            long pi64 = Convert.ToInt64(value);
                            property.SetValue(obj, pi64, null);
                        }
                        else if (propertyType == typeof(byte))
                        {
                            byte pb = Convert.ToByte(value);
                            property.SetValue(obj, pb, null);
                        }
                        else
                        {
                            property.SetValue(obj, null, null);
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
        }
    }
}

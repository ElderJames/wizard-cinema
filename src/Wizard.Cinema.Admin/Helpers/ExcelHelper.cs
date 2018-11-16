using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
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
        /// <returns></returns>
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

        public static byte[] ExportExcel<T>(IEnumerable<T> list)
        {
            PropertyInfo[] propertyList = typeof(T).GetProperties();

            IWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);
            for (int i = 0; i < propertyList.Length; i++)
            {
                PropertyInfo property = propertyList[i];
                string column = property.GetCustomAttribute<ColumnAttribute>()?.Name ?? property.Name;

                headerRow.CreateCell(i).SetCellValue(column);
            }

            for (int i = 0; i < list.Count(); i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                var obj = list.ElementAt(i);
                for (int j = 0; j < propertyList.Length; j++)
                {
                    PropertyInfo property = propertyList[j];
                    object value = property.GetValue(obj);
                    Type propertyType = property.PropertyType;

                    if (propertyType == typeof(string))
                    {
                        row.CreateCell(j).SetCellValue(value.ToString());
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        var pdt = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                        row.CreateCell(j).SetCellValue(pdt);
                    }
                    else if (propertyType == typeof(bool))
                    {
                        bool pb = Convert.ToBoolean(value);
                        row.CreateCell(j).SetCellValue(pb);
                    }
                    else if (propertyType == typeof(short))
                    {
                        short pi16 = Convert.ToInt16(value);
                        row.CreateCell(j).SetCellValue(pi16);
                    }
                    else if (propertyType == typeof(int))
                    {
                        int pi32 = Convert.ToInt32(value);
                        row.CreateCell(j).SetCellValue(pi32);
                    }
                    else if (propertyType == typeof(long))
                    {
                        long pi64 = Convert.ToInt64(value);
                        row.CreateCell(j).SetCellValue(pi64);
                    }
                    else if (propertyType == typeof(byte))
                    {
                        byte pb = Convert.ToByte(value);
                        row.CreateCell(j).SetCellValue(pb);
                    }
                }
            }

            byte[] buffer = new byte[1024 * 5];
            using (var ms = new MemoryStream())
            {
                workbook.Write(ms);
                buffer = ms.GetBuffer();
                ms.Close();
            }
            return buffer;
        }
    }
}

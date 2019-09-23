﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TwelveFinal.Repositories.Models;

namespace DataSeeding
{
    public class UniversityInit : CommonInit
    {
        public UniversityInit(TFContext _context) : base(_context)
        {

        }

        public void Init()
        {
            List<UniversityDAO> universityDAOs = LoadFromExcel("../../../DataSeeding.xlsx");
            DbContext.AddRange(universityDAOs);
        }
        private List<UniversityDAO> LoadFromExcel(string path)
        {
            List<UniversityDAO> excelTemplates = new List<UniversityDAO>();
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                var worksheet = package.Workbook.Worksheets[4];
                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    UniversityDAO excelTemplate = new UniversityDAO()
                    {
                        Id = CreateGuid("University" + worksheet.Cells[i, 1].Value?.ToString()),
                        Code = worksheet.Cells[i, 1].Value?.ToString(),
                        Name = worksheet.Cells[i, 2].Value?.ToString(),
                    };
                    excelTemplates.Add(excelTemplate);
                }
            }
            return excelTemplates;
        }
    }
}

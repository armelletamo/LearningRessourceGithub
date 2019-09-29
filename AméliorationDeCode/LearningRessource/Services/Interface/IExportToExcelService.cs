using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningRessource.Services.Interface
{
   public  interface IExportToExcelService
    {
        DataSet ConvertToDataTable<T>(IList<T> data);
        void GenerateExcelFile(DataSet ds);
        void ExportToExcel<T>(IList<T> liste);
    }
}

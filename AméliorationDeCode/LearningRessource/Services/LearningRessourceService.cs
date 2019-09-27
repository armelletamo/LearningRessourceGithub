using LearningRessource.Repository.Interface;
using LearningRessource.Repository.Models;
using LearningRessource.Services.Interface;
using LearningRessource.ViewModels;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace LearningRessource.Services
{
    public class LearningRessourceService : ILearningRessourceService
    {
        private ILearningRepository _learningrepository;


        public LearningRessourceService(ILearningRepository learningrepository)
        {
            _learningrepository = learningrepository;
        }

        public void AddRessource(CourseVM courseVM)
        {
            Course myCourse = new Course();
            myCourse.Title = courseVM.Title;
            myCourse.Description = courseVM.Description;
            myCourse.StartDate = courseVM.StartDate;
            myCourse.EndDate = courseVM.EndDate;
            _learningrepository.Add(myCourse);
        }

        public List<CourseVM> GetRessources()
        {

            List<CourseVM> courseVM = new List<CourseVM>();

            List<Course> myCourses = _learningrepository.GetCourses();
            if (myCourses != null)
            {
                foreach (Course course in myCourses)
                {
                    CourseVM myCourseVM = new CourseVM();
                    myCourseVM.Title = course.Title;
                    myCourseVM.Description = course.Description;
                    myCourseVM.StartDate = course.StartDate;
                    myCourseVM.EndDate = course.EndDate;
                    courseVM.Add(myCourseVM);
                }
            }
            return courseVM;
        }

        public System.Data.DataSet ConvertToDataTable<T>(IList<T> data)

        {

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            System.Data.DataTable table = new System.Data.DataTable();

            foreach (PropertyDescriptor prop in properties)

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)

            {

                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)

                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);

            }
            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            return ds;

        }

        private void GenerateExcelFile(DataSet ds)
        {
            string paramFileFullPath = AppDomain.CurrentDomain.BaseDirectory + "LearningRessourceTest.xlsx";
            // Global missing reference for objects we are not defining...
            object missing = System.Reflection.Missing.Value;

            // Create an Excel object and add workbook...
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excel.Application.Workbooks.Add(true);

            //loop datatables here.... and add sheets to workbook
            foreach (System.Data.DataTable dt in ds.Tables)
            {
                addTableSheet(ref workbook, ref excel, dt, true);
            }

            // If wanting to Save the workbook...
            workbook.SaveAs(paramFileFullPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missing, missing, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missing, missing, missing, missing, missing);

            // If wanting to make Excel visible and activate the worksheet...
            excel.Visible = true;
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;
            ((_Worksheet)worksheet).Activate();

            // If wanting excel to shutdown...
            //((_Application)excel).Quit();
        }

        private void addTableSheet(ref Workbook wb, ref Microsoft.Office.Interop.Excel.Application excel, System.Data.DataTable dt, bool _IsHeaderIncluded)
        {

            //Rename the first/default sheet name
            if (dt.TableName.ToString().Trim() != string.Empty)
            {
                Worksheet ws = (Worksheet)excel.Worksheets.get_Item(1);
                if (ws.Name.ToLower() != "LearningRessource")
                {
                    ws = (Worksheet)wb.Worksheets.Add();
                }
                ws.Name = dt.TableName.ToString();
            }

            int iCol = 0;
            // Add column headings...
            if (_IsHeaderIncluded == true)
            {
                foreach (DataColumn c in dt.Columns)
                {
                    iCol++;
                    excel.Cells[1, iCol] = c.ColumnName;
                }
            }

            // for each row of data...
            int iRow = 0;
            foreach (DataRow r in dt.Rows)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    iCol++;
                    if (_IsHeaderIncluded == true)
                    {
                        excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                    }
                    else
                    {
                        excel.Cells[iRow, iCol] = r[c.ColumnName];
                    }
                }
            }
        }

        public void ImportToExcel<T>(IList<T> liste)
        {
            var x = ConvertToDataTable(liste);
            GenerateExcelFile(x);
        }
    }

}
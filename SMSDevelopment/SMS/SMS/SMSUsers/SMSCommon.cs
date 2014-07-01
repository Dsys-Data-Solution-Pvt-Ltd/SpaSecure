using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SMS.SMSCommons
{
    public class SMSCommon
    {
        public static DataTable ConvertRowsToColumns(DataTable table, string columnX, string columnY)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            foreach (DataRow dr in table.Rows)
            {
                string columnXTemp = dr[columnX].ToString().Replace('.', ' ').Trim();
                //Verify if the value was already listed
                if (!columnXValues.Contains(columnXTemp))
                {
                    //if the value id different from others provided, add to the list of 
                    //values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    returnTable.Columns.Add(columnXTemp);
                }
                dr[columnX] = dr[columnX].ToString().Replace('.', ' ').Trim();
            }

            //Add a line for each column of the DataTable
            int rowsadd = 0;
            foreach (string val in columnXValues)
            {
                DataRow[] rows = table.Select(columnX + "='" + val + "'");
                if (rows.Count() > rowsadd)
                {
                    rowsadd = rows.Count();
                }
            }

            for (int i = 0; i < rowsadd; i++)
            {
                DataRow dr = returnTable.NewRow();
                returnTable.Rows.Add(dr);
            }

            foreach (string val in columnXValues)
            {
                DataRow[] rows = table.Select(columnX + "='" + val + "'");
                int i = 0;
                foreach (DataRow dr in rows)
                {
                    returnTable.Rows[i][val] = dr[columnY];
                    i++;
                }
            }

            return returnTable;
        }



        public static DataTable ConvertRowsToColumns1(DataTable table, string columnX, string columnY, string columnZ)
        {
            //Create a DataTable to Return
            DataTable returnTable = new DataTable();

            //Read all DISTINCT values from columnX Column in the provided DataTale
            List<string> columnXValues = new List<string>();

            foreach (DataRow dr in table.Rows)
            {
                string columnXTemp = dr[columnX].ToString().Replace('.', ' ').Trim();
                //Verify if the value was already listed
                if (!columnXValues.Contains(columnXTemp))
                {
                    //if the value id different from others provided, add to the list of 
                    //values and creates a new Column with its value.
                    columnXValues.Add(columnXTemp);
                    returnTable.Columns.Add(columnXTemp);
                }
                dr[columnX] = dr[columnX].ToString().Replace('.', ' ').Trim();
            }

            //Add a line for each column of the DataTable
            int rowsadd = 0;
            foreach (string val in columnXValues)
            {
                DataRow[] rows = table.Select(columnX + "='" + val + "'");
                if (rows.Count() > rowsadd)
                {
                    rowsadd = rows.Count();
                }
            }

            for (int i = 0; i < rowsadd; i++)
            {
                DataRow dr = returnTable.NewRow();
                returnTable.Rows.Add(dr);
            }

            foreach (string val in columnXValues)
            {
                DataRow[] rows = table.Select(columnX + "='" + val + "'");
                int i = 0;
                foreach (DataRow dr in rows)
                {
                    returnTable.Rows[i][val] = dr[columnY];
                    returnTable.Rows[i][val] = dr[columnZ];
                    i++;
                }
            }

            return returnTable;
        }
    }
}

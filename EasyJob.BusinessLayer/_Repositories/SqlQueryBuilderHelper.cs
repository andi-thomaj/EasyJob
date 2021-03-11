using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace EasyJob.BusinessLayer._Repositories
{
    public class SqlQueryBuilderHelper
    {
        private const string sqlSelectAll = "SELECT * FROM {0} ";
        private const string sqlWhereEqual = " {0} = {1} ";
        private const string sqlSelectAllWhere = "SELECT * FROM {0} WHERE {1} ";
        private const string sqlSelectAllCount = "SELECT count(*) FROM {0} ";
        private const string sqlSelectAllCountWhere = "SELECT count(*) FROM {0} WHERE {1} ";

        private const string sqlDeleteFromWhere = "DELETE FROM {0} WHERE {1}";


        public static string GetSqlDeleteFromWhere(string tableName, string colName, params int[] colsValue)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentNullException(nameof(tableName));
            var inWhere = GetSqlWhereByIdColumnInList(colName, colsValue);
            return string.Format(sqlDeleteFromWhere, tableName, inWhere);
        }

        public static string GetSqlSelectAll(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentNullException(nameof(tableName));

            return string.Format(sqlSelectAll, tableName);
        }

        public static string GetSqlSelectAllWhere(string tableName, string whereClausole)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentNullException(nameof(tableName));

            if (string.IsNullOrWhiteSpace(whereClausole))
                throw new ArgumentNullException(nameof(whereClausole));

            if (whereClausole.StartsWith("WHERE ", StringComparison.OrdinalIgnoreCase))
                whereClausole = whereClausole.Substring("WHERE".Length);
            return string.Format(sqlSelectAllWhere, tableName, whereClausole);
        }
        public static string GetSqlSelectByIdColumn(string tableName, string colName, int colValue)
        {
            var whereClausole = string.Format(sqlWhereEqual, colName, colValue);
            return GetSqlSelectAllWhere(tableName, whereClausole);
        }

        public static string GetSqlSelectByIdColumnInList(string tableName, string colName, params int[] colsValue)
        {
            return GetSqlSelectAllWhere(tableName, GetSqlWhereByIdColumnInList(colName, colsValue));
        }

        public static string GetSqlWhereByIdColumnInList(string colName, params int[] colsValue)
        {
            var whereClausole = new StringBuilder();
            whereClausole.Append(colName);
            whereClausole.Append(" in (");
            var sep = "";
            foreach (var colValue in colsValue)
            {
                whereClausole.Append(sep);
                sep = ",";
                whereClausole.Append(colValue);
            }
            whereClausole.Append(" )");

            return whereClausole.ToString();
        }
        public static GetSqlSelectByColumnsOutput GetSqlSelectByColumnns(string tableName, IDictionary<string, object> columnsParams)
        {
            var output = new GetSqlSelectByColumnsOutput();
            var whereClausole = new StringBuilder();
            var sqlPars = new List<SqlParameter>();
            var and = "";
            foreach (var colParam in columnsParams)
            {
                var col = colParam.Key;
                whereClausole.AppendFormat(sqlWhereEqual,col, "=@" + col);
                whereClausole.Append(and);
                and = " AND ";
                sqlPars.Add(new SqlParameter("@" + col, colParam.Value));
            }

            output.SqlSelectWithWhere = GetSqlSelectAllWhere(tableName, whereClausole.ToString());
            output.Parameters = sqlPars;
            return output;
        }

        public static string GetSqlSelectAllCount(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentNullException(nameof(tableName));

            return string.Format(sqlSelectAllCount, tableName);
        }

        public static string GetSqlSelectAllCountWhere(string tableName, string whereClausole)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentNullException(nameof(tableName));

            if (string.IsNullOrWhiteSpace(whereClausole))
                throw new ArgumentNullException(nameof(whereClausole));

            if (whereClausole.StartsWith("WHERE ", StringComparison.OrdinalIgnoreCase))
                whereClausole = whereClausole.Substring("WHERE".Length);
            return string.Format(sqlSelectAllCountWhere, tableName, whereClausole);
        }
    }

    public class GetSqlSelectByColumnsOutput
    {
        public string SqlSelectWithWhere { get; set; }
        public IEnumerable<SqlParameter> Parameters { get; set; }
    }
}
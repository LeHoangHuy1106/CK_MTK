using QLNH.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNH.DAO
{
    public class TableDAO
    {
        // singleton
        private static TableDAO instance;

        public static TableDAO Instance 
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set => instance = value; 
        }

        // kích thước button mỗi table
        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        // lấy danh sách Table trả về list
        public List<Table> GetListTable()
        {
            List<Table> list = new List<Table>();

            string query = "select * from TableFood";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }

            return list;
        }

        public List<Table> SearchTableByName(string name)
        {
            List<Table> list = new List<Table>();

            string query = string.Format("select * from TableFood where dbo.fuChuyenCoDauThanhKhongDau(name) like N'%' + dbo.fuChuyenCoDauThanhKhongDau(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }

            return list;
        }

        public List<Table> SearchForLoadTable(string name)
        {
            List<Table> list = new List<Table>();

            string query = string.Format("select * from TableFood where dbo.fuChuyenCoDauThanhKhongDau(name) like N'%' + dbo.fuChuyenCoDauThanhKhongDau(N'{0}') + '%' or dbo.fuChuyenCoDauThanhKhongDau(status) like N'%' + dbo.fuChuyenCoDauThanhKhongDau(N'{0}') + '%'", name, name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }

            return list;
        }

        // chuyển bàn
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_SwitchTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_GetTablelist");

            // lấy từng dòng trong data
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            // trả vể List<>
            return tableList;
        }

        public bool InsertTable(string name, string status)
        {
            string query = string.Format("insert TableFood(name, status) values (N'{0}', N'{1}')", name, status);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateTable(int id, string name, string status)
        {
            string query = string.Format("update TableFood set name = N'{0}', status = N'{1}' where id = {2}", name, status, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int id)
        {
            string query = string.Format("delete TableFood where id = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}

using System;
using System.Data;
using System.Linq;

namespace Triangle.DbManagement
{
    public class TransferableDataTable : IDisposable
    {

        private DataTable internalTable;


        private int totalRowCount = -1;


        public TransferableDataTable(DataTable table)
        {
            this.internalTable = table;
        }


        public DataTable Table
        {
            get { return this.internalTable; }
        }


        public int TotalRowCount
        {
            get
            {
                if (this.totalRowCount == -1)
                {
                    return this.internalTable.Rows.Count;
                }

                return this.totalRowCount;
            }
        }


        public bool HasRows
        {
            get
            {
                return this.internalTable != null && this.internalTable.Rows != null && this.internalTable.AsEnumerable().Any();
            }
        }


        public void OverrideRowCount(int rowCount)
        {
            this.totalRowCount = rowCount;
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposeOfManaged)
        {
            if (this.internalTable != null)
            {
                this.internalTable.Dispose();
                this.internalTable = null;
            }
        }
    }
}

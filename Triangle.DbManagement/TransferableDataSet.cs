using System;
using System.Data;


namespace Triangle.DbManagement
{
    public class TransferableDataSet : IDisposable
    {

        private DataSet internalSet;


        public TransferableDataSet(DataSet table)
        {
            this.internalSet = table;
        }


        public DataSet Set
        {
            get { return this.internalSet; }
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeOfManaged)
        {
            if (this.internalSet != null)
            {
                this.internalSet.Dispose();
                this.internalSet = null;
            }
        }
    }
}

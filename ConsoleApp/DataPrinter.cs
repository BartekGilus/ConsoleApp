using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class DataPrinter
    {
        #region Members
        private IEnumerable<ImportedObject> importedObjects = null;

        #endregion

        #region Constructors
        public DataPrinter(IEnumerable<ImportedObject> importedObjects)
        {
            this.importedObjects = importedObjects;
        }
        #endregion

        #region Public Methods
        public void PrintData()
        {
            if (this.importedObjects is null)
                return;

            IEnumerable<ImportedObject> databases = importedObjects.Where(x => x.Type == "DATABASE");

            foreach (ImportedObject database in databases)
            {
                Console.WriteLine($"Database '{database.Name}' ({database.NumberOfChildren} tables)");

                IEnumerable<ImportedObject> tables = this.importedObjects.Where(x => x.ParentType == database.Type && x.ParentName == database.Name);

                foreach (ImportedObject table in tables)
                {
                    Console.WriteLine($"\tTable '{table.Schema}.{table.Name}' ({table.NumberOfChildren} columns)");

                    IEnumerable<ImportedObject> columns = this.importedObjects.Where(x => x.ParentType == table.Type && x.ParentName == table.Name);

                    foreach (ImportedObject column in columns)
                    {
                        Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
                    }
                }

            }
            Console.ReadLine();
        }
        #endregion
    }
}

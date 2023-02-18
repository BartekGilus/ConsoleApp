namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DataReader
    {
        #region Members
        private List<ImportedObject> importedObjects = null;
        #endregion

        #region Public Properties
        public IEnumerable<ImportedObject> ImportedObjects
        {
            get { return this.importedObjects; }
        }
        #endregion

        #region Public Methods
        public void ImportData(string fileToImport)
        {
            this.importedObjects = new List<ImportedObject>();

            string[] importedLines = ReadDataFromFile(fileToImport);

            for (var i = 1; i < importedLines.Length; i++)
            {
                string[] values = importedLines[i].Split(';');
                ImportedObject importedObject = new ImportedObject();

                if (values.Length <= 1)
                    continue;

                try
                {
                    importedObject.Type = values[0];
                    importedObject.Name = values[1];
                    importedObject.Schema = values[2];
                    importedObject.ParentName = values[3];
                    importedObject.ParentType = values[4];
                    importedObject.DataType = values[5];
                    importedObject.IsNullable = values[6];
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }

                CorrectNumberOfChildren(importedObject);
                this.importedObjects.Add(importedObject);
            }
        }
        #endregion

        #region Private Methods
        private string[] ReadDataFromFile(string fileToImport)
        {
            List<string> lines = new List<string>();

            StreamReader streamReader = new StreamReader(fileToImport);

            while (!streamReader.EndOfStream)
            {
                lines.Add(streamReader.ReadLine());
            }

            return lines.ToArray();
        }

        private void CorrectNumberOfChildren(ImportedObject importedObject)
        {
            if (importedObject.Type == "DATABASE")
            {
                int count = importedObjects.Count(x => x.ParentName == importedObject.Name && x.ParentType == importedObject.Type);
                importedObject.NumberOfChildren = count;
            }
            else
            {
                ImportedObject obj = importedObjects.FirstOrDefault(x => x.Name == importedObject.ParentName && x.Type == importedObject.ParentType);

                if (obj is null)
                    return;
                obj.NumberOfChildren++;
            }
        }
        #endregion
    }
}

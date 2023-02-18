using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ImportedObject : ImportedObjectBaseClass
    {
        #region Membres
        private string schema;
        private string parentName;
        private string parentType;
        private string dataType;
        private string isNullable;
        private int numberOfChildren;

        #endregion

        #region Properties
        public string Schema
        {
            get { return this.schema; }
            set
            {
                if (value is null)
                    return;

                this.schema = CorrectTheValue(value, false);
            }
        }

        public string ParentName
        {
            get { return this.parentName; }
            set
            {
                if (value is null)
                    return;

                this.parentName = CorrectTheValue(value, false);
            }
        }

        public string ParentType
        {
            get { return this.parentType; }
            set
            {
                if (value is null)
                    return;

                this.parentType = CorrectTheValue(value, true);
            }
        }

        public string DataType
        {
            get { return this.dataType; }
            set
            {
                if (value is null)
                    return;

                this.dataType = CorrectTheValue(value, false);
            }
        }

        public string IsNullable
        {
            get { return this.isNullable; }
            set
            {
                if (value is null)
                    return;

                this.isNullable = CorrectTheValue(value, false);
            }
        }

        public int NumberOfChildren
        {
            get { return this.numberOfChildren; }
            set { this.numberOfChildren = value; }
        }
        #endregion
    }
}

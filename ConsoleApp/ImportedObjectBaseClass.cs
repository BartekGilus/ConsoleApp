using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ImportedObjectBaseClass
    {
        #region Members
        private string type;
        private string name;

        #endregion

        #region Properties
        public string Type
        {
            get { return this.type; }
            set
            {
                if (value is null)
                    return;

                this.type = CorrectTheValue(value, true);
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value is null)
                    return;

                this.name = CorrectTheValue(value, false);
            }
        }
        #endregion

        protected string CorrectTheValue(string value, bool toUpper)
        {
            if (toUpper)
                return value.Trim().Replace(" ", "").Replace(Environment.NewLine, "").ToUpper();
            else
                return value.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
        }
    }
}

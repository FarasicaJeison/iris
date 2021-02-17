using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iris.Models
{
    public class modelsProducto
    {
        private int codiprod;
        private string nombprod;
        private string descprod;
        private int valoprod;

        public modelsProducto(int codiprod, string nombprod, string descprod, int valoprod)
        {
            this.Codiprod = codiprod;
            this.Nombprod = nombprod;
            this.Descprod = descprod;
            this.Valoprod = valoprod;
        }

        public int Valoprod { get => valoprod; set => valoprod = value; }
        public int Codiprod { get => codiprod; set => codiprod = value; }
        public string Nombprod { get => nombprod; set => nombprod = value; }
        public string Descprod { get => descprod; set => descprod = value; }
    }
}

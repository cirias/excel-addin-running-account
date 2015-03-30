using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CtpLibrary
{
    public class InitializeEventArgs : EventArgs
    {
        private readonly List<string> lstTiles;

        public List<string> LstTiles
        {
            get { return lstTiles; }
        }

        public InitializeEventArgs(List<string> lstTiles)
        {
            this.lstTiles = lstTiles;
        }
    }
}

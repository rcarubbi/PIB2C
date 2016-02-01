using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIB2C
{
    public class BestScoreEventArgs : EventArgs
    {
        public decimal NewRecord { get; set; }
    }
}

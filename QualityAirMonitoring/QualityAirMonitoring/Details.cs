using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAirMonitoring
{
    public class Details
    {
        public string Value { get; set; }
        public List<(string Name, double Value)> Probabilities { get; set; }
    }


}

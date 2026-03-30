using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAirMonitoring
{
    public interface IDetailsFactory
    {
        Details GetDetails(string selectedValue);
    }
}

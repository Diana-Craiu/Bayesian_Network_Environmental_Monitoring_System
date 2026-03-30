using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAirMonitoring
{
    public class NivelPoluareMapper
    {
        public string MapTemperatura(double temperatura)
        {
            if (temperatura < 10)
            {
                return "Scazut";
            }
            else if (temperatura >= 10 && temperatura <= 25)
            {
                return "Moderat";
            }
            else
            {
                return "Ridicat";
            }
        }

        public string MapUmiditate(double umiditate)
        {
            if (umiditate < 40)
            {
                return "Scazut";
            }
            else if (umiditate >= 40 && umiditate <= 60)
            {
                return "Moderat";
            }
            else
            {
                return "Ridicat";
            }
        }

        public string MapVant(double vant)
        {
            if (vant < 20)
            {
                return "Scazut";
            }
            else if (vant >= 20 && vant <= 40)
            {
                return "Moderat";
            }
            else
            {
                return "Ridicat";
            }
        }
    }
}

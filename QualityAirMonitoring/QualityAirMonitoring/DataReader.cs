using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAirMonitoring
{
    class DataReader
    {
        private readonly string filePath;

        public DataReader(string filePath)
        {
            this.filePath = filePath;
        }

        public MeteoDetails GetMeteoDetails(string selectedCity, string selectedWeek)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);

                foreach (var city in data.orase)
                {
                    if (city.nume == selectedCity)
                    {
                        foreach (var week in city.saptamani)
                        {
                            if (week.nume_saptamana == selectedWeek)
                            {
                                return new MeteoDetails
                                {
                                    Temperatura = week.detalii_meteo.temperatura,
                                    Trafic = week.detalii_meteo.trafic,
                                    Vant = week.detalii_meteo.vant,
                                    Industrie = week.detalii_meteo.industrie,
                                    Umiditate = week.detalii_meteo.umiditate
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
            }

            return new MeteoDetails();
        }

        public Details GetDetails(string valueType, string selectedValue)
        {
            IDetailsFactory factory;
            try
            {
                switch (valueType)
                {
                    case "Temperatura":
                        factory = new TemperatureDetailsFactory(filePath);
                        break;
                    case "Vant":
                        factory = new VantDetailsFactory(filePath);
                        break;
                    case "Umiditate":
                        factory = new UmiditateDetailsFactory(filePath);
                        break;
                    case "Trafic":
                        factory = new TraficDetailsFactory(filePath);
                        break;
                    case "Industrie":
                        factory = new IndustrieDetailsFactory(filePath);
                        break;
                    case "Aer":
                        factory = new AerDetailsFactory(filePath);
                        break;
                    case "Apa":
                        factory = new ApaDetailsFactory(filePath);
                        break;
                    default:
                        throw new ArgumentException("Invalid value type");
                }
                return factory.GetDetails(selectedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
           
            

            
        }

        
    }
}

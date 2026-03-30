using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAirMonitoring
{
    public class MeteoDetails
    {
        public string Temperatura { get; set; }
        public string Trafic { get; set; }
        public string Vant { get; set; }
        public string Industrie { get; set; }
        public string Umiditate { get; set; }
        public double NumericValue { get; set; }
   
    }

    public class TemperatureDetailsFactory : IDetailsFactory
    {
        private readonly string _filePath;

        public TemperatureDetailsFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Details GetDetails(string selectedValue)
        {
            try
            {
                string jsonContent = File.ReadAllText(_filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                dynamic selectedData = data["Temperatura"][selectedValue];

                var probabilities = new List<(string Name, double Value)>();

                foreach (var item in selectedData)
                {
                    var probName = item.Name;
                    var probValue = (double)item.Value;

                    probabilities.Add((probName, probValue));
                }

                return new Details
                {
                    Value = selectedValue,
                    Probabilities = probabilities
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
        }
    }

    public class VantDetailsFactory : IDetailsFactory
    {
        private readonly string _filePath;

        public VantDetailsFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Details GetDetails(string selectedValue)
        {
            try
            {
                string jsonContent = File.ReadAllText(_filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                dynamic selectedData = data["Vant"][selectedValue];

                var probabilities = new List<(string Name, double Value)>();

                foreach (var item in selectedData)
                {
                    var probName = item.Name;
                    var probValue = (double)item.Value;

                    probabilities.Add((probName, probValue));
                }

                return new Details
                {
                    Value = selectedValue,
                    Probabilities = probabilities
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
        }
    }

    public class UmiditateDetailsFactory : IDetailsFactory
    {
        private readonly string _filePath;

        public UmiditateDetailsFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Details GetDetails(string selectedValue)
        {
            try
            {
                string jsonContent = File.ReadAllText(_filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                dynamic selectedData = data["Umiditate"][selectedValue];

                var probabilities = new List<(string Name, double Value)>();

                foreach (var item in selectedData)
                {
                    var probName = item.Name;
                    var probValue = (double)item.Value;

                    probabilities.Add((probName, probValue));
                }

                return new Details
                {
                    Value = selectedValue,
                    Probabilities = probabilities
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
        }
    }

    public class TraficDetailsFactory : IDetailsFactory
    {
        private readonly string _filePath;

        public TraficDetailsFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Details GetDetails(string selectedValue)
        {
            try
            {
                string jsonContent = File.ReadAllText(_filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                dynamic selectedData = data["Trafic"][selectedValue];

                var probabilities = new List<(string Name, double Value)>();

                foreach (var item in selectedData)
                {
                    var probName = item.Name;
                    var probValue = (double)item.Value;

                    probabilities.Add((probName, probValue));
                }

                return new Details
                {
                    Value = selectedValue,
                    Probabilities = probabilities
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
        }
    }

    public class IndustrieDetailsFactory : IDetailsFactory
    {
        private readonly string _filePath;

        public IndustrieDetailsFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Details GetDetails(string selectedValue)
        {
            try
            {
                string jsonContent = File.ReadAllText(_filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                dynamic selectedData = data["Industrie"][selectedValue];

                var probabilities = new List<(string Name, double Value)>();

                foreach (var item in selectedData)
                {
                    var probName = item.Name;
                    var probValue = (double)item.Value;

                    probabilities.Add((probName, probValue));
                }

                return new Details
                {
                    Value = selectedValue,
                    Probabilities = probabilities
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
        }
    }

    public class AerDetailsFactory : IDetailsFactory
    {
        private readonly string _filePath;

        public AerDetailsFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Details GetDetails(string selectedValue)
        {
            try
            {
                string jsonContent = File.ReadAllText(_filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                dynamic selectedData = data["Aer"][selectedValue];

                var probabilities = new List<(string Name, double Value)>();

                foreach (var item in selectedData)
                {
                    var probName = item.Name;
                    var probValue = (double)item.Value;

                    probabilities.Add((probName, probValue));
                }

                return new Details
                {
                    Value = selectedValue,
                    Probabilities = probabilities
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
        }
    }

    public class ApaDetailsFactory : IDetailsFactory
    {
        private readonly string _filePath;

        public ApaDetailsFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Details GetDetails(string selectedValue)
        {
            try
            {
                string jsonContent = File.ReadAllText(_filePath);
                dynamic data = JsonConvert.DeserializeObject(jsonContent);
                dynamic selectedData = data["Apa"][selectedValue];

                var probabilities = new List<(string Name, double Value)>();

                foreach (var item in selectedData)
                {
                    var probName = item.Name;
                    var probValue = (double)item.Value;

                    probabilities.Add((probName, probValue));
                }

                return new Details
                {
                    Value = selectedValue,
                    Probabilities = probabilities
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
                return null;
            }
        }
    }
}

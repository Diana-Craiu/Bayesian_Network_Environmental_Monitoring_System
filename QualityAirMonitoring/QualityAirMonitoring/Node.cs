using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAirMonitoring
{
    public class Node
    {
        public string Name { get; set; }
        public List<string> PossibleValues { get; set; }
        public Dictionary<List<string>, double> ConditionalProbabilities { get; set; }

        public Node(string name, List<string> possibleValues)
        {
            Name = name;
            PossibleValues = possibleValues;
            ConditionalProbabilities = new Dictionary<List<string>, double>();
        }

        public void SetConditionalProbability(List<string> condition, double probability)
        {
            ConditionalProbabilities[condition] = probability;
        }

        public double PredictValue(List<Node> givenNodes, List<string> givenValues, string predictedValue)
        {
            throw new Exception("Aceasta metoda trebuie implementata");
        }
    }
}

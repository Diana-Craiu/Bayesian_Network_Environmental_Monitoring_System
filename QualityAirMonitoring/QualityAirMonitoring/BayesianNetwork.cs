using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityAirMonitoring
{
    public class BayesianNetwork
    {
        public List<Node> Nodes { get; private set; }

        public BayesianNetwork()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void RemoveNode(Node node)
        {
            Nodes.Remove(node);
        }

        public Dictionary<string, double> PredictValues(List<Node> givenNodes, List<string> givenValues, List<string> predictedNodes)
        {
            Dictionary<string, double> predictions = new Dictionary<string, double>();
            foreach (string predictedNodeName in predictedNodes)
            {
                Node predictedNode = Nodes.FirstOrDefault(n => n.Name == predictedNodeName);
                if (predictedNode != null)
                {
                    double prediction = predictedNode.PredictValue(givenNodes, givenValues, predictedNodeName);
                    predictions.Add(predictedNodeName, prediction);
                }
            }
            return predictions;
        }
    }
}



using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace IdealWeightCalculator
{
    public class WeightRepository : IDataRepository
    {
        IEnumerable<WeightCalculator> weights;
        public WeightRepository()
        {

            weights = new List<WeightCalculator>()

            {
                new WeightCalculator {Sex='w', Height=175},
                new WeightCalculator  {Sex='m', Height=167},
                new WeightCalculator  {Sex='m', Height=182},
            };
        }

        public IEnumerable<WeightCalculator> GetWeights()
        {
            return weights;
        } 


    }
}

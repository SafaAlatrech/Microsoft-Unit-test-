using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Tests
{
    public class FakeWeightRepository : IDataRepository
    {

        IEnumerable<WeightCalculator> weights;
        public FakeWeightRepository()
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

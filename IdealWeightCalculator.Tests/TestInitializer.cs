using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.Tests
{
    public class TestInitializer
    {

        [AssemblyInitialize]
        public static void AssemblyIntialize(TestContext context)
        {
            context.WriteLine("In Assembly Inialize");

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup(TestContext context)
        {
            context.WriteLine("In Assembly CleanUp");

        }

    }
}

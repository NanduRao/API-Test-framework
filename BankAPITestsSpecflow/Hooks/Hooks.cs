using System.Diagnostics;
using TechTalk.SpecFlow;
using BankSystem.Tests.Utilities;

namespace BankSystem.Tests
{
    [Binding]
    public class Hooks
    {
        [AfterFeature]
        public static void OneTimeTearDown()
        {
            // Run the external command to generate the LivingDoc report
            Utils.GenerateLivingDocReport();
        }
    }
}

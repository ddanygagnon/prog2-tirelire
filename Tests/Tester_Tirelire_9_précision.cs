using Microsoft.VisualStudio.TestTools.UnitTesting;

using TirelireLib;

namespace Tests
{
    public partial class Tester_Tirelire_9
    {

        [TestMethod]
        public void T5_DéposerAvecPrécision()
        {
            TesterDéposer(new Tirelire9());
        }


        [TestMethod]
        public void T6_RetirerAvecPrécision()
        {
            TesterRetirer(new Tirelire9());
        }

    }
}

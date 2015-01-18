using InOut.Utils;

namespace InOutTest.Ex
{
    public class AliasItem
    {
        [Alias("property_a")]
        public string ProperyA { get; set; }

        [Alias("property_b")]
        public bool PropertyB { get; set; }
        [Alias("properetyc")]
        public long PropretyC { get; set; }
    }
}

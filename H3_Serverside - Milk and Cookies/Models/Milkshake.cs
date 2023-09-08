namespace H3_Serverside___Milk_and_Cookies.Models
{
    public class Milkshake
    {
        public MilkshakeFlavour Flavour { get; set; }

        public Milkshake(MilkshakeFlavour flavour)
        {
            Flavour = flavour;
        }
    }
}

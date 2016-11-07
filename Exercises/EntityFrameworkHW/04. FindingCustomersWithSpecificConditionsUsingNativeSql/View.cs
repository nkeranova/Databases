namespace FindingCustomersWithSpecificConditionsUsingNativeSql
{
    using System;

    public class View
    {
        public string Customer { get; set; }

        public DateTime OrderYear { get; set; }

        public string ShipCountry { get; set; }

        public override string ToString()
        {
            return "Customer: " + this.Customer +
                   ", Order Year: " + this.OrderYear +
                   ", Ship Country: " + this.ShipCountry;
        }
    }
}
using System.Collections.Generic;

namespace DotnetQaFront.Models
{
    public class CreditCardExceptionModel
    {
        public CreditCardExceptionModel(string Name, string NumberCard, string ValidationCard, string NumberCardSegrete)
        {
            this.Name = Name;
            this.NumberCard = NumberCard;
            this.ValidationCard = ValidationCard;
            this.NumberCardSegrete = NumberCardSegrete;
        }

        public string Name { get; set; }
        public string NumberCard { get; set; }
        public string ValidationCard { get; set; }
        public string NumberCardSegrete { get; set; }
    }
}
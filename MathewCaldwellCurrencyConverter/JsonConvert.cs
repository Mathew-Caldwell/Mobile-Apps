using System;
using System.Collections.Generic;
using System.Text;

namespace MathewCaldwellCurrencyConverter
{

    public class CurrencyJSONRootObject
    {
        public string disclaimer { get; set; }
        public string license { get; set; }
        public int timestamp { get; set; }
        public string _base { get; set; }
        public Rates rates { get; set; }
    }

    public class Rates
    {
        public float AUD { get; set; }
        public float CAD { get; set; }
        public float EUR { get; set; }
        public float GBP { get; set; }
        public float IDR { get; set; }
        public float INR { get; set; }
        public float JPY { get; set; }
        public float NZD { get; set; }
        public int USD { get; set; }
    }

}

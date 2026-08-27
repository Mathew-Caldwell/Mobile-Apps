using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using Newtonsoft;
using Newtonsoft.Json;

namespace MathewCaldwellCurrencyConverter
{
    public partial class MainPage : ContentPage
    {
        public List<string> currencyList = new List<string>();
        public string number;
        CurrencyJSONRootObject currency {  get; set; }

        
        public MainPage()
        {
            InitializeComponent();
            Test();
            List<string> fieldNames = typeof(Rates).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(field => field.Name).ToList();
            foreach(string field in fieldNames)
            {
                currencyList.Add(field);
            }
            Currencies.ItemsSource = currencyList;
        }

        public async void GetAPI()
        {

        }

        void Test()
        {
            var jsonString = @"{" +
                "\"disclaimer\": \"Usage subject to terms: https://openexchangerates.org/terms\"," +
                "\"license\": \"https://openexchangerates.org/license\"," +
                "\"timestamp\": 1722506400," +
                "\"base\": \"USD\"," +
                "\"rates\": {" +
                    "\"AUD\": 1.532673," +
                    "\"CAD\": 1.38327," +
                    "\"EUR\": 0.927796," +
                    "\"GBP\": 0.784006," +
                    "\"IDR\": 16267.05072," +
                    "\"INR\": 83.725572," +
                    "\"JPY\": 149.95677778," +
                    "\"NZD\": 1.683006," +
                    "\"USD\": 1" +
                "}" +
            "}";
            currency = JsonConvert.DeserializeObject<CurrencyJSONRootObject>(jsonString);
            
        }

        private void NumberPadClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string name = button.StyleId;
            if (number != null && number.Contains("."))
            {
                string[] part = number.Split('.');
                if (part[1].Length < 2)
                {
                    number = name switch
                    {
                        "bt9" => number + "9",
                        "bt8" => number + "8",
                        "bt7" => number + "7",
                        "bt6" => number + "6",
                        "bt5" => number + "5",
                        "bt4" => number + "4",
                        "bt3" => number + "3",
                        "bt2" => number + "2",
                        "bt1" => number + "1",
                        "bt0" => number + "0",
                        "btpoint" => number
                    };
                }
            }
            else
            {
                number = name switch
                {
                    "bt9" => number + "9",
                    "bt8" => number + "8",
                    "bt7" => number + "7",
                    "bt6" => number + "6",
                    "bt5" => number + "5",
                    "bt4" => number + "4",
                    "bt3" => number + "3",
                    "bt2" => number + "2",
                    "bt1" => number + "1",
                    "bt0" => number + "0",
                    "btpoint" => number + ".",
                };
            }
            Input.Text = number;
        }

        private void Currencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currencySelected = (string)e.CurrentSelection.FirstOrDefault();
            PropertyInfo property = currency.rates.GetType().GetProperty(currencySelected);
            float AUD = currency.rates.AUD;
            if(this.number == null)
            {
                this.number = "1";
            }
            float number = float.Parse(this.number);
            float AUDtoUSD = number / AUD;
            float exchange = (float)Convert.ToSingle(property.GetValue(currency.rates));
            float toWantedCurrency = (float)Math.Round(AUDtoUSD * exchange, 2);
            Output.Text = $"${number}AUD = ${toWantedCurrency}{currencySelected}";

            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.number = null;
            Output.Text = "$XX.XX AUD = $XX.XX AUD";
            Input.Text = "0.00";
        }
    }
}

using System.Diagnostics;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;

namespace MathewCaldwellCurrencyConverter
{
    public partial class MainPage : ContentPage
    {
        public List<string> currencyList = new List<string>();

        
        public MainPage()
        {
            InitializeComponent();
            Test();
            currencyList.Add("AUD");
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
            var currency = JsonConvert.DeserializeObject<CurrencyJSONRootObject>(jsonString);
            
        }

        private void bt7_Clicked(object sender, EventArgs e)
        {

        }
    }
}

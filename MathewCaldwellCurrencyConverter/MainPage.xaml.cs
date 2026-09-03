using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using Newtonsoft;
using Newtonsoft.Json;

namespace MathewCaldwellCurrencyConverter
{
    public partial class MainPage : ContentPage
    {
        public List<string> currencyList = new List<string>(); // list of all types of currency

        string number; // string of the current input
        CurrencyJSONRootObject currency {  get; set; } // class wide accessable version of the deserialised json

        string APILink = "https://openexchangerates.org/api/latest.json?app_id=744c0e65d9ae400eae78bcbf1151ff54";

        
        public MainPage()
        {
            InitializeComponent();

            GetAPI();

            // looks through the JsonConvert class and adds all the fields under rates as a string to a list
            List<string> fieldNames = typeof(Rates).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(field => field.Name).ToList();

            foreach(string field in fieldNames)
            {
                currencyList.Add(field);
            }

            Currencies.ItemsSource = currencyList;
        }

        /// <summary>
        /// Fetches the exchange rate API
        /// </summary>
        public async void GetAPI()
        {
            var client = new HttpClient();
            var responce = await client.GetAsync(APILink);

            while(responce.StatusCode != System.Net.HttpStatusCode.OK || responce.Content == null)
            {
                await DisplayAlertAsync("Error", string.Format("Connection failed attempting reconnection", responce.StatusCode), "OK");
                responce = await client.GetAsync(APILink);
            }

            var responceString = await responce.Content.ReadAsStringAsync();
            currency = JsonConvert.DeserializeObject<CurrencyJSONRootObject>(responceString);
        }

        /// <summary>
        /// Number pad input system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Converts AUD input to selected currency 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Currencies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currencySelected = (string)e.CurrentSelection.FirstOrDefault();

            PropertyInfo property;
            float AUD = 1.395f;
            float exchange = 1;

            if (currency != null)
            {
                property = currency.rates.GetType().GetProperty(currencySelected);
                AUD = currency.rates.AUD;
                exchange = (float)Convert.ToSingle(property.GetValue(currency.rates)); // getting conversion rate of selected currency
            }

            
            if(this.number == null)
            {
                this.number = "1";
            }

            float number = float.Parse(this.number);
            float AUDtoUSD = number / AUD;            
            float toWantedCurrency = (float)Math.Round(AUDtoUSD * exchange, 2);

            Output.Text = $"${number}AUD = ${toWantedCurrency}{currencySelected}";

            
        }

        /// <summary>
        /// Resets all inputs to start value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            this.number = null;
            Output.Text = "$XX.XX AUD = $XX.XX AUD";
            Input.Text = "0.00";
        }
    }
}

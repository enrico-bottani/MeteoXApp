using Java.Lang;
using Xamarin.Forms;

namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        public string ForecastIcon { get; set; }
        public string NomeCitta { get; set; }
        public string Temp { get; set; }
        public string MaxTemp { get; set; }
        public string MinTemp { get; set; }
        public string ForecastExtended { get; set; }

        public MeteoItemPage()
        {
            InitializeComponent();
            ForecastIcon = "sunny.png";
            NomeCitta = "L'isola che non c'é";
            Temp = Integer.ToString(30);
            MaxTemp = Integer.ToString(45);
            MinTemp = Integer.ToString(15);
            ForecastExtended = "Parzialmente nuvoloso con tracce di sole e neve";
        }
    }
}
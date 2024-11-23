namespace ShopTARgv23.Models.OpenWeatherMap
{
    public class OpenWeatherMapViewModel
    {
        public string city { get; set; }
        public string country { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public double WindSpeed { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}

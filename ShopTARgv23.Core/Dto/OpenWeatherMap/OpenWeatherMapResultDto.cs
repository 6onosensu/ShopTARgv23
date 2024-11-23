using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARgv23.Core.Dto.OpenWeatherMap
{
    public class OpenWeatherMapResultDto
    {
        public string city {  get; set; }
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

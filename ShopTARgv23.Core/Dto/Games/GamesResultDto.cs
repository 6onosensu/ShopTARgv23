﻿namespace ShopTARgv23.Core.Dto.Games
{
    public class GamesResultDto
    {
        public List<GameDto> GameDto { get; set; }
    }
    public class GameDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string short_description { get; set; }
        public string game_url { get; set; }
        public string genre { get; set; }
        public string platform { get; set; }
        public string publisher { get; set; }
        public string developer { get; set; }
        public string release_date { get; set; }
        public string freetogame_profile_url { get; set; }
    }
}

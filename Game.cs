﻿using Newtonsoft.Json;

namespace FunctionApp
{
    /// <summary>
    /// Represent a game.
    /// </summary>
    public class Game
    {
        public string Id { get; set; }

        public string Image { get; set; }

        public string Thumbnail { get; set; }

        public string Name { get; set; }

        [JsonProperty("owned")]
        public bool IsOwned { get; set; }

        [JsonProperty("want")]
        public bool IsWanted { get; set; }

        public bool IsExpansion { get; set; }
    }
}

﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace footballnet.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayerRole
    {
        [EnumMember(Value = "V")]
        Goalkeeper = 'V',

        [EnumMember(Value = "A")]
        Defender = 'A',

        [EnumMember(Value = "U")]
        Forward = 'U'
    }

    public class PlayerNr
    {
        public int Id { get; set; }
        public int Nr { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }

        [JsonProperty("Vards")]
        public string Firstname { get; set; }

        [JsonProperty("Uzvards")]
        public string Lastname { get; set; }

        [JsonProperty("Nr")]
        public int Number { get; set; }

        [JsonProperty("Loma")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerRole Role { get; set; }

        public string Team { get; set; }

        public int Goals { get; set; }
        public int Passes { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesPlayedInMainTeam { get; set; }
        public int MinutesPlayed { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int TotalGoalsMissed { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public float AvgGoalsMissed { get; set; }
    }

    public class PlayerRecord
    {
        public int Id { get; set; }

        [JsonProperty("Speletajs")]
        public List<Player> Players { get; set; }
    }

    public class PlayerNrRecord
    {
        public int Id { get; set; }

        [JsonProperty("Speletajs")]
        public List<PlayerNr> PlayersNrs { get; set; }
    }
}
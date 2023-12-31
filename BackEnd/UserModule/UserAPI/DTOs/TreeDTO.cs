﻿using System.Text.Json.Serialization;
using TechTitansAPI.Models;

namespace TechTitansAPI.DTOs
{
    public enum TreeExtinctionIndex
    {
        CR, EN, VU, NT, LC, DD, NE, NA
    }
    public class TreeDTO
	{

        [JsonPropertyName("scientificName")]
        public string ScientificName { get; set; }

        [JsonPropertyName("commonName")]
        public string CommonName { get; set; }

        [JsonPropertyName("treeExtinctionIndex")]
        public TreeExtinctionIndex TreeExtinctionIndex { get; set; }

        [JsonPropertyName("zoochory")]
        public int Zoochory { get; set; }

        [JsonPropertyName("absorbedCo2")]
        public double AbsorbedCo2 { get; set; }

        [JsonPropertyName("ownerCPF")]
        public string OwnerCPF { get; set; }

	}
}

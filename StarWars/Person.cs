using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars
{
	public class Person
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("height")]
		public string Height { get; set; }
		[JsonProperty("mass")]
		public string Mass { get; set; }
		[JsonProperty("hair_color")]
		public string HairColor { get; set; }
		[JsonProperty("skin_color")]
		public string SkinСolor { get; set; }
		[JsonProperty("eye_color")]
		public string EyeColor { get; set; }
		[JsonProperty("birth_year")]
		public string BirthYear { get; set; }
		[JsonProperty("gender")]
		public string Gender { get; set; }
		[JsonProperty("homeworld")]
		public string Homeworld { get; set; }
		//public List<string> films { get; set; }
		//public List<string> species { get; set; }
		//public List<object> vehicles { get; set; }
		//public List<object> starships { get; set; }
		[JsonProperty("created")]
		public DateTime Created { get; set; }
		[JsonProperty("edited")]
		public DateTime Edited { get; set; }
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}

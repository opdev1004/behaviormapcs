using System.Text.Json;

namespace BehaviorMap
{
	public class StringBehaviorDictionary
	{
		public Dictionary<string, string> BD = [];

		public void Add(string state, string behavior)
		{
			BD.Add(state, behavior);
		}

		public void Remove(string state)
		{
			BD.Remove(state);
		}

		public void Update(string state, string behavior)
		{
			BD[state] = behavior;
		}

		public string Get(string state)
		{
			if (BD.TryGetValue(state, out string? behavior))
			{
				if (behavior == null) return "";

				return behavior;
			}

			return "";
		}

		public string SerializeToJson()
		{
			return JsonSerializer.Serialize(BD);
		}

		public void DeserializeFromJson(string jsonString)
		{
			Dictionary<string, string>? dictionary = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

			if (dictionary != null) BD = dictionary;
		}
	}
}

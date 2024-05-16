using System.Text.Json;

namespace BehaviorMap
{
	public class StringStatefulBehaviorDictionary
	{
		public string CurrentState = "";
		public string PreviousState = "";
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

		public void Set(string state)
		{
			PreviousState = CurrentState;
			CurrentState = state;
		}

		public string Get()
		{
			if (BD.TryGetValue(CurrentState, out string? behavior))
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

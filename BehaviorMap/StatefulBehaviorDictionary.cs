namespace BehaviorMap
{
	public class StatefulBehaviorDictionary
	{
		public string CurrentState = "";
		public string PreviousState = "";
		public delegate void BDDelegate();
		public Dictionary<string, BDDelegate> BD = [];

		public void Add(string state, BDDelegate bddelegate)
		{
			BD.Add(state, bddelegate);
		}

		public void Remove(string state)
		{
			BD.Remove(state);
		}

		public void Update(string state, BDDelegate bddelegate)
		{
			BD[state] = bddelegate;
		}

		public void Set(string state)
		{
			PreviousState = CurrentState;
			CurrentState = state;
		}

		public void Invoke()
		{
			if (BD.TryGetValue(CurrentState, out BDDelegate? bddelegate))
			{
				bddelegate();
			}
		}
	}
}

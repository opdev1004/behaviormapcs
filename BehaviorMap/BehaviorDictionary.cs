namespace BehaviorMap
{
	public class BehaviorDictionary
	{
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

		public void Invoke(string state)
		{
			if (BD.TryGetValue(state, out BDDelegate? bddelegate))
			{
				bddelegate();
			}
		}
	}
}

using BehaviorMap;

namespace UnitTest
{
	public class BMTest
	{
		readonly BehaviorDictionary BD = new();

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			int a = 0;

			BD.Add("test", () => {
				Console.WriteLine("This is test!");
				a = 5;
			});

			BD.Invoke("test");

			Assert.That(a, Is.EqualTo(5));
		}
	}
}
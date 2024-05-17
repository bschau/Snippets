/**
 * Add the MsTest.TestAdapter and MsTest.TestFramework nuget packages
 * to your solution.
 */
[TestClass]
public class NumbersTests
{
	[DataRow(0, 0)]
	[DataRow(1, 1)]
	[DataRow(2, 1)]
	[DataTestMethod]
	public void VerifyThatTwoSelectedNumbersAreEqual(int number1, int number2)
	{
		Assert.AreEqual(number1, number2);
	}
}

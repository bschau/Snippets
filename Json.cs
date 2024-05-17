using System;
using System.Text.Json;

public class Program
{
	class JTest
	{
		public string Key { get; set; }
	}

	public static void Main()
	{
		var jtest = new JTest
		{
			Key = "Hello+world"
		};
		var json = JsonSerializer.Serialize(jtest);
		Console.WriteLine("Default: {json}");

		var options = new JsonSerializerOptions
		{
			// JsonSerializer serializes + to \u002B by default
			Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		json = JsonSerializer.Serialize(jtest, options);
		Console.WriteLine("Websafe: {json}");
	}
}

/* Output:
Default: {"Key":"Hello\u002Bworld"}
Websafe: {"Key":"Hello+world"}
*/


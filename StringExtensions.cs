using System.Linq;

namespace Extensions
{
	public static class StringExtensions
	{
		public static string AddGenitiv(this string source)
		{
			if (string.IsNullOrEmpty(source))
			{
				return source;
			}

			var lastCharacter = source[source.Length - 1];
			if (lastCharacter == 's' || lastCharacter == 'x' || lastCharacter == 'z')
			{
				return $"{source}'s";
			}

			return $"{source}s";
		}

		public static string RemoveDiacritics(this string source)
		{
			char[] allowed = { 'æ', 'ø', 'å', 'Æ', 'Ø', 'Å' };
			return new string(source.Where(c => allowed.Contains(c) || (c >= 0x20 && c < 0x7f && c != ':' && c != '*')).ToArray());
		}
	}
}


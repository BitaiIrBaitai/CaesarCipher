internal class Program
{
	private static void Main(string[] _)
	{
		string msg = @"Skirtingai nuo piktografinių bei logografinių sistemų, kuriose ženklai žymi žodžius (pvz., galvijas, gražus, prastai), abėcėlė yra fonografinė sistema: ženklai reiškia garsus, iš kurių junginių susidaro žodžiai. Tačiau ji skiriasi nuo kitų fonografinių sistemų, – abugidų, abdžadų ir skiemeninių raštų, – tuo, kad čia naudojami ženklai reiškia tik vieną fonemą, ir didelis vaidmuo atitenka balsiams.";
		byte shift = 8;
		string encrypted = Encrypt(msg, shift);
        Console.WriteLine(encrypted);
		string decrypted = Decrypt(encrypted, shift);
		Console.WriteLine(decrypted);
    }

	private static string Encrypt(string msg, byte shift)
	{
		const string LOWER_LETTERS = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž";
		const string UPPER_LETTERS = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ";
		char[] result = new char[msg.Length];
		
		for (int i = 0; i < msg.Length; i++)
		{
			char c = msg[i];
			if (LOWER_LETTERS.Contains(c))
			{
				result[i] = ShiftLetter(shift, LOWER_LETTERS, c);
			}
			else if (UPPER_LETTERS.Contains(c))
			{
				result[i] = ShiftLetter(shift, UPPER_LETTERS, c);
			}
			else
			{
				result[i] = c;
			}
		}

		return new string(result);
	}

	private static string Decrypt(string msg, byte shift)
	{
		const string LOWER_LETTERS = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž";
		const string UPPER_LETTERS = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ";
		char[] result = new char[msg.Length];

		for (int i = 0; i < msg.Length; i++)
		{
			char c = msg[i];
			if (LOWER_LETTERS.Contains(c))
			{
				result[i] = ShiftLetteBack(shift, LOWER_LETTERS, c);
			}
			else if (UPPER_LETTERS.Contains(c))
			{
				result[i] = ShiftLetteBack(shift, UPPER_LETTERS, c);
			}
			else
			{
				result[i] = c;
			}
		}

		return new string(result);
	}

	private static char ShiftLetter(byte shift, string symbols, char c)
	{
		int index = symbols.IndexOf(c);
		int newIndex = (index + shift) % symbols.Length;
		return symbols[newIndex];
	}

	private static char ShiftLetteBack(byte shift, string symbols, char c)
	{
		int index = symbols.IndexOf(c);
		int newIndex = index - shift;
		while (newIndex < 0)
			newIndex += symbols.Length;
		return symbols[newIndex];
	}
}

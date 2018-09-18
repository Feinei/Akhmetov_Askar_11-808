namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            // на окончание влияют две последние/последняя цифры
            int ending2 = count % 100;
            int ending1 = count % 10;
            if ((ending1 == 1) && (ending2 != 11)) return "рубль";
            else if ((ending1 >= 2) && (ending1 <= 4) && (ending2 < 12) && (ending2 >14)) return "рубля";
                 else return "рублей";
		}
	}
}
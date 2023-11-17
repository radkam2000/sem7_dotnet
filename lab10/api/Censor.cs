namespace api
{
    public class Censor
    {
        /// <summary>
        /// Lista słów, które mają zostać ocenzurowane w tekście
        /// </summary>
        public List<string> Blacklist { get; set; } = new List<string>();

        /// <summary>
        /// Funkcja cenzurująca pojedyncze słowo.
        /// 
        /// Słowa, które znajdują się na liście <see cref="Blacklist"/> mają zostać zamienione
        /// na pierwszą literę oraz taką liczbę gwiazdek, ile miało oryginalne słowo,
        /// np. "bomba" na "b****"
        /// </summary>
        /// <param name="word">Słowo nieocenzurowane</param>
        /// <returns>Słowo ocenzurowane</returns>
        public string CensorWord(string word)
        {
            return word;
        }

        /// <summary>
        /// Funkcja cenzurująca cały tekst, który możę się składać z wielu słów.
        /// 
        /// Można zignorować znaki przestankowe (,."?! itp.) oraz nadmiarowe spacje w środku tekstu.
        /// </summary>
        /// <param name="text">Tekst nieocenzurowany</param>
        /// <returns>Tekst ocenzurowany</returns>
        public string CensorText(string text)
        {
            return text;
        }
    }
}

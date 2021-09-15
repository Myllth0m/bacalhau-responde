namespace BacalhauResponde.Extentions
{
    public static class StringExtencoes
    {
        public static string BuscarPrimeiroNome(this string nomeCompleto)
        {
            int identificadorDoPrimeiroEspacoEmBranco = nomeCompleto.IndexOf(" ");

            string primeiroNome = nomeCompleto.Substring(0, identificadorDoPrimeiroEspacoEmBranco);

            return primeiroNome;
        }
    }
}

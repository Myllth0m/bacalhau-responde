namespace BacalhauResponde.Extentions
{
    public static class StringExtencoes
    {
        public static string BuscarPrimeiroNome(this string nomeCompleto)
        {
            int identificadorDoPrimeiroEspacoEmBranco = nomeCompleto.IndexOf(" ");

            if (identificadorDoPrimeiroEspacoEmBranco.Equals(-1))
                return nomeCompleto;

            string primeiroNome = nomeCompleto.Substring(0, identificadorDoPrimeiroEspacoEmBranco);

            return primeiroNome;
        }
    }
}

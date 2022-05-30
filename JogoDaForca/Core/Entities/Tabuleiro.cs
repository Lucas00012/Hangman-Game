using JogoDaForca.Core.Helpers;

namespace JogoDaForca.Core.Entities
{
    public class Tabuleiro
    {
        private string Palavra { get; set; }
        private int Vidas { get; set; }

        private List<char> LetrasHistorico { get; set; } = new List<char>();

        public void Jogar(int vidas)
        {
            Console.Clear();
            PrepararJogo(vidas);

            while (true)
            {
                MostrarSituacaoTabuleiro();

                Console.Write("Digite uma letra: ");
                var letra = char.ToUpper(Console.ReadKey().KeyChar);

                Console.Clear();

                if (!char.IsLetter(letra) || LetrasHistorico.Contains(letra))
                {
                    Console.WriteLine("Letra inválida ou já escolhida!");
                    continue;
                }

                EscolherLetra(letra);

                if (VerificarDerrota() || VerificarVitoria())
                {
                    Console.Clear();
                    Console.WriteLine("FIM DE JOGO!");
                    Console.WriteLine($"VOCÊ {(VerificarDerrota() ? "PERDEU" : "GANHOU")}");
                    Console.WriteLine($"A PALAVRA ERA: {Palavra}");

                    return;
                }
            }
        }

        private void EscolherLetra(char letra)
        {
            LetrasHistorico.Add(letra);

            if (!Palavra.Contains(letra))
            {
                Vidas--;
                Console.WriteLine("Oops! Você perdeu uma vida!");
            }
        }

        private void PrepararJogo(int vidas)
        {
            SortearPalavra();

            Vidas = vidas;
            LetrasHistorico.Clear();
        }

        private void SortearPalavra()
        {
            Console.WriteLine("CARREGANDO....");
            Palavra = ScrapperHelper.ObterPalavra().Result;

            Console.Clear();
        }

        private void MostrarSituacaoTabuleiro()
        {
            Console.WriteLine($"VIDAS: {Vidas}");
            Console.WriteLine($"LETRAS USADAS: {(LetrasHistorico.Any() ? string.Join(", ", LetrasHistorico) : "nenhuma")}");
            Console.WriteLine();
            Console.Write("PALAVRA: ");

            foreach (var caracterePalavra in Palavra)
                Console.Write(PodeExibirCaractere(caracterePalavra) ? caracterePalavra : '_');

            Console.WriteLine();
        }

        private bool PodeExibirCaractere(char caractere)
        {
            return char.IsWhiteSpace(caractere) || LetrasHistorico.Contains(caractere);
        }

        private bool VerificarVitoria()
        {
            return Palavra.All(caracterePalavra => PodeExibirCaractere(caracterePalavra));
        }

        private bool VerificarDerrota()
        {
            return Vidas < 0;
        }
    }
}

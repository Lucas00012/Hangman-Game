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

            while (!VerificarDerrota() && !VerificarVitoria())
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

                LetrasHistorico.Add(letra);

                if (!Palavra.Contains(letra))
                {
                    Vidas--;
                    Console.WriteLine("Oops! Você perdeu uma vida!");
                }
            }

            Console.Clear();
            Console.WriteLine("FIM DE JOGO!");
            Console.WriteLine($"VOCÊ {(VerificarDerrota() ? "PERDEU" : "GANHOU")}");
            Console.WriteLine($"A PALAVRA ERA: {Palavra}");
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

            var html = ScrapperHelper.ObterHtml("https://www.palabrasaleatorias.com/palavras-aleatorias.php").Result;
            var palavra = html.DocumentNode.SelectSingleNode("//html/body/center/table/tr/td/div").InnerText.ToUpper();

            Palavra = palavra.Replace("\r\n", string.Empty);

            Console.Clear();
        }

        private void MostrarSituacaoTabuleiro()
        {
            Console.WriteLine($"VIDAS: {Vidas}");
            Console.WriteLine($"LETRAS USADAS: {(LetrasHistorico.Any() ? string.Join(", ", LetrasHistorico) : "nenhuma")}");
            Console.WriteLine();
            Console.Write("PALAVRA: ");

            foreach (var caractere in Palavra)
                Console.Write(PodeExibirCaractere(caractere) ? caractere : '_');

            Console.WriteLine();
        }

        private bool PodeExibirCaractere(char caractere)
        {
            return char.IsWhiteSpace(caractere) || LetrasHistorico.Contains(caractere);
        }

        private bool VerificarVitoria()
        {
            return Palavra.All(caractere => PodeExibirCaractere(caractere));
        }

        private bool VerificarDerrota()
        {
            return Vidas == -1;
        }
    }
}

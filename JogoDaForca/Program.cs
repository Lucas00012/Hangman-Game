using JogoDaForca.Core.Entities;

Console.WriteLine(@"

     ██╗ ██████╗  ██████╗  ██████╗     ██████╗  █████╗ 
     ██║██╔═══██╗██╔════╝ ██╔═══██╗    ██╔══██╗██╔══██╗
     ██║██║   ██║██║  ███╗██║   ██║    ██║  ██║███████║
██   ██║██║   ██║██║   ██║██║   ██║    ██║  ██║██╔══██║
╚█████╔╝╚██████╔╝╚██████╔╝╚██████╔╝    ██████╔╝██║  ██║
 ╚════╝  ╚═════╝  ╚═════╝  ╚═════╝     ╚═════╝ ╚═╝  ╚═╝
                                                       
███████╗ ██████╗ ██████╗  ██████╗ █████╗               
██╔════╝██╔═══██╗██╔══██╗██╔════╝██╔══██╗              
█████╗  ██║   ██║██████╔╝██║     ███████║              
██╔══╝  ██║   ██║██╔══██╗██║     ██╔══██║              
██║     ╚██████╔╝██║  ██║╚██████╗██║  ██║              
╚═╝      ╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝              

Como jogar?
- Escolha uma letra até o jogo acabar
- Você ganha se encontrar todas as letras da palavra sorteada
- Você perde caso as suas vidas fiquem abaixo de 0 durante o processo

Pressione qualquer tecla para continuar...
");

Console.ReadKey();
Console.Clear();

Console.Write("Digite o nº de vidas: ");
var vidas = int.Parse(Console.ReadLine());

var tabuleiro = new Tabuleiro();
char opcao;

do
{
    tabuleiro.Jogar(vidas);

    do
    {
        Console.WriteLine();
        Console.WriteLine("Deseja jogar novamente? S/N");

        opcao = char.ToUpper(Console.ReadKey().KeyChar);
    } while (opcao != 'S' && opcao != 'N');
} while (opcao == 'S');
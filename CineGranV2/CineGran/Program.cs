using Cinema.Models;

namespace Cinema;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sistema de Cinema");

        Sala salaPrincipal = new(10, 20);
        Sala salaA = new(10, 10);

        salaPrincipal.ExibirMapa();


        Filme avatar = new(
            titulo:"Avatar: O Caminho da Água",
            diretor:"James Cameron",
            duracaoMinutos:192,
            genero:"Ficção Científica",
            anoLancamento:2022,
            classificacao:"12"
            );

        Sessao sessao1 = new(
            filme: avatar,
            sala: salaPrincipal,
            horario: DateTime.Parse("29/05/2026 19:00:00"),
            precoIngresso: 35
        );

        Sessao sessao2 = new(
            filme: avatar,
            sala: salaPrincipal,
            horario: new DateTime(2026, 5, 29, 21, 30, 0),
            precoIngresso: 30
        );

        Console.WriteLine($"\nSessão 1:");
        sessao1.OcuparPoltrona('B', 2, 15); // Compra válida
        sessao1.OcuparPoltrona('A', 4, 10);
        sessao1.ExibirMapaOcupacao();
    }
}

 
namespace Cinema.Models;

public class Sessao
{
    private Filme filme;
    private Sala sala;
    private DateTime horario;
    private double precoIngresso;
    private bool[,] poltronasOcupadas;

    public Sessao(Filme filme, Sala sala, DateTime horario, double precoIngresso)
    {
        this.filme = filme;
        this.sala = sala;
        this.horario = horario;
        this.precoIngresso = precoIngresso;
        this.poltronasOcupadas = new bool[sala.QtdeFileiras, sala.QtdePoltronasPorFileira];
    }

    public Filme Filme => filme;
    public Sala Sala => sala;
    public DateTime Horario => horario;
    public double PrecoIngresso
    {
        get => precoIngresso;
        set => precoIngresso = value;
    }

    public bool OcuparPoltrona(char fileira, int poltrona, int idadeEspectador)
    {
        poltrona -= 1; // Ajusta para índice zero-based
        if (!sala.PoltronaExiste(fileira, poltrona))
        {
                        Console.WriteLine("Poltrona inválida.");
            return false;
        }

        if (!filme.PodeAssistir(idadeEspectador))
        {
            Console.WriteLine($"\nAcesso negado! Classificação {filme.Classificacao} anos.");
            return false;
        }

        int fileiraIndex = sala.GetIndiceFileira(fileira);
        if(poltronasOcupadas[fileiraIndex, poltrona])
        {
            Console.WriteLine($"Poltrona {fileira}{poltrona+1} já ocupada.");
            return false;
        }

        poltronasOcupadas[fileiraIndex, poltrona] = true;
        Console.WriteLine($"Compra realizada com sucesso!");
        Console.WriteLine($"Filme: {filme.Titulo}!");
        Console.WriteLine($"Horário: {horario:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Poltrona: {fileira}{poltrona+1}");
        Console.WriteLine($"Preço do ingresso: R${precoIngresso:F2}");
        return true;

    }

    public void ExibirMapaOcupacao()
    {
        Console.WriteLine($"\nMapa de Poltronas para {filme.Titulo} - {horario:dd/MM/yyyy HH:mm}");
        sala.ExibirMapa(poltronasOcupadas);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Detalhes da Sessão:");
        Console.WriteLine($"Filme: {filme.Titulo}!");
        Console.WriteLine($"Horário: {horario:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Preço do ingresso: R${precoIngresso:F2}");
        Console.WriteLine($"Sala: {sala.QtdeFileiras} fileiras X {sala.QtdePoltronasPorFileira} poltronas por fileira");

        int ocupadas = 0;
        for (int i = 0; i < sala.QtdeFileiras; i++)
        {
            for (int j = 0; j < sala.QtdePoltronasPorFileira; j++)
            {
                if (poltronasOcupadas[i, j])
                    ocupadas++;
            }
        }
        int disponiveis = (sala.QtdeFileiras * sala.QtdePoltronasPorFileira) - ocupadas;
        Console.WriteLine($"Poltronas disponíveis: {disponiveis}");
    }

}
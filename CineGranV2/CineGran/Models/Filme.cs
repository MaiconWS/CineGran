namespace Cinema.Models;

public class Filme   // public class sinaliza que qualquer parte desse projeto pode acessar essa classe, e a classe filme tem as seguintes propriedades: id, titulo, diretor, duracao e genero
{
    //atributos da classe filme
    private string titulo;
    private string diretor;
    private int duracaoMinutos;
    private string genero;
    private int anoLancamento;
    private string classificacao;

    // Metodo construtor para criar um objeto filme
    public Filme(string titulo, string diretor, int duracaoMinutos, string genero, int anoLancamento, string classificacao)
    {
        this.titulo = titulo;
        this.diretor = diretor;
        this.duracaoMinutos = duracaoMinutos;
        this.genero = genero;
        this.anoLancamento = anoLancamento;
        this.classificacao = classificacao;
    }

    // Métodos getters e setters para acessar os atributos do filme
    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Diretor
    {
        get { return diretor; }
        set { diretor = value; }
    }

    public int DuracaoMinutos
    {
        get { return duracaoMinutos; }
        set { duracaoMinutos = value; }
    }

    public string Genero
    {
        get { return genero; }
        set { genero = value; }
    }

    public int AnoLancamento
    {
        get { return anoLancamento; }
        set { anoLancamento = value; }
    }

    public string Classificacao
    {
        get { return classificacao; }
        set { classificacao = value; }
    }

    // Método para obter duração do filme em horas e minutos
    public string GetDuracaoFormatada()
    {
        int horas = duracaoMinutos / 60;
        int minutos = duracaoMinutos % 60;
        return $"{horas}h {minutos}min";
    }

    // Método para verificar se o filme é recomendado para menores de idade com base na classificação
    public bool PodeAssistir(int idadeEspectador)
    {
        if (classificacao == "Livre") return true;
        int idadeMinima = int.Parse(classificacao);
        return idadeEspectador >= idadeMinima;
    }

    // Método para exibir informações completas do filme
    public void ExibirInformacoes()
    {
        Console.WriteLine($"Título: {titulo}");
        Console.WriteLine($"Diretor: {diretor}");
        Console.WriteLine($"Duração: {GetDuracaoFormatada()}");
        Console.WriteLine($"Gênero: {genero}");
        Console.WriteLine($"Ano de Lançamento: {anoLancamento}");
        Console.WriteLine($"Classificação: {classificacao}");
    }
}
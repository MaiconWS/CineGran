class Program
{
    // Configuração da sala
    const int FILEIRAS = 10;
    const int POLTRONAS = 20;
    const double PRECO = 22.50;
    static readonly char[] LetrasFileira = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
    static bool[,] sala = new bool[FILEIRAS, POLTRONAS];
    //quantidade de virgulas determina a quantidade de tamanhos.

    //Contadores globais
    static double totalIngressos = 0;
    static int qtdIngressos = 0;
    static int qtdClientes = 0;
    static int qtdEstudantes = 0;

    static void Main()
    {
        EsvaziarSala();
        bool continuar = true;
        do
        {
            Console.Clear();
            Console.WriteLine("CINEGRAN");  
            DesenharSala();
            continuar = LerSimNao("Sessão ativa. Continuar vendendo ingressos ? (S/N): ");

            if (continuar)
            {
                Console.Write("Quantos ingressos deseja comprar? ");
                int qtde = int.Parse(Console.ReadLine() ?? "0"); //Valida a quantidade de ingressos
                if (qtde > 0) VenderIngresso(qtde);
            }
        } while (continuar);
        RelatorioFinal();
        
    }

    //region serve para separar uma área especifica.
    #region Métodos Utilitários
    //Inicializa todas as poltronas como livres (false)
    static void EsvaziarSala()
    {
        for (int i = 0; i < FILEIRAS; i++)
        {
            for (int j = 0; j < POLTRONAS; j++)
            {
                sala[i, j] = false;
            }
        }
    }
    //Converte a letra da Fileira('A'...'J') para o indice (0...9)
    //Retornar -1 se a letra não valida.
    static int IndiceFileira(char fileira)
    {
        for (int i = 0; i < FILEIRAS; i++)
        {
            if (LetrasFileira[i] == char.ToUpper(fileira))
            {
                return i;
            }
        }
        return -1;
    }

    //Tenta marcar uma poltrana. Retorna true se conseguir, false se já estava ocupada.
    //poltrona: número digitado pelo usuário (1...20)
    static bool MarcarPoltrona(char fileira, int poltrona)
    {
        int i = IndiceFileira(fileira);
        int j = poltrona - 1;
        //Verifica os limites da sala.
        if (i < 0 || j < 0 || j >= POLTRONAS)
        {
            return false;
        }
        if (sala[i, j])
        {
            return false;
        }
        sala[i, j] = true;
        return true;
    }

    //Exibir uma mensagem e aguardar o usúario pressionar Enter
    static void Pausar(string texto)
    {
        Console.WriteLine(texto);
        Console.WriteLine("Pressione [Enter] para continuar...");
        Console.ReadLine();
    }

    //Exiba uma mensagem e aguardar o usúario pressionar S ou N
    static bool LerSimNao(string pergunta)
    {
        while (true)
        {
            Console.Write(pergunta);
            string s = (Console.ReadLine() ?? "").Trim().ToUpper();

            if (s == "S" || s == "SIM")
            {
                return true;
            }
            if (s == "N" || s == "NAO" || s == "NÃO")
            {
                return false;
            }
            Console.WriteLine("Resposta inválida. Digite S ou N");
        }
    }

    //Exibe a sala marcando as poltronas já ocupadas.
    static void DesenharSala()
    {
        Console.Write("  ");
        for (int i = 1; i <= POLTRONAS; i++)
        {
            if (i <= 9)
            {
                Console.Write($"[  {i}]");
            }
            else
            {
                Console.Write($"[ {i}]");
            }
        }
        Console.WriteLine();
        //Desenhar fileiras - Fileiras: letra + poltrona
        for (int i = 0; i < FILEIRAS; i++)
        {
            Console.Write($"{LetrasFileira[i]} ");
            for (int j = 0; j < POLTRONAS; j++)
            {
                Console.Write(sala[i, j] ? "[ X ]" : "[   ]");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }

    #endregion
    //Lógica para vender ingressos
    static void VenderIngresso(int qtde)
    {
        double total = 0;
        int marcados = 0;

        qtdClientes += 1; //Atualiza o contador global de clientes.
        qtdIngressos += qtde; //Atualiza o contador global de ingressos vendidos.

        while (marcados < qtde)// Lógica para vender ingressos
        {
            Console.Write($"Digite a fileira do ingresso {marcados + 1}: ");
            Console.Write("Informe a letra da fileira (A-J): ");
            string filStr = Console.ReadLine() ?? "";
            char fil = filStr.Length > 0 ? filStr[0] : '?';

            Console.Write($"Informe a poltrona: ");
            int pol = int.Parse(Console.ReadLine() ?? "0");
            
            if (MarcarPoltrona(fil, pol))
            {
                bool estudante = LerSimNao("O cliente é estudante? (S/N): ");
                if (estudante)
                {
                    total += PRECO / 2.0; // Desconto de 50% para estudantes
                    qtdEstudantes += 1; //Atualiza o contador global de estudantes.
                }
                else
                {
                total += PRECO;
                }
                marcados++;
                Pausar("Ingresso marcado com sucesso!");
            }
            else
            {
                Console.WriteLine("Poltrona já ocupada ou inválida. Tente novamente.\n");
            }
        }
        Pausar($"Total a pagar: R$ {total:F2}");
        totalIngressos += total; //Atualiza o contador global de valor total dos ingressos vendidos.
    }

    static void RelatorioFinal()
    {
        Console.Clear();
        Console.WriteLine("Relatório Final de Vendas");
        Console.WriteLine($"Total de clientes............... {qtdClientes}");
        Console.WriteLine($"Total de estudantes............. {qtdEstudantes}");
        Console.WriteLine($"Total de ingressos vendidos..... {qtdIngressos}");
        Console.WriteLine($"Valor total arrecadado.......... R$ {totalIngressos:F2}");
    }


}
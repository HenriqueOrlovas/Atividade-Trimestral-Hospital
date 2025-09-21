using System;

class Program
{
    static void Main()
    {
        Paciente[] filaPacientes = new Paciente[15];
        int totalPacientes = 0;
        string opcao = "";

        while (opcao != "q" && opcao != "Q")
        {
            Console.WriteLine("1 - Cadastrar paciente");
            Console.WriteLine("2 - Listar pacientes");
            Console.WriteLine("3 - Atender paciente");
            Console.WriteLine("4 - Alterar dados do paciente");
            Console.WriteLine("q - Sair");
            Console.Write("Digite a opção: ");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                if (totalPacientes >= 15)
                {
                    Console.WriteLine("A fila de pacientes está cheia!");
                }
                else
                {
                    Paciente p = new Paciente();

                    Console.Write("Nome completo: ");
                    p.NomeCompleto = Console.ReadLine();

                    Console.Write("Data de nascimento (dd/mm/aaaa): ");
                    p.DataNascimento = Console.ReadLine();

                    Console.Write("Sexo: ");
                    p.Sexo = Console.ReadLine();

                    Console.Write("RG: ");
                    p.RG = Console.ReadLine();

                    Console.Write("CPF: ");
                    p.CPF = Console.ReadLine();

                    Console.Write("Telefone: ");
                    p.Telefone = Console.ReadLine();

                    Console.Write("Número do Cartão do SUS: ");
                    p.NumeroCartaoSUS = Console.ReadLine();

                    Console.Write("É preferencial? (s/n): ");
                    string pref = Console.ReadLine();
                    if (pref == "s" || pref == "S")
                        p.Preferencial = true;
                    else
                        p.Preferencial = false;

                    if (p.Preferencial)
                    {
                        int pos = 0;
                        while (pos < totalPacientes && filaPacientes[pos].Preferencial)
                        {
                            pos++;
                        }
                        for (int i = totalPacientes; i > pos; i--)
                        {
                            filaPacientes[i] = filaPacientes[i - 1];
                        }
                        filaPacientes[pos] = p;
                    }
                    else
                    {
                        filaPacientes[totalPacientes] = p;
                    }

                    totalPacientes++;

                    Console.WriteLine("Paciente cadastrado com sucesso!");
                    Console.ReadLine();
                }
            }
            else if (opcao == "2")
            {
                if (totalPacientes == 0)
                {
                    Console.WriteLine("Não há pacientes na fila.");
                }
                else
                {
                    for (int i = 0; i < totalPacientes; i++)
                    {
                        Paciente p = filaPacientes[i];
                        Console.WriteLine((i + 1) + " - " + p.NomeCompleto + " (Preferencial: " + (p.Preferencial ? "Sim" : "Não") + ")");
                    }
                }
                Console.ReadLine();
            }
            else if (opcao == "3")
            {
                if (totalPacientes == 0)
                {
                    Console.WriteLine("Não há pacientes para atender.");
                }
                else
                {
                    Paciente atendido = filaPacientes[0];
                    Console.WriteLine("Atendendo paciente: " + atendido.NomeCompleto);

                    for (int i = 1; i < totalPacientes; i++)
                    {
                        filaPacientes[i - 1] = filaPacientes[i];
                    }
                    totalPacientes--;

                    Console.WriteLine("Paciente atendido e removido da fila.");
                    Console.ReadLine();
                }
            }
            else if (opcao == "4")
            {
                if (totalPacientes == 0)
                {
                    Console.WriteLine("Não há pacientes na fila.");
                }
                else
                {
                    for (int i = 0; i < totalPacientes; i++)
                    {
                        Console.WriteLine((i + 1) + " - " + filaPacientes[i].NomeCompleto);
                    }

                    int escolha = int.Parse(Console.ReadLine()) - 1;

                    if (escolha >= 0 && escolha < totalPacientes)
                    {
                        Paciente p = filaPacientes[escolha];

                        Console.Write("Nome completo (" + p.NomeCompleto + "): ");
                        string novoNome = Console.ReadLine();
                        if (novoNome != "") p.NomeCompleto = novoNome;

                        Console.Write("Data de nascimento (" + p.DataNascimento + "): ");
                        string novaData = Console.ReadLine();
                        if (novaData != "") p.DataNascimento = novaData;

                        Console.Write("Sexo (" + p.Sexo + "): ");
                        string novoSexo = Console.ReadLine();
                        if (novoSexo != "") p.Sexo = novoSexo;

                        Console.Write("RG (" + p.RG + "): ");
                        string novoRG = Console.ReadLine();
                        if (novoRG != "") p.RG = novoRG;

                        Console.Write("CPF (" + p.CPF + "): ");
                        string novoCPF = Console.ReadLine();
                        if (novoCPF != "") p.CPF = novoCPF;

                        Console.Write("Telefone (" + p.Telefone + "): ");
                        string novoTel = Console.ReadLine();
                        if (novoTel != "") p.Telefone = novoTel;

                        Console.Write("Número do Cartão SUS (" + p.NumeroCartaoSUS + "): ");
                        string novoCartao = Console.ReadLine();
                        if (novoCartao != "") p.NumeroCartaoSUS = novoCartao;

                        Console.Write("É preferencial? (s/n) (" + (p.Preferencial ? "Sim" : "Não") + "): ");
                        string pref = Console.ReadLine();
                        if (pref == "s" || pref == "S") p.Preferencial = true;
                        else if (pref == "n" || pref == "N") p.Preferencial = false;

                        Console.WriteLine("Dados do paciente atualizados!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Paciente inválido.");
                        Console.ReadLine();
                    }
                }
            }
            else if (opcao == "q" || opcao == "Q")
            {
                Console.WriteLine("Saindo do software...");
            }
            else
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                Console.ReadLine();
            }
        }
    }
}

class Paciente
{
    public string NomeCompleto = "";
    public string DataNascimento = "";
    public string Sexo = "";
    public string RG = "";
    public string CPF = "";
    public string Telefone = "";
    public string NumeroCartaoSUS = "";
    public bool Preferencial;
}

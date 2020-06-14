using System;

namespace review
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = BuscaOpcao();
            do
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Aluno aluno = new Aluno();
                        Console.Write("Informe o nome do aluno: ");
                        aluno.Nome = Console.ReadLine();

                        Console.Write($"Informe nota do Aluno {aluno.Nome}: ");

                        //var nota = decimal.Parse(Console.ReadLine());
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal! Insira novamente: ");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (string.IsNullOrEmpty(a.Nome))
                            {
                                continue;
                            }
                            Console.WriteLine($"Aluno: {a.Nome}, Nota: {a.Nota}");
                        }
                        Console.WriteLine("Selecione qualquer tela para voltar ao Menu");
                        Console.ReadLine();
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var alunosTotal = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                alunosTotal++;
                            }
                            else break;
                        }

                        decimal mediaGeral = notaTotal / alunosTotal;
                        Console.WriteLine($"Média Geral: {mediaGeral}");
                        Console.WriteLine("Pressione qualquer tecla pra prosseguir");
                        Console.ReadLine();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Caracter inválido. Insira novamente");
                        break;
                }
                opcaoUsuario = BuscaOpcao();
            } while (opcaoUsuario.ToUpper() != "X");
        }

        private static string BuscaOpcao()
        {
            //Console.Clear();
            Console.WriteLine("Inserir o novo aluno:");
            Console.WriteLine("1 - Inserir aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

using System;
using System.Collections.Generic;

namespace cad_alunos_console
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";
            List<Aluno> alunos = new List<Aluno>();

            do
            {
                Console.WriteLine("---------------- Alunos ---------------------\n");
                Console.WriteLine("Informe a opção desejada:\n");
                Console.WriteLine("1 - Inserir novo Aluno");
                Console.WriteLine("2 - Listar ALunos");
                Console.WriteLine("3 - Calcular Média Geral");
                Console.WriteLine("x - Sair");
                Console.WriteLine("\n");

                opcao = Console.ReadLine();
                Console.Clear();

                if (opcao.ToUpper() != "X")
                {
                    switch (opcao)
                    {
                        case "1":
                            var aluno = new Aluno();
                            Console.WriteLine("----------- Inserir Aluno -----------");
                            Console.WriteLine("Nome do aluno: ");
                            aluno.Nome = Console.ReadLine();

                            Console.WriteLine("Nota do aluno: ");
                            if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                                aluno.Nota = nota;
                            }else{
                                throw new ArgumentException("A nota deve ser decimal");
                            }
                            alunos.Add(aluno);
                            break;
                        case "2":
                            Console.WriteLine("----------- Lista de Alunos -------------");
                            alunos.ForEach(a => {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}\n");
                            });
                            break;
                        case "3":
                            Console.WriteLine("------------ Média dos Alunos ------------");
                            decimal soma = 0;
                            alunos.ForEach(a => soma += a.Nota);

                            decimal media = soma/alunos.Count;

                            Console.WriteLine($"MEDIA: {media}");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Opção inválida");
                    }
                    Console.Beep();
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadLine();
                    Console.Clear();

                }

            } while (opcao.ToUpper() != "X");
        }
    }
}

using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Olá");
            string opcaomenu = Menu();

            while (opcaomenu.ToUpper() != "X")
            {

                switch (opcaomenu)
                {

                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        VizualizarSerie();
                        break;

                    case "5":
                        ExcluirSerie();
                        break;

                    default:
                        Console.WriteLine("Sua escolha é inválida, Digite novamente");
                        Console.WriteLine();
                        break;
                }

                opcaomenu = Menu();

            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");

        }
        static string Menu()
        {

            Console.WriteLine();
            Console.WriteLine("Selecione uma das opções a Seguir:");
            Console.WriteLine();

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Vizualizar Série");
            Console.WriteLine("5- Excluir Série");
            Console.WriteLine("X- Sair do Programa");
            Console.WriteLine();

            string opcaomenu = Console.ReadLine();
            Console.Clear();
            return opcaomenu;
        }

        static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine("Sua lista de Séries:");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Séria Cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {

                var Excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0} - {1} {2}", serie.retornaId(), serie.retornaNome(), (Excluido ? "*Excluido*" : ""));
            }
        }

        static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine("Insira sua Série:");
            Console.WriteLine();

            foreach (int x in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", x, Enum.GetName(typeof(Genero), x));
            }

            Console.WriteLine();
            Console.WriteLine("Digite uma das opções acima para informar o gênero: ");
            Console.WriteLine();
            int entradagenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o nome da série: ");
            Console.WriteLine();
            String entradanome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Dê uma descrição para a série: ");
            Console.WriteLine();
            string entradadescricao = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite o ano que foi criada: ");
            Console.WriteLine();
            int entradaAno = int.Parse(Console.ReadLine());

            Serie novaserie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradagenero,
                                        nome: entradanome,
                                        ano: entradaAno,
                                        descricao: entradadescricao);

            repositorio.Insere(novaserie);
            
            Console.WriteLine();
            Console.WriteLine("Série Inserida com sucesso!");
            Console.WriteLine("Digite enter para continuar!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void AtualizarSerie(){
            Console.Clear();
            Console.WriteLine("Deseja consultar a lista de séries?");
            Console.WriteLine("Digite Y para sim e N para não");
            Console.WriteLine();

            string opcaoatualizar = Console.ReadLine();
            Console.WriteLine();

            if (opcaoatualizar.ToUpper() == "Y"){
                ListarSeries();
            }

            Console.WriteLine();
            Console.WriteLine("Digite o ID da série: ");
            Console.WriteLine();
            int IndiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine();
            Console.WriteLine("Digite o gênero dentre as opções acima: ");
            Console.WriteLine();
            int entradagenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o Nome da série: ");
            Console.WriteLine();
            string entradanome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite o Ano da série: ");
            Console.WriteLine();
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Dê uma descrição a série: ");
            Console.WriteLine();
            String entradadescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: IndiceSerie,
                                            nome: entradanome,
                                            genero: (Genero)entradagenero,
                                            ano: entradaAno,
                                            descricao: entradadescricao);

            repositorio.Atualiza(IndiceSerie, atualizaSerie);

            Console.WriteLine();
            Console.WriteLine("Série atualizada com sucesso!");
            Console.WriteLine("Digite enter para continuar!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void VizualizarSerie(){
            Console.Clear();
            Console.WriteLine("Deseja consultar a lista de séries?");
            Console.WriteLine("Digite Y para sim e N para não");
            Console.WriteLine();

            string opcaoatualizar = Console.ReadLine();
            Console.WriteLine();

            if (opcaoatualizar.ToUpper() == "Y"){
                ListarSeries();
            }
            
            Console.WriteLine();
            Console.WriteLine("Digite o ID da série");
            Console.WriteLine();
            int IndiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(IndiceSerie);

            Console.WriteLine(serie);
            Console.WriteLine();
            Console.WriteLine("Digite enter para continuar!");
            Console.ReadLine();
            Console.Clear();
        }

        private static void ExcluirSerie(){
            Console.Clear();
            Console.WriteLine("Deseja consultar a lista de séries?");
            Console.WriteLine("Digite Y para sim e N para não");
            Console.WriteLine();

            string opcaoatualizar = Console.ReadLine();
            Console.WriteLine();

            if (opcaoatualizar.ToUpper() == "Y"){
                ListarSeries();
            }

            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);

            Console.WriteLine();
            Console.WriteLine("Série excluida com sucesso!");
            Console.WriteLine("Digite enter para continuar!");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

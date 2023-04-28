using app.Models;
using app.Servicos;
using ContratoPersistencia;
using JsonPersistencia;
using MongoDBPersistencia;
using PostgresPersistencia;



internal class Program
{
    private static void Main(string[] args)
    {

        //var persistencia = new Persistencia(new PersistenciaPostgres("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=123456;"));

       
        var persistencia = new Persistencia(new PersistenciaMongoDB( "clientes"));

        //var persistencia = new PersistenciaJson("cliente.json");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Digite uma das opções abaixo:");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Listar Cliente");
            Console.WriteLine("3 - Sair");

            var opcao = Console.ReadLine();
            var sair = false;

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Digite o nome do cliente");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Digite o telefone do cliente");
                    var telefone = Console.ReadLine();

                    persistencia.Salvar(new Cliente()
                    {
                        Nome = nome,
                        Telefone = telefone
                    });

                    Console.WriteLine("Cliente cadastrado com sucesso ...");
                    Thread.Sleep(1000);
                    break;
                case "2":
                    Console.WriteLine("=== Lista de clientes =====");

                    //var clientesArquivo = persistencia.Lista();
                    IEntidade cliente = new Cliente();
                    var clientesArquivo = persistencia.Lista();

                    foreach (Cliente cli in clientesArquivo)
                    {
                        Console.WriteLine($"Nome: {cli.Nome}");
                        Console.WriteLine($"Telefone: {cli.Telefone}");
                        Console.WriteLine("------------------------------");
                    }

                    Console.WriteLine("Pressione Enter para continuar ...");
                    Console.ReadKey();
                    break;
                default:
                    sair = true;
                    break;
            }

            if (sair) break;
        }
    }
}
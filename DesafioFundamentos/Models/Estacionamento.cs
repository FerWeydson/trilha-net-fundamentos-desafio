namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"

            // *IMPLEMENTE AQUI*
            string placaVeiculo = "";

            try
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placaVeiculo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(placaVeiculo) || placaVeiculo.Length > 7)
                {
                    Console.WriteLine("Placa inválida. A placa deve conter no máximo 7 caracteres. Tente novamente.");
                    return;
                }

                veiculos.Add(placaVeiculo);
                Console.WriteLine("Veículo adicionado com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar veículo: {ex.Message}");
            }

        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placaVeiculo = "";

            try
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                placaVeiculo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(placaVeiculo) || placaVeiculo.Length > 7)
                {
                    Console.WriteLine("Placa não existe no sistema ou está inválida.\n" +
                    "A placa deve conter no máximo 7 caracteres. Tente novamente.");
                    return;
                }
                

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placaVeiculo.ToUpper()))
                {
                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado

                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal               
                    // *IMPLEMENTE AQUI*

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    removerVeiculo(placaVeiculo);

                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    if (int.TryParse(Console.ReadLine(), out int horas))
                    {
                        decimal valorTotal = calcularPreco(horas);
                        Console.WriteLine($"O veículo de placa: {placaVeiculo} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de horas inválidas. Tente novamente.");
                    }

                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover veículo: {ex.Message}");
            }

        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine($"Os veículos estacionados são: ");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*

                for (int i = 0; i < veiculos.Count; i++)
                {
                    // Count = Length
                    Console.WriteLine($"Na vaga {i} está o veiculo de placa: {veiculos[i]}");
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        private void removerVeiculo(string placaVeiculo)
        {
            veiculos.Remove(placaVeiculo);
            Console.WriteLine("Veículo removido com sucesso!");
        }
        private decimal calcularPreco(int horas)
        {
            return (precoInicial + precoPorHora) * horas;
        }
        public static decimal ValidaValores(string msg)
        {
            decimal preco = 0;
            while (!decimal.TryParse(Console.ReadLine(), out preco))
            {
                Console.Clear();
                Console.WriteLine("Você digitou um valor inválido, tente novamente.");
                Console.WriteLine(msg);
            }
            return preco;
        }
    }
}
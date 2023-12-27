using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(placa))
                Console.WriteLine("A placa do veículo não pode estar vazia. Inclusão cancelada.");
            else
            {
                Veiculo veiculo = new Veiculo(placa);
                veiculos.Add(veiculo);

                Console.WriteLine($"Veículo com placa {placa} foi estacionado com sucesso.");
            }
        }


        public void RemoverVeiculo()
        {
            if (veiculos.Count >= 1)
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                string placa = Console.ReadLine();

                Veiculo veiculoRemover = veiculos.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper());

                if (veiculoRemover != null)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int horas = Convert.ToInt32(Console.ReadLine());

                    decimal valorTotal = precoInicial + precoPorHora*horas;

                    veiculos.Remove(veiculoRemover);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
            else
                Console.WriteLine("Não há veículos estacionados");
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                    Console.WriteLine(veiculo.Placa);
            }
            else
                Console.WriteLine("Não há veículos estacionados.");
        }
    }
}

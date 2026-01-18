using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

Console.WriteLine("\n--- Teste com desconto de 10% (reserva >= 10 dias) ---");
// Teste com desconto
Reserva reserva2 = new Reserva(diasReservados: 10);
reserva2.CadastrarSuite(suite);
reserva2.CadastrarHospedes(hospedes);

Console.WriteLine($"Hóspedes: {reserva2.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária (10 dias com desconto): {reserva2.CalcularValorDiaria()}");

Console.WriteLine("\n--- Teste de validação de capacidade ---");
// Teste de exceção - capacidade insuficiente
try
{
    List<Pessoa> hospedes3 = new List<Pessoa>();
    hospedes3.Add(new Pessoa(nome: "Hóspede 1"));
    hospedes3.Add(new Pessoa(nome: "Hóspede 2"));
    hospedes3.Add(new Pessoa(nome: "Hóspede 3"));
    
    Suite suite2 = new Suite(tipoSuite: "Standard", capacidade: 2, valorDiaria: 25);
    Reserva reserva3 = new Reserva(diasReservados: 5);
    reserva3.CadastrarSuite(suite2);
    reserva3.CadastrarHospedes(hospedes3);
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
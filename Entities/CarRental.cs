using System;

namespace Exercicio_Interface.Entities;

internal class CarRental
{
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public Vehicle Vehicle { get; set; }
    public Invoice Invoice { get; set; }

    public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
    {
        Start = start;
        Finish = finish;
        Vehicle = vehicle;
        //Invoice = null; A nota dé pagamento só vai ser processada quando gerar o pagamento do aluguel de carro. Já é nulo por default.
    }
}

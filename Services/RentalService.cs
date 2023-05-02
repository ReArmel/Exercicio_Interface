using Exercicio_Interface.Entities;

namespace Exercicio_Interface.Services;

 class RentalService
 {
    public double PricePerHour { get; private set; }
    public double PricePerDay { get; private set; }

    private ITaxService _taxService;
    //Inversão de controle por meio de injeção de dependência. Minha classe RentalService não instancia mais a dependência dela. Ela recebe o objeto instanciado e faz a atribuição.
    public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
    {
        PricePerHour = pricePerHour;
        PricePerDay = pricePerDay;
        _taxService = taxService;
    }

    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

        double basicPayment = 0.0;
        if(duration.TotalHours <= 12.0)
        {
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        }
        else
        {
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        }

        double tax = _taxService.Tax(basicPayment);

        carRental.Invoice = new Invoice(basicPayment, tax);
    }
 }

public class ServicePrice
{
    public long id { get; set; }

    public string? name { get; set; }

    public decimal price { get; set; }

    public static ServicePrice GetServicePrice(String name, List<ServicePrice> servicePrices)
    {
        ServicePrice selectedService = new ServicePrice();
        switch (name)
        {
            case "Delivery from China":
                selectedService = servicePrices.Where(service => service.name == "Delivery from China").First();
                break;
            case "Delivery in Russia":
                selectedService = servicePrices.Where(service => service.name == "Delivery in Russia").First();
                break;
            case "Fee":
                selectedService = servicePrices.Where(service => service.name == "Fee").First();
                break;
        }

        return selectedService;
    }
}
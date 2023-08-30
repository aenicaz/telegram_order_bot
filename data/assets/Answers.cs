class Answers
{
    public static string HelloMessage()
    {
        return @"
                            Привет! Давай знакомиться👋🏼
Я Poison bot🔥
Я помогу тебе рассчитать стоимость товара с площадки POIZON в рублях.
Для этого напиши стоимость выбранного товара в ¥ (CNY) и я пришлю тебе итоговую стоимость в ₽ (RUB)

Например: 233";
    }
    public static string TotalPriceMessage(Currency currency, String message, List<ServicePrice> servicePrices)
    {
       return $@"Итоговая стоимость:
{Int32.Parse(message) * currency.exchange_rate + ServicePrice.GetServicePrice("Delivery from China", servicePrices).price + ServicePrice.GetServicePrice("Delivery ir Russia", servicePrices).price + ServicePrice.GetServicePrice("Fee", servicePrices).price} RUB 🔥
_______________
Курс {currency.name}/RUB: {currency.exchange_rate}
(на {DateTime.Now.ToString("MM/dd/yyyy")})
➖
Цена в CNY: {Int32.Parse(message)} ¥
Цена в RUB: {Int32.Parse(message) * currency.exchange_rate} ₽
Доставка по Китаю: {ServicePrice.GetServicePrice("Delivery from China", servicePrices).price} ₽
Доставка в РФ: {ServicePrice.GetServicePrice("Delivery in Russia", servicePrices).price} ₽
Комиссия сервиса: {ServicePrice.GetServicePrice("Fee", servicePrices).price} ₽";
    }
    public static string ReplyMessage(){
        return @"Нажмите на кнопку выше, если вы готовы оформить заказ, или напишите новую цену в CNY, чтобы рассчитать другой товар!";
    }
    public static string SendProductLinkMessage(){
        return @"🔗 Отправьте пожалуста ссылку на интересующий товар.";
    }
    public static string CancelledOrderMessage(){
        return @"Выполнено! Оформление заказа прекращено.";
    }
    public static string NewOrderMessage(){
        return @"Если Вы снова решите что-то заказать, просто отправьте мне стоимость товара, и я обязательно Вам помогу!";
    }
}
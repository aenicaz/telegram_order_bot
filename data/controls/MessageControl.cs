using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class MessageControl
{
    private ITelegramBotClient botClient;
    private Update update;
    public ITelegramBotClient BotClient
    {
        get => botClient;
        set => botClient = value;
    }
    public Update Update
    {
        get => update;
        set => update = value;
    }
    public MessageControl(ITelegramBotClient botClient, Update update)
    {
        BotClient = botClient;
        Update = update;
    }
    public void MessageControler()
    {
        PrintLogs();
        if (update.Message.Text.ToLower() == "/start")
        {
            botClient.SendTextMessageAsync(
                chatId: update.Message.Chat,
                text: Answers.HelloMessage());
            return;
        }
        try
        {
            if (Int32.Parse(update.Message.Text) > 0)
            {
                var currency = new Currency();
                List<ServicePrice> servicePrices = new List<ServicePrice>();

                using (TelegramBotContext db = new TelegramBotContext())
                {
                    currency = db.Currencies.First(c => c.name == "CNY");
                    servicePrices = db.Service_price.ToList();
                }
                botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat,
                    text: Answers.TotalPriceMessage(currency, update.Message.Text, servicePrices),
                    replyMarkup: InlineKeyboard.CreateOrder()
                    );
                return;
            }
        }
        catch (System.Exception e)
        {
            //TODO: implement error logic
        }
    }

    private void PrintLogs()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"User: {update.Message.From.Username}, Command:{update.Message.Text}, ID: {update.Message.MessageId}, Time: {DateTime.Now}");
    }
}
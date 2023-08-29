using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class CallbackControl
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
    public CallbackControl(ITelegramBotClient botClient, Update update)
    {
        BotClient = botClient;
        Update = update;
    }
    public void CallbackControler()
    {
        try
        {
            var callbackData = Int32.Parse(update.CallbackQuery.Data);
            if (callbackData == 1)
            {
                botClient.SendTextMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: "PLACE HOLDER MESSAGE"//TODO: Implement messages 
               );
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
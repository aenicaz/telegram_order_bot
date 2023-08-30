using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class CallbackControl
{
    private const string Photo = "";
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
    public async void CallbackControler()
    {
        try
        {
            var callbackData = Int32.Parse(update.CallbackQuery.Data);
            switch (callbackData)
            {
                case 0:
                    await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.Message.Chat.Id,
                    text: Answers.ReplyMessage());

                    await botClient.SendPhotoAsync(
                    chatId: update.CallbackQuery.Message.Chat.Id,
                    caption: Answers.SendProductLinkMessage(),
                    photo: InputFile.FromUri(Secrets.OrderImageSrc),
                    replyMarkup: InlineKeyboard.CancelOrder());
                    break;
                case 1:
                    var deleteMessageId = new List<int> {
                        update.CallbackQuery.Message.MessageId - 2,
                        update.CallbackQuery.Message.MessageId - 1,
                        update.CallbackQuery.Message.MessageId,
                    };
                    foreach (var id in deleteMessageId)
                    {
                        await botClient.DeleteMessageAsync(
                        chatId: update.CallbackQuery.Message.Chat.Id,
                        messageId:id);
                    }
                    
                    await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.Message.Chat.Id,
                    text: Answers.CancelledOrderMessage());

                    await botClient.SendTextMessageAsync(
                    chatId: update.CallbackQuery.Message.Chat.Id,
                    text: Answers.NewOrderMessage());
                    break;
                default:
                    break;
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
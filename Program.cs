using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;


namespace TelegramOrderBot
{
    class Program
    {

        static ITelegramBotClient bot = new TelegramBotClient(Secrets.ApiKey);
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            MessageControl messageControl = new MessageControl(botClient, update);
            CallbackControl callbackControl= new CallbackControl(botClient, update);

            switch (update.Type)
            {
                case UpdateType.Message:
                    messageControl.MessageControler();
                    break;

                case UpdateType.CallbackQuery:
                    callbackControl.CallbackControler();
                    break;
                default:
                    break;
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Bot is runing" + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, 
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
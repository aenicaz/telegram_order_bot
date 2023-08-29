using Telegram.Bot.Types.ReplyMarkups;

class InlineKeyboard
{
    public static InlineKeyboardMarkup CreateOrder()
    {
        return new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("Оформить заказ", "1"));
    }


}
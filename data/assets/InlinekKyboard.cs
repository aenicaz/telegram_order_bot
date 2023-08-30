using Telegram.Bot.Types.ReplyMarkups;

class InlineKeyboard
{
    public static InlineKeyboardMarkup CreateOrder()
    {
        return new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("✔️Оформить заказ", "0"));
    }

    public static InlineKeyboardMarkup CancelOrder()
    {
        return new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("❌ Отметить оформление", "1"));
    }
}
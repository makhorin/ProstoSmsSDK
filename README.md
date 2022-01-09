# ProstoSmsSDK
Неофициальный клиент для сервиса https://sms-prosto.ru/

Документация API https://lk.sms-prosto.ru/help.php?faq=43

## Примеры использования

### Отправка СМС
```
var client = new Client(YOUR_API_KEY);
var pushResponse = await _client.PushMessage()
    .ToMobile()
    .WithText("some text")
    .From(YOUR_SENDER_NAME)
    .To(RECIPIENT_PHONE)
    .ExecuteAsync();
```

### Отправка сообщения в Telegram с каскадной отправкой СМС
```
var client = new Client(YOUR_API_KEY);
var pushResponse = await _client.PushMessage()
    .ToTelegram()
    .AndThenToMobile()
    .WithText("some text")
    .From(YOUR_SENDER_NAME)
    .To(RECIPIENT_PHONE)
    .ExecuteAsync();
```

### Получение статуса СМС
```
var client = new Client(YOUR_API_KEY);
var statusResponse = await _client.GetStatus(SMS_ID).ExecuteAsync();
```

### Получение профиля с балансом счёта
```
var client = new Client(YOUR_API_KEY);
var profile = await _client.GetProfile().ExecuteAsync();
```

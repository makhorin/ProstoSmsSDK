using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProstoSmsSdk.Tests
{
    [TestFixture]
    public class SdkTests
    {
        private Client _client;
        private string _sender;
        private string _testRecipient;
        [SetUp]
        public void Setup()
        {
            _client = Client.CreateHttpClient(Environment.GetEnvironmentVariable("PROSTO_SMS_API_KEY"));
            _sender = Environment.GetEnvironmentVariable("PROSTO_SMS_SENDER");
            _testRecipient = Environment.GetEnvironmentVariable("PROSTO_SMS_TEST_RECIPIENT");
        }
        
        [Test]
        public async Task ItShouldMakeAuthCall()
        {
            var response = await _client.MakeAuthCall()
                .WithCode("1111")
                .From(_sender)
                .To(_testRecipient)
                .ExecuteAsync();
            Assert.AreEqual(1, response.RawSms);
        }

        [Test]
        public async Task ItShouldSendSmsMsg()
        {
            var response = await _client.PushMessage()
                .ToMobile()
                .WithText("some text")
                .From(_sender)
                .To(_testRecipient)
                .WithExternalId("some_id")
                .WithPriority(Priority.High)
                .ExecuteAsync();
            Assert.AreEqual(1, response.RawSms);
        }

        [Test]
        public async Task ItShouldSendTelegramMsg()
        {
            var response = await _client.PushMessage()
                .ToTelegram()
                .AndThenToMobile()
                .WithText("some text")
                .From(_sender)
                .To(_testRecipient)
                .WithExternalId("some_id")
                .WithPriority(Priority.High)
                .ExecuteAsync();
            Assert.AreEqual(1, response.RawSms);
        }

        [Test]
        public async Task ItShouldWaitForCall()
        {
            var response = await _client.WaitForCall()
                .From(_testRecipient)
                .WaitFor(100)
                .ExecuteAsync();
            Assert.AreEqual(_testRecipient, response.WaitingCallFrom);
        }

        [Test]
        public async Task ItShouldReturnStatusOfSms()
        {
            var textToSend = "some text";
            var sendResponse = await _client.PushMessage()
                .ToMobile()
                .WithText("some text")
                .From(_sender)
                .To(_testRecipient)
                .ExecuteAsync();
            var statusResponse = await _client.GetStatus(sendResponse.Id)
                .ExecuteAsync();

            Assert.AreEqual(sendResponse.SenderName, statusResponse.SenderName);
            Assert.AreEqual(textToSend, statusResponse.Text);
        }

        [Test]
        public async Task ItShouldReturnProfile()
        {
            var profile = await _client.GetProfile().ExecuteAsync();
            Assert.AreEqual(_sender, profile.SenderName);
        }
    }
}
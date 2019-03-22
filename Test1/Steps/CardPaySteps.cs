using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using NUnit;
using NUnit.Framework;

namespace ProjectForCardPay
{
    [Binding]
    public class CardPayWithout3DSecureSteps
    {
        private IWebDriver _driver;

        [Given(@"Open Payment Page")]
        public void GivenOpenPaymentPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://sandbox.cardpay.com/MI/cardpayment2.html?orderXml=PE9SREVSIFdBTExFVF9JRD0nODI5OScgT1JERVJfTlVNQkVSPSc0NTgyMTEnIEFNT1VOVD0nMjkxLjg2JyBDVVJSRU5DWT0nRVVSJyAgRU1BSUw9J2N1c3RvbWVyQGV4YW1wbGUuY29tJz4KPEFERFJFU1MgQ09VTlRSWT0nVVNBJyBTVEFURT0nTlknIFpJUD0nMTAwMDEnIENJVFk9J05ZJyBTVFJFRVQ9JzY3NyBTVFJFRVQnIFBIT05FPSc4NzY5OTA5MCcgVFlQRT0nQklMTElORycvPgo8L09SREVSPg==&sha512=998150a2b27484b776a1628bfe7505a9cb430f276dfa35b14315c1c8f03381a90490f6608f0dcff789273e05926cd782e1bb941418a9673f43c47595aa7b8b0d");

        }

        [Given(@"Enter a card number (.*)")]
        public void GivenEnterACardNumber(string number)
        {
            IWebElement cardNumberField = _driver.FindElement(By.Id("input-card-number"));
            cardNumberField.SendKeys(number);
        }

        [Given(@"Enter a CardHolder name")]
        public void GivenEnterACardHolderName()
        {
            IWebElement cardHolderName = _driver.FindElement(By.Id("input-card-holder"));
            cardHolderName.SendKeys("Ivan Ivanov");
        }

        [Given(@"Select the expired month")]
        public void GivenSelectTheExpiredMonth()
        {
            IWebElement expiresMonth = _driver.FindElement(By.Id("card-expires-month"));
            SelectElement selectAMonth = new SelectElement(expiresMonth);
            selectAMonth.SelectByValue("6");
        }

        [Given(@"Select the expired year")]
        public void GivenSelectTheExpiredYear()
        {
            IWebElement expiresYear = _driver.FindElement(By.Id("card-expires-year"));
            SelectElement selectYear = new SelectElement(expiresYear);
            selectYear.SelectByValue("2019");
        }

        [Given(@"Enter three digits of CVV")]
        public void GivenEnterThreeDigitsOfCVV()
        {
            IWebElement cvcCode = _driver.FindElement(By.Id("input-card-cvc"));
            cvcCode.SendKeys("123");
        }

        [Given(@"User clicks Pay button")]
        public void GivenUserClicksPayButton()
        {
            IWebElement buttonPay = _driver.FindElement(By.Id("action-submit"));
            buttonPay.Click();
        }

        [When(@"User clicks Emulate 3-D Secure")]
        public void WhenUserClicksEmulate3DSecure()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(12));
            wait.Until(ExpectedConditions.ElementExists(By.Id("success")));
            IWebElement paymentStatus = _driver.FindElement(By.Id("success"));
            paymentStatus.Click();

        }

        [When(@"User clicks Emulate Failed 3-D Secure")]
        public void WhenUserClicksEmulateFailed3DSecure()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(12));
            wait.Until(ExpectedConditions.ElementExists(By.Id("failure")));
            IWebElement paymentStatus = _driver.FindElement(By.Id("failure"));
            paymentStatus.Click();

        }

        [When(@"User clicks Pay button")]
        public void WhenUserClicksPayButton()
        {
            IWebElement buttonPay = _driver.FindElement(By.Id("action-submit"));
            buttonPay.Click();
        }

        [Then(@"User sees that the payment status is (.*)")]
        public void ThenUserSeesThatThePaymentStatusIsSuccess(string status)
        {
            IWebElement paymentStatus =
                _driver.FindElement(By.Id("payment-status"));
            Assert.AreEqual(status, paymentStatus.Text);
        }

        [Then(@"User sees that the payment is declined by issuing bank")]
        public void ThenUserSeesThatThePaymentIsDeclinedByIssuingBank()
        {
            IWebElement paymentStatusDeclined =
                _driver.FindElement(By.Id("payment-item-status"));
            Assert.AreEqual("Payment status Declined by issuing bank", paymentStatusDeclined.Text);
        }
        //IWebElement paymentItemStatus =
        //	_driver.FindElement(By.Id("payment-item-status"));
        //Assert.Equal("Payment status Confirmed", paymentItemStatus.Text);

        //IWebElement paymentCardNumber =
        //	_driver.FindElement(By.Id("payment-item-cardnumber"));
        //Assert.Equal("Card number ...0077", paymentCardNumber.Text);

        //IWebElement paymentCardType =
        //	_driver.FindElement(By.Id("payment-item-cardtype"));
        //Assert.Equal("Card type VISA", paymentCardType.Text);

        //IWebElement paymentCardHolder =
        //	_driver.FindElement(By.Id("payment-item-cardholder"));
        //Assert.Equal("Card holder IVAN IVANOV", paymentCardHolder.Text);

        //IWebElement paymentItemTotal =
        //	_driver.FindElement(By.Id("payment-item-total"));
        //Assert.Equal("Total amount EUR   291.86", paymentItemTotal.Text);


        [AfterScenario]
        public void closeWebDriver()
        {
            _driver.Dispose();
        }

    }
}

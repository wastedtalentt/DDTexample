using AngleSharp.Text;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DDTProjectTest.Pages
{
    internal class LoginPage : Form
    {
        private ITextBox username => ElementFactory.GetTextBox(By.Id("userName"), "Username field");
        private ITextBox emaill => ElementFactory.GetTextBox(By.Id("userEmail"), "Email field");
        private IButton submit => ElementFactory.GetButton(By.Id("submit"), "Submit button");
        private ILabel appearedBlock => ElementFactory.GetLabel(
        By.XPath("//*[contains(@class, 'border')]"),
        "appeared Block To see username and email");
        private ITextBox currentAddress => ElementFactory.GetTextBox(By.Id("currentAddress"), "current address field");
        private ITextBox permanentAddress => ElementFactory.GetTextBox(By.Id("permanentAddress"), "permanent Address field");

        public LoginPage() : base(By.Id("userForm"), "Login Page") { }

        public void InputUsername(string text)
        {
            username.ClearAndType(text);
        }

        public void InputEmail(string email)
        {
            emaill.ClearAndType(email);
        }

        public void ScrollToTheElement()
        {
            submit.JsActions.ScrollToTheCenter();
        }
        
        public void ClickSubmit()
        {
            submit.Click();
        }

        public void InputCurrentAddress(string address)
        {
            currentAddress.ClearAndType(address);
        }
        public void InputPermanentAddress(string address)
        {
            currentAddress.ClearAndType(address);
        }

        public string AppearedBlock() => appearedBlock.Text;
    }
}

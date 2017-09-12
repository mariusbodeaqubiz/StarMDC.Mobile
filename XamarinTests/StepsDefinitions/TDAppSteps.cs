using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;
using XamarinTests.StepsDefinitions;

namespace XamarinTests.StepsDefinitions
{
    [Binding]
    public class TDAppSteps
    {
        public AndroidApp appTest = BaseClass.app;

        [Given(@"I have open the app")]
        public void GivenIHaveOpenTheApp()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit ""(.*)"" as phone number")]
        public void WhenISubmitAsPhoneNumber(string phoneNumber)
        {
            BaseClass.app.EnterText(c => c.Class("EntryEditText"), phoneNumber);
        }
        
        [Given(@"I tap ""(.*)"" button")]
        public void GivenITapButton(string button)
        {
            switch (button.ToLower())
            {
                case "sign up":
                    BaseClass.app.Tap(c => c.Marked("Sign Up"));
                    break;
                case "activate":
                    BaseClass.app.Tap(c => c.Marked("Activate"));
                    break;
                case "hamburger menu":
                    BaseClass.app.WaitForElement(c => c.Class("AppCompatTextView").Marked("ODP TD(Acc)"), "Upload is taking too long", new TimeSpan(0, 0, 90, 0));
                    BaseClass.app.Tap(c => c.Marked("OK"));
                    break;
                case "thrombosys module":
                    BaseClass.app.Tap(c => c.Marked("Thrombosys module"));
                    break;
                case "overview sent messages":
                    BaseClass.app.Tap(c => c.Marked("Overview sent messages"));
                    break;
                case "measure inr":
                    Func<AppQuery, AppQuery> measureInrButton = e => e.Marked("Measure INR").Index(1);
                    BaseClass.app.Tap(measureInrButton);
                    break;
                case "manually enter":
                    Func<AppQuery, AppQuery> manuallyEnterButton = e => e.Marked("manually enter");
                    BaseClass.app.Tap(manuallyEnterButton);
                    break;
                case "register inr value":
                    Func<AppQuery, AppQuery> registerInrValueButton = e => e.Marked("Register INR value");
                    BaseClass.app.Tap(registerInrValueButton);
                    break;
                case "register extra info":
                    Func<AppQuery, AppQuery> registerExtraInfoButton = e => e.Marked("Register extra info");
                    BaseClass.app.ScrollDown();
                    BaseClass.app.Tap(registerExtraInfoButton);
                    break;
                case "ready":
                    Func<AppQuery, AppQuery> readyButton = e => e.Marked("Ready");
                    BaseClass.app.Tap(readyButton);
                    break;
                case "confirm and send":
                    Func<AppQuery, AppQuery> confirmAndSendButton = e => e.Marked("Confirm and Send");
                    BaseClass.app.Tap(confirmAndSendButton);
                    break;
                case "submit":
                    Func<AppQuery, AppQuery> submitButton = e => e.Marked("Submit");
                    BaseClass.app.Tap(submitButton);
                    break;
                default:
                    throw new PendingStepException();
            }
        }

        [Then(@"I should be on ""(.*)"" page")]
        public void ThenIShouldBeOnMainePage(String page)
        {
            switch(page.ToLower())
            {
                case "enter pin code":
                    var mainText = BaseClass.app.Query(c => c.Class("FormsTextView")).First();
                    Assert.IsTrue(mainText.Text.Contains("Welcome to StarMDC Portal app."));
                    break;
                case "measure inr":
                    var measureInr = BaseClass.app.Query(c => c.Marked("Measure INR")).First();
                    Assert.IsTrue(measureInr.Text.Contains("Measure INR"));
                    break;
                default:
                    throw new PendingStepException();
            }
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(String page)
        {
            switch (page.ToLower())
            {
                case "panel menu":
                    var panel = BaseClass.app.Query(c => c.Id("NoResourceEntry-2")).FirstOrDefault();
                    Assert.IsNotNull(panel);
                    break;
                default:
                    throw new PendingStepException();
            }
        }

        [Given(@"I input ""(.*)"" as Patient BSN")]
        public void GivenIInputAsPatientBSN(string bsn)
        {
            Func<AppQuery, AppQuery> bsnField = e => e.Class("EntryEditText").Index(0);
            BaseClass.app.EnterText(bsnField, bsn);
        }

        [Given(@"I input ""(.*)"" as Employee Id")]
        public void GivenIInputAsEmployeeId(string employeeId)
        {
            Func<AppQuery, AppQuery> employeeIdField = e => e.Class("EntryEditText").Index(2);
            BaseClass.app.EnterText(employeeIdField, employeeId);
        }

        [Given(@"I input ""(.*)"" as INR value")]
        public void GivenIInputAsINRValue(string inr)
        {
            Func<AppQuery, AppQuery> inrOneField = e => e.Class("EntryEditText").Index(3);
            Func<AppQuery, AppQuery> inrTwoField = e => e.Class("EntryEditText").Index(4);

            BaseClass.app.DismissKeyboard();
            BaseClass.app.EnterText(inrOneField, inr);
            BaseClass.app.DismissKeyboard();
            BaseClass.app.EnterText(inrTwoField, inr);
            BaseClass.app.DismissKeyboard();
        }

        [Given(@"I select ""(.*)"" as ""(.*)""")]
        public void GivenISelectAs(string infoType, string status)
        {
            Func<AppQuery, AppQuery> statusButton;
            int infoTypeId = 0;

            switch (infoType.ToLower())
            {
                case "medication":
                    infoTypeId = 0;
                    break;
                case "been bleeding":
                    infoTypeId = 1;
                    break;
                case "medical intervention":
                    infoTypeId = 2;
                    break;
                default:
                    throw new PendingStepException();
            }

            switch(status.ToLower())
            {
                case "no":
                    statusButton = e => e.Marked("No").Index(infoTypeId);
                    BaseClass.app.Tap(statusButton);
                    break;
                case "yes":
                    statusButton = e => e.Marked("Yes  ").Index(infoTypeId);
                    BaseClass.app.Tap(statusButton);
                    break;
                default:
                    throw new PendingStepException();
            }

        }

        [Then(@"I ""(.*)"" to get my location")]
        public void ThenIToGetMyLocation(string status)
        {
            BaseClass.app.Device.SetLocation(52.3702, 4.8952);
            ////Func<AppQuery, AppQuery> confirmAndSendButton = e => e.Marked("Confirm and Send");
            //Func<AppQuery, AppQuery> confirmAndSendButton = e => e.Marked("ALLOW").Parent().Class("AlertDialogLayout").Index(0);
            //BaseClass.app.Tap(confirmAndSendButton);
        }

        [Then(@"I verify if the ""(.*)"" is ""(.*)""")]
        public void ThenIVerifyIfTheIs(string parameter, string value)
        {
            int parameterIndex = 0;
            BaseClass.app.WaitForElement(c => c.Marked("Patient:"));

            switch(parameter.ToLower())
            {
                case "bsn":
                    parameterIndex = 3;
                    break;
                case "employee id":
                    parameterIndex = 5;
                    break;
                case "inr value":
                    parameterIndex = 9;
                    break;
            }
            
            var parameterText = BaseClass.app.Query(c => c.Class("FormsTextView").Index(parameterIndex));
            Assert.IsTrue(parameterText.First().Text.Contains(value), "But: " + parameterText.First().Text);
        }

        [Then(@"I verify if the ""(.*)"" is ""(.*)"" on Overview Sent Messages")]
        public void ThenIVerifyIfTheIsOnOverviewSentMessages(string parameter, string value)
        {
            int parameterIndex = 0;
            BaseClass.app.WaitForElement(c => c.Marked("Patient ID:"));

            switch (parameter.ToLower())
            {
                case "bsn":
                    parameterIndex = 2;
                    break;
                case "employee id":
                    parameterIndex = 5;
                    break;
                case "inr value":
                    parameterIndex = 9;
                    break;
            }

            var parameterText = BaseClass.app.Query(c => c.Class("FormsTextView").Index(parameterIndex));
            Assert.IsTrue(parameterText.First().Text.Contains(value), "But: " + parameterText.First().Text);
        }

    }
}

using System;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class BankingScenariosSteps
{
    private RestClient client;
    private IRestResponse response;

    [Given(@"the user sends the request to create account with details '(.*)','(.*)', and '(.*)'")]
    public void GivenTheUserSendsRequestToCreateAccount(string initialBalance, string accountName, string address)
    {
        var initialBalance = accountDetails["initialBalance"];
        var accountName = accountDetails["accountName"];
        var address = accountDetails["address"];

        var requestPayload = new
        {
            InitialBalance = Convert.ToInt32(initialBalance),
            AccountName = accountName,
            Address = address
        };

        client = new RestClient("https://www.localhost:8080/api/account/create");
        var request = new RestRequest(Method.POST);
        request.AddJsonBody(JsonConvert.SerializeObject(requestPayload));
        response = client.Execute(request);
    }
   [Then(@"I verify the status code '(.*)'")]
   public void ThenIVerifyTheStatusCode(string expectedStatusCode)
    {
        if(response.statusCode == expectedStatusCode){
            Console.WriteLine("API Successful!!");
        }
        else{
            Console.WriteLine("Status code not matched");
        }
    }

    [And(@"verify the response data '(.*)','(.*)','(.*)' and '(.*)'")]
    public void AndVerifyTheResponseData(string expectedInitialBalance, string expectedAccountName, string expectedAccountNumber, string expectedMessage)
    {
        var InitialBalance = expectedResponse["expectedInitialBalance"];
        var AccountName = expectedResponse["expectedAccountName"];
        var AccountNumber = expectedResponse["expectedAccountNumber"];
        var Message = expectedResponse["expectedMessage"];

        var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Assert.Equal(InitialBalance, responseData.Data.expectedInitialBalance.ToString());
        Assert.Equal(AccountName, responseData.Data.expectedAccountName.ToString());
        Assert.Equal(AccountNumber, responseData.Data.expectedAccountNumber.ToString());
        Assert.Equal(Message, responseData.expectedMessage.ToString());
        Assert.Empty(responseData.Errors);
    }
    [Given(@"the user has an account with AccountID ""(.*)""")]
    public void GivenTheUserHasAnAccountWithAccountID(string accountID)
    {
        client = new RestClient($"https://www.localhost:8080/api/account/delete/{accountID}");
        var request = new RestRequest(Method.DELETE);
        response = client.Execute(request);
    }

    [Then(@"the response should contain Data: ""(.*)"" and Message: ""(.*)""")]
    public void ThenTheResponseShouldContainDataAndMessage(string expectedData, string expectedMessage)
    {
        var data = expectedResponse["Data"];
        var message = expectedResponse["Message"];

        var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Assert.Equal(Data, responseData.expectedData.ToString());
        Assert.Equal(Message, responseData.expectedMessage.ToString());
        Assert.Empty(responseData.Errors);
    }
    [Given(@"the user has an account with AccountNumber ""(.*)""")]
    public void GivenTheUserHasAnAccountWithAccountNumber(string accountNumber)
    {
        // Additional setup logic can be added if needed
        client = new RestClient($"https://www.localhost:8080/api/account/deposit");
        var depositDetails = table.Rows[0];
        var accountNumber = depositDetails["AccountNumber"];
        var amount = depositDetails["Amount"];

        var requestPayload = new
        {
            AccountNumber = accountNumber,
            Amount = Convert.ToInt32(amount)
        };

        var request = new RestRequest(Method.PUT);
        request.AddJsonBody(JsonConvert.SerializeObject(requestPayload));
        response = client.Execute(request);
    }

    [Then(@"the response should contain AccountNumber: ""(.*)"", NewBalance: ""(.*)"", and Message: ""(.*)""")]
    public void ThenTheResponseShouldContainAccountNumberNewBalanceAndMessage(string expectedAccountNumber, string expectedNewBalance, string expectedMessage)
{
    var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

    // Verify the response data
    Assert.Equal(expectedAccountNumber, responseData.Data.AccountNumber.ToString());
    Assert.Equal(expectedNewBalance, responseData.Data.NewBalance.ToString());
    Assert.Equal(expectedMessage, responseData.Message.ToString());
    Assert.Empty(responseData.Errors);

}
    [Given(@"the user has an account with details '(.*)' and '(.*)'")]
    public void GivenTheUserHasAnAccountWithDetails(string accountNumber, int amount)
    {
        // Additional setup logic can be added if needed
        client = new RestClient($"https://www.localhost:8080/api/account/withdraw");
        var accountNumber = withdrawalDetails["AccountNumber"];
        var amount = withdrawalDetails["Amount"];

        var requestPayload = new
        {
            AccountNumber = accountNumber,
            Amount = Convert.ToInt32(amount)
        };

        var request = new RestRequest(Method.PUT);
        request.AddJsonBody(JsonConvert.SerializeObject(requestPayload));
        response = client.Execute(request);
    }

    [Then(@"the response should contain AccountNumber: ""(.*)"", NewBalance: ""(.*)"", and Message: ""(.*)""")]
    public void ThenTheResponseShouldContainAccountNumberNewBalanceAndMessage(string expectedAccountNumber, int expectedNewBalance, string expectedMessage)
    {
       var accountNumber = expectedResponse["AccountNumber"];
        var newBalance = expectedResponse["NewBalance"];
        var message = expectedResponse["Message"];

        var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

        Assert.Equal(accountNumber, responseData.Data.AccountID.ToString());
        Assert.Equal(newBalance, responseData.Data.NewBalance.ToString());
        Assert.Equal(message, responseData.Message.ToString());
        Assert.Empty(responseData.Errors);
    }
}

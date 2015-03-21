using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data
{
    public class UserClient:DataClient
    {
        private string userToken;

        public string mobile;
        public string name;
        public string lastname;

        private bool setup=false;

        public bool SetupDone
        {
            get
            {
                return setup;
            }
        }

        public async Task Signin(string phoneNumber,string name, string lastname)
        {
            this.mobile = phoneNumber;
            this.name = name;
            this.lastname = lastname;
            JObject results;
            HttpHeaders headers;
            // sign in
            GetResponseAndHeaders(await SendAsync(HttpMethod.Get, DataTokens.SIGNIN_TOKEN + phoneNumber + @"/", null), out results, out headers);
            string sessiontoken = headers.GetValues("sessiontoken").FirstOrDefault();
            string smscode = (string)results["smscode"];
            string type = (string)results["type"];
            if (type == "register")
            {
                // register 
                GetResponseAndHeaders(await SendAsync(HttpMethod.Get, DataTokens.SIGNIN_TOKEN + DataTokens.REGISTER_TOKEN + smscode + @"/", null, "sessiontoken", sessiontoken), out results, out headers);
                string registrationtoken = headers.GetValues("registrationtoken").FirstOrDefault();
                var body = new { firstname = name, lastname = lastname, email = "tim.jim@gmail.com", pin = "1234" };
                GetResponseAndHeaders(await SendAsync(HttpMethod.Put, DataTokens.SIGNIN_TOKEN + DataTokens.REGISTER_TOKEN + DataTokens.FINISH_TOKEN, body, "registrationtoken", registrationtoken), out results, out headers);
                userToken = headers.GetValues("usertoken").FirstOrDefault();
            }
            else
            {
                // login
                GetResponseAndHeaders(await SendAsync(HttpMethod.Get, DataTokens.SIGNIN_TOKEN + DataTokens.LOGIN_TOKEN + smscode + @"/", null, "sessiontoken", sessiontoken), out results, out headers);
                userToken = headers.GetValues("usertoken").FirstOrDefault();
            }
        }

        public async Task SetupCreditCard(string creditNumber)
        {
            JObject results;
            HttpHeaders headers;
            // check if credit card exists
            GetResponseAndHeaders(await SendAsync(HttpMethod.Get, DataTokens.CREDITCARD_TOKEN, null, "usertoken", userToken), out results, out headers);
            if(results==null)
            {
                // register card
                var body = new { number = creditNumber, preferred = "true", expiration = "04/15", code = "123" };
                GetResponseAndHeaders(await SendAsync(HttpMethod.Put, DataTokens.CREDITCARD_TOKEN, body, "usertoken", userToken), out results, out headers);
            }
            setup = true;
        }

        public async Task SendMoneyTo(string phoneNumber, string amount,string comment="",string image="")
        {
            JObject results;
            HttpHeaders headers;
            // get credit card id
            GetResponseAndHeaders(await SendAsync(HttpMethod.Get, DataTokens.USER_TOKEN, null, "usertoken", userToken), out results, out headers);
            var creditCardTemp = results["creditCards"].ToString();
            var creditCard = creditCardTemp.TrimStart('[').TrimEnd(']');
            var creditId = (JObject.Parse(creditCard))["id"];
            // send
            var body = new { phoneNumber = phoneNumber, amount = amount, loadAmount = amount, creditCardId = creditId, loadFee = "0", comment = comment, image = image };
            GetResponseAndHeaders(await SendAsync(HttpMethod.Put, DataTokens.BALANCE_TOKEN + DataTokens.TRANSACTION_TOKEN + DataTokens.SEND_TOKEN, body, "usertoken", userToken), out results, out headers);
        }

        public async Task RequestMoneyFrom(string phoneNumber, string amount, string comment = "", string image = "")
        {
            JObject results;
            HttpHeaders headers;
            // send
            var body = new { phoneNumber = phoneNumber, amount = amount, loadAmount = amount, comment = comment, image = image };
            GetResponseAndHeaders(await SendAsync(HttpMethod.Put, DataTokens.BALANCE_TOKEN + DataTokens.TRANSACTION_TOKEN + DataTokens.REQUEST_TOKEN, body, "usertoken", userToken), out results, out headers);
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            List<Transaction> results;
            // send
            var tuple= await SendAsync(HttpMethod.Get, DataTokens.ACTIVITY_TOKEN + DataTokens.ACTIVITIES_TOKEN, null, "usertoken", userToken);
            if (tuple.Item1 != "[]" && tuple.Item1 != "")
            {
                results = new List<Transaction>();
                JArray responses = JArray.Parse(tuple.Item1) as JArray;
                foreach (JObject response in responses)
                {
                    var transaction = new Transaction
                    {
                        id = (string)response["id"],
                        timestamp = (string)response["timestamp"],
                        type = (string)response["type"],
                        status = (string)response["status"],
                        amount = (string)response["amount"],
                        phoneNumber = (string)response["phoneNumber"]
                    };
                    results.Add(transaction);
                }
            }
            else
                results = null;
            return results;
        }

        public async Task AcceptRequestFrom(string transId)
        {
            JObject results;
            HttpHeaders headers;
            // get credit card id
            GetResponseAndHeaders(await SendAsync(HttpMethod.Get, DataTokens.USER_TOKEN, null, "usertoken", userToken), out results, out headers);
            var creditCardTemp = results["creditCards"].ToString();
            var creditCard = creditCardTemp.TrimStart('[').TrimEnd(']');
            var creditId = (JObject.Parse(creditCard))["id"];
            // send
            var body = new { loadAmount = "10", creditCardId = creditId, loadFee = "0" };
            GetResponseAndHeaders(await SendAsync(HttpMethod.Post, DataTokens.ACTIVITY_TOKEN + DataTokens.ACCEPT_TOKEN + transId + @"/", body, "usertoken", userToken), out results, out headers);
        }

        public async Task RejectRequestFrom(string transId)
        {
            JObject results;
            HttpHeaders headers;
            // send
            GetResponseAndHeaders(await SendAsync(HttpMethod.Post, DataTokens.ACTIVITY_TOKEN + DataTokens.REJECT_TOKEN + transId + @"/", null, "usertoken", userToken), out results, out headers);
        }
    }

}

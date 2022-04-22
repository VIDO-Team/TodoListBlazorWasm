using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ZaloVidoAPI.Data;
using ZaloVidoAPI.Dtos;
using ZaloVidoAPI.Models;
using AutoMapper;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using ZaloDotNetSDK;
using Microsoft.EntityFrameworkCore;

namespace ZaloVidoAPI.Lib
{
    public class SendMessageLib
    {
        private readonly ZaloVidoDbContext _context;

        public SendMessageLib(ZaloVidoDbContext context)
        {
            _context = context;
            
        }
        public ApplicationConfig GetApplicationConfig()
        {
            var applicationConfig = _context.ApplicationConfigs.FirstOrDefault(a => a.Id >= 1);
            if(applicationConfig.LastUpdatedDateTime.AddMinutes(-50) > DateTime.Now){
                return null;
            }
            return applicationConfig;
        }
        public string SendMessage(string userId, string messages){
            var appConfig = GetApplicationConfig();
            if(appConfig != null){
                ZaloClient client = new ZaloClient(appConfig.AccessToken);
                
                JObject result = client.sendTextMessageToUserId(userId, messages);
                return result.ToString();
            }
            
            return null;
        }
        public async void SendMessageCrisp(string message,string websiteId, string sessionId,string identifer, string key){
            message = message.Replace("\n", "\\n");
            
            HttpClient client = new HttpClient();
            string url = "https://api.crisp.chat/v1/website/"+websiteId+"/conversation/"+sessionId+"/message";
            
            var authenticationString = $"{identifer}:{key}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic",base64EncodedAuthenticationString);
            client.DefaultRequestHeaders.Add("X-Crisp-Tier","plugin");

            var payload = "{\"type\": \"text\",\"from\": \"operator\",\"origin\": \"chat\",\"content\": \""+message+"\"}";
            Console.WriteLine(payload);
            Console.WriteLine(url);
            try
            {
                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = client.PostAsync(url, c).GetAwaiter().GetResult();
                httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299
                string responseString = await httpResponse.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
  
       public JObject getMessageHistory(long userId){
            var appConfig = GetApplicationConfig();
            if(appConfig != null){
                ZaloClient client = new ZaloClient(appConfig.AccessToken);
                JObject result = client.getListConversationWithUser(userId, 0, 3);
                return result;
            }
            return null;
       }

       public string GetAnswerByQuestion(string question)
        {
            Console.WriteLine("GetAnswerByQuestion: {0}",question);
            question = convertToUnSign(question);
            Console.WriteLine("GetAnswerByQuestion:1{0}",question);
            var flight = _context.FQADetails.Where(s=>s.Question==question).Include(s=>s.FQA).FirstOrDefault();

            if (flight == null)
            {
                return null;
            }
            //This mapping won't work as I have not done the Profiles section Duh!!!
            return flight.FQA.Answers;
        }

       public string getMessageType(string userId){
            var message = getMessageHistory(Int64.Parse(userId));
            Console.WriteLine("message: "+message);
            string result ="";
            if(message ["data"].Count() == 3){
                if(message["data"][0]["from_display_name"].ToString()=="Cao đẳng Viễn Đông TPHCM"){
                    if(message["data"][2]["message"].ToString() == "Email:\n- Ví Dụ: nguyenvana@vido.com"){
                        result = "email";
                    }else if(message["data"][2]["message"].ToString() == "Họ và Tên:\n- Ví dụ: Nguyễn Văn A"){
                        result = "ten";
                    }else if(message["data"][2]["message"].ToString() == "Địa chỉ:\n- Ví Dụ: Cao Đẳng Viễn Đông"){
                        result = "dc";
                    }else if(message["data"][2]["message"].ToString() == "Số Điện Thoại:\n- Ví Dụ: 0931231311"){
                        result ="sdt";
                    }else if(message["data"][2]["message"].ToString() =="Ngày Sinh: \n- Ví Dụ: 01/01/2000"){
                        result ="ns";
                    }
               }else if(message["data"][0]["from_display_name"].ToString()!="Cao đẳng Viễn Đông TPHCM"){
                   if(message["data"][1]["message"].ToString() == "Email:\n- Ví Dụ: nguyenvana@vido.com"){
                        result = "email";
                    }else if(message["data"][1]["message"].ToString() == "Họ và Tên:\n- Ví dụ: Nguyễn Văn A"){
                        result = "ten";
                    }else if(message["data"][1]["message"].ToString() == "Địa chỉ:\n- Ví Dụ: Cao Đẳng Viễn Đông"){
                        result = "dc";
                    }else if(message["data"][1]["message"].ToString() == "Số Điện Thoại:\n- Ví Dụ: 0931231311"){
                        result ="sdt";
                    }else if(message["data"][1]["message"].ToString() =="Ngày Sinh: \n- Ví Dụ: 01/01/2000"){
                        result ="ns";
                    }
               }
            }
            Console.WriteLine("result: "+result);
           return result;
       }
        public static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }  
    }
}


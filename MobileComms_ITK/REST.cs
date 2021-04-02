using Microsoft.OpenApi.Readers;
using MobileComms_ITK.JSON.Types;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobileComms_ITK.REST
{

    public class REST
    {


        public enum Actions
        {
            GET,
            PUT,
            POST,
            DELETE,
            STREAM
        }

        public class Command
        {
            public Type JSONType { get; set; }
            public string TypeName { get; set; }
            public Actions Action { get; set; }
            public List<string> Resources { get; set; }
        }

        public List<Command> Commands { get; } = new List<Command>()
        {
            { new Command() { Action = Actions.GET, TypeName = "DataStoreItem", JSONType = typeof(DataStoreItem), Resources = new List<string>()
                {
                    "/DataStoreItem/ByKey/{namekey}",
                    "/DataStoreItem/UpdatedSince?sinceTime={ms}",
                    "/DataStoreItem/BySource/{Source}",
                    "/DataStoreItem/ByItemName/{ItemName}",
                    "/DataStoreItem/ByType/{Type}",
                    "/DataStoreItem/ByDisplayName/{DisplayName}",
                    "/DataStoreItem/ByGroupName/{GroupName}",
                    "/DataStoreItem/ByCategory/{Category}"
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "DataStoreValue", JSONType = typeof(DataStoreValue), Resources = new List<string>()
                {
                    "/DataStoreValue/ByKey/{namekey}",
                    "/DataStoreValue/UpdatedSince?sinceTime={ms}",
                }
            } },
            { new Command() { Action = Actions.STREAM, TypeName = "DataStoreValue", JSONType = typeof(DataStoreValue), Resources = new List<string>()
                {
                    "/DataStoreValue/Stream",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "DataStoreValueLatest", JSONType = typeof(DataStoreValue), Resources = new List<string>()
                {
                    "/DataStoreValueLatest/{DataStore item name}",
                    "/DataStoreValueLatest/{DataStore item name}:{AMR name}",
                    "/DataStoreValueLatest/{DataStore item name}:*",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "SubscriptionConfig", JSONType = typeof(SubscriptionConfig), Resources = new List<string>()
                {
                    "/SubscriptionConfig/ByKey/{namekey}",
                    "/SubscriptionConfig/UpdatedSince?sinceTime={ms}",
                }
            } },
            { new Command() { Action = Actions.STREAM, TypeName = "SubscriptionConfig", JSONType = typeof(SubscriptionConfig), Resources = new List<string>()
                {
                    "/SubscriptionConfig/Stream",
                }
            } },
            { new Command() { Action = Actions.PUT, TypeName = "SubscriptionConfig", JSONType = typeof(SubscriptionConfig_PUT), Resources = new List<string>()
                {
                    "/SubscriptionConfig",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "Pickup", JSONType = typeof(Pickup), Resources = new List<string>()
                {
                    "/Pickup/UpdatedSince?sinceTime={time millis}",
                    "/Pickup/ByKey/{namekey}",
                    "/Pickup/ByJobId/{JobId}",
                    "/Pickup/ByStatus/{Status}",
                    "/Pickup/ByAssignedJobId/{AssignedJobId}",
                }
            } },
            { new Command() { Action = Actions.STREAM, TypeName = "Pickup", JSONType = typeof(Pickup), Resources = new List<string>()
                {
                    "/Pickup/Stream",
                }
            } },
            { new Command() { Action = Actions.POST, TypeName = "Pickup", JSONType = typeof(Pickup_POST), Resources = new List<string>()
                {
                    "/Pickup",
                }
            } },
            { new Command() { Action = Actions.DELETE, TypeName = "Pickup", JSONType = typeof(Pickup), Resources = new List<string>()
                {
                    "/Pickup/{namekey}",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "PickupDropoff", JSONType = typeof(PickupDropoff), Resources = new List<string>()
                {
                    "/PickupDropoff/UpdatedSince?sinceTime={time millis}",
                    "/PickupDropoff/ByKey/{namekey}",
                    "/PickupDropoff/ByJobId/{JobId}",
                    "/PickupDropoff/ByStatus/{Status}",
                    "/PickupDropoff/ByAssignedJobId/{AssignedJobId}",
                }
            } },
            { new Command() { Action = Actions.STREAM, TypeName = "PickupDropoff", JSONType = typeof(PickupDropoff), Resources = new List<string>()
                {
                    "/PickupDropoff/Stream",
                }
            } },
            { new Command() { Action = Actions.POST, TypeName = "PickupDropoff", JSONType = typeof(PickupDropoff_POST), Resources = new List<string>()
                {
                    "/PickupDropoff",
                }
            } },
            { new Command() { Action = Actions.DELETE, TypeName = "PickupDropoff", JSONType = typeof(PickupDropoff), Resources = new List<string>()
                {
                    "/PickupDropoff/{namekey}",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "Dropoff", JSONType = typeof(Dropoff), Resources = new List<string>()
                {
                    "/Dropoff/UpdatedSince?sinceTime={time millis}",
                    "/Dropoff/ByKey/{namekey}",
                    "/Dropoff/ByJobId/{JobId}",
                    "/Dropoff/ByStatus/{Status}",
                    "/Dropoff/ByAssignedJobId/{AssignedJobId}",
                    "/Dropoff/ByRobot/{AMR}"
                }
            } },
            { new Command() { Action = Actions.STREAM, TypeName = "Dropoff", JSONType = typeof(Dropoff), Resources = new List<string>()
                {
                    "/Dropoff/Stream",
                }
            } },
            { new Command() { Action = Actions.POST, TypeName = "Dropoff", JSONType = typeof(Dropoff_POST), Resources = new List<string>()
                {
                    "/Dropoff",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "JobRequest", JSONType = typeof(JobRequest), Resources = new List<string>()
                {
                    "/JobRequest/UpdatedSince?sinceTime={time millis}",
                    "/JobRequest/ByKey/{namekey}",
                    "/JobRequest/ByJobId/{JobId}",
                    "/JobRequest/ByStatus/{Status}",
                    "/JobRequest/ByAssignedJobId/{AssignedJobId}",
                }
            } },
            { new Command() { Action = Actions.STREAM, TypeName = "JobRequest", JSONType = typeof(JobRequest), Resources = new List<string>()
                {
                    "/JobRequest/Stream",
                }
            } },
            { new Command() { Action = Actions.POST, TypeName = "JobRequest", JSONType = typeof(JobRequest_POST), Resources = new List<string>()
                {
                    "/JobRequest",
                }
            } },
            { new Command() { Action = Actions.DELETE, TypeName = "JobRequest", JSONType = typeof(JobRequest), Resources = new List<string>()
                {
                    "/JobRequest/{namekey}",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "JobRequestDetail", JSONType = typeof(JobRequestDetail), Resources = new List<string>()
                {
                    "/JobRequestDetail/ByKey/{namekey}",
                    "/JobRequestDetail/UpdatedSince?sinceTime={time millis}",
                    "/JobRequestDetail/ByJobRequest/{JobRequestnamekey}",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "Job", JSONType = typeof(Job), Resources = new List<string>()
                {
                    "/Job/ByKey/{namekey}",
                    "/Job/UpdatedSince?sinceTime={time millis}",
                    "/Job/History?sinceTime={time millis}",
                    "/Job/History?sinceTime={time millis}&namekey={namekey}",
                    "/Job/ByJobId/{JobId}",
                    "/Job/ByLastAssignedRobot/{LastAssignedRobot}",
                    "/Job/ByStatus/{Status}",
                }
            } },
            { new Command() { Action = Actions.STREAM, TypeName = "Job", JSONType = typeof(Job), Resources = new List<string>()
                {
                    "/Job/Stream",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "JobSegment", JSONType = typeof(JobSegment), Resources = new List<string>()
                {
                    "/JobSegment/ByKey/{namekey}",
                    "/JobSegment/UpdatedSince?sinceTime={time millis}",
                    "/JobSegment/History?sinceTime={time millis}",
                    "/JobSegment/History?sinceTime={time millis}&namekey={namekey}",
                    "/JobSegment/ByStatus/{Status}",
                    "/JobSegment/ByJob/{Job}",
                    "/JobSegment/ByRobot/{AMR}",
                    "/JobSegment/ByGoalName/{GoalName}"
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "JobSegment", JSONType = typeof(JobSegment), Resources = new List<string>()
                {
                    "/JobSegment/Stream",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "JobSegmentModify", JSONType = typeof(JobSegmentModify), Resources = new List<string>()
                {
                    "/JobSegmentModify/ByKey/{namekey}",
                    "/JobSegmentModify/History?sinceTime={time millis}",
                    "/JobSegmentModify/BySegmentId/{SegmentID}",
                }
            } },
            { new Command() { Action = Actions.POST, TypeName = "JobSegmentModify", JSONType = typeof(JobSegmentModify_POST), Resources = new List<string>()
                {
                    "/JobSegmentModify",
                }
            } },
            { new Command() { Action = Actions.DELETE, TypeName = "JobSegmentModify", JSONType = typeof(JobSegmentModify), Resources = new List<string>()
                {
                    "/JobSegmentModify/{namekey}",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "JobCancel", JSONType = typeof(JobCancel), Resources = new List<string>()
                {
                    "/JobCancel/ByKey/{namekey}",
                    "/JobCancel/UpdatedSince?sinceTime={time millis}",
                }
            } },
            { new Command() { Action = Actions.POST, TypeName = "JobCancel", JSONType = typeof(JobCancel_POST), Resources = new List<string>()
                {
                    "/JobCancel",
                }
            } },
            { new Command() { Action = Actions.DELETE, TypeName = "JobCancel", JSONType = typeof(JobCancel), Resources = new List<string>()
                {
                    "/JobCancel/{namekey}",
                }
            } },

            { new Command() { Action = Actions.GET, TypeName = "Robot", JSONType = typeof(Robot), Resources = new List<string>()
                {
                    "/Robot/ByKey/{namekey}",
                    "/Robot/History?sinceTime={time millis}",
                    "/Robot/History?sinceTime={time millis}&namekey={namekey}",
                    "/Robot/ByStatus/{Status}",
                    "/Robot/BySubStatus/{SubStatus}",
                    "/Robot/UpdatedSince?sinceTime={time millis}"
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "RobotFault", JSONType = typeof(RobotFault), Resources = new List<string>()
                {
                    "/RobotFault/ByKey/{namekey}",
                    "/RobotFault/UpdatedSince?sinceTime={time millis}",
                    "/RobotFault/History?sinceTime={time millis}",
                    "/RobotFault/History?sinceTime={time millis}&namekey={namekey}",
                    "/RobotFault/ByRobot/{AMR}",
                    "/RobotFault/ByType/{Type}",
                    "/RobotFault/ByName/{Name}",
                    "/RobotFault/ByActive/{Value}"
                }
            } },
            { new Command() { Action = Actions.POST, TypeName = "WaitTaskCancel", JSONType = typeof(WaitTaskCancelQuery_POST), Resources = new List<string>()
                {
                    "/WaitTaskCancel",
                }
            } },
            { new Command() { Action = Actions.GET, TypeName = "WaitTaskState", JSONType = typeof(WaitTaskStateQuery), Resources = new List<string>()
                {
                    "/WaitTaskState/{AMR}",
                }
            } }
        };

        private HttpClient HttpClient { get; set; }
        private Client Client { get; set; }


        public string UserName => "toolkitadmin";
        public string ConnectionString(string host) => $"https://{host}:8443";
        public string ConnectionString(string host, string resource) => $"https://{host}:8443{resource}";

        public bool IsException { get; private set; }
        public Exception RESTException { get; private set; }
        public bool IsHttpStatus { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }


        private void Reset()
        {
            RESTException = null;
            IsException = false;

            IsHttpStatus = false;
        }

        private void Testing(string host, string password)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender1, certificate, chain, sslPolicyErrors) => true;
            byte[] cred = UTF8Encoding.UTF8.GetBytes($"{UserName}:{password}");
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            Client = new Client(ConnectionString(host), HttpClient);

            List<DataStoreItem> lst = (List<DataStoreItem>)Client.DataStoreItem_POLL_Async("1").Result;
        }
        public async Task<string> Post(string url, string pass, string jSONData)
        {
            Reset();


            try
            {
                byte[] cred = UTF8Encoding.UTF8.GetBytes($"{UserName}:{pass}");
                using HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(jSONData, UTF8Encoding.UTF8, "application/json");

                return await client.PostAsync(url, content).Result.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                RESTException = ex;
                IsException = true;
                return string.Empty;
            }
            finally
            {
                ServicePointManager.ServerCertificateValidationCallback -= (sender1, certificate, chain, sslPolicyErrors) => true;
            }

        }
        public async Task<string> Put(string url, string pass, string jSONData)
        {
            Reset();

            ServicePointManager.ServerCertificateValidationCallback += (sender1, certificate, chain, sslPolicyErrors) => true;
            try
            {
                byte[] cred = UTF8Encoding.UTF8.GetBytes($"{UserName}:{pass}");
                using HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(jSONData, UTF8Encoding.UTF8, "application/json");

                return await client.PutAsync(url, content).Result.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                RESTException = ex;
                IsException = true;
                return string.Empty;
            }
            finally
            {
                ServicePointManager.ServerCertificateValidationCallback -= (sender1, certificate, chain, sslPolicyErrors) => true;
            }

        }
        public async Task<string> Delete(string url, string pass)
        {
            Reset();

            ServicePointManager.ServerCertificateValidationCallback += (sender1, certificate, chain, sslPolicyErrors) => true;
            try
            {
                byte[] cred = UTF8Encoding.UTF8.GetBytes($"{UserName}:{pass}");
                using HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                return await client.DeleteAsync(url).Result.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                RESTException = ex;
                IsException = true;
                return string.Empty;
            }
            finally
            {
                ServicePointManager.ServerCertificateValidationCallback -= (sender1, certificate, chain, sslPolicyErrors) => true;
            }

        }
        public async Task<string> Get(string url, string pass)
        {
            Reset();

            ServicePointManager.ServerCertificateValidationCallback += (sender1, certificate, chain, sslPolicyErrors) => true;
            try
            {
                byte[] cred = UTF8Encoding.UTF8.GetBytes($"{UserName}:{pass}");
                using HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string res = await client.GetAsync(url).Result.Content.ReadAsStringAsync();

                if(!res.StartsWith("["))
                {
                    if(res.StartsWith("<html>"))
                    {
                        Match match = Regex.Match(res, @"(?:<h1>)[0-9]+");
                        if(match.Success)
                        {
                            IsHttpStatus = true;
                            HttpStatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), match.Value.Replace("<h1>", ""));
                        }
                    }
                    else
                        throw new Exception(res);
                }


                return res;
            }
            catch(Exception ex)
            {
                RESTException = ex;
                IsException = true;
                return string.Empty;
            }
            finally
            {
                ServicePointManager.ServerCertificateValidationCallback -= (sender1, certificate, chain, sslPolicyErrors) => true;
            }
        }
        public async Task<Stream> Stream(string url, string pass)
        {
            Reset();

            ServicePointManager.ServerCertificateValidationCallback += (sender1, certificate, chain, sslPolicyErrors) => true;
            try
            {
                byte[] cred = UTF8Encoding.UTF8.GetBytes($"{UserName}:{pass}");
                using HttpClient client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/event-stream"));


                return await client.GetStreamAsync(url);
            }
            catch(Exception ex)
            {
                RESTException = ex;
                IsException = true;
                return null;
            }
            finally
            {
                ServicePointManager.ServerCertificateValidationCallback -= (sender1, certificate, chain, sslPolicyErrors) => true;
            }


        }

    }
}

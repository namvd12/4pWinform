using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
namespace _4P_PROJECT.Control
{
    internal class Https
    {
        private HttpClient client;
        private static string localHost = "https://192.168.1.116/testPHP/";
        private static string Url = "";
        private static string Url_maintenance_plan = localHost + "machinePlan.php";
        private static string Url_spare_part = localHost + "sparePartPlan.php";
        private static string Url_delete_maintenance_plan = localHost + "deleteMachinePlan.php";
        private static string Url_delete_spare_part = localHost + "deleteSparePartPlan.php";
        private static string Url_machine = localHost + "machine.php";
        private static string Url_machineStatusNG = localHost + "machineListNG.php";
        private static string Url_notiNG = localHost + "sendNotification";
        private static string responseString = string.Empty;

        private string path = "setting.bin";
        public Https()
        {
            if (System.IO.File.Exists(path))
            {
                localHost = "https://" + System.IO.File.ReadAllText(path) + "/testPHP/";
                Url_maintenance_plan = localHost + "machinePlan.php";
                Url_spare_part = localHost + "sparePartPlan.php";
                Url_delete_maintenance_plan = localHost + "deleteMachinePlan.php";
                Url_delete_spare_part = localHost + "deleteSparePartPlan.php";
                Url_machine = localHost + "machine.php";
                string webSocketHost = "https://" + System.IO.File.ReadAllText(path) + "/WebSocket/";
                Url_machineStatusNG = webSocketHost + "machineListNG.php";
                Url_notiNG = "http://" + System.IO.File.ReadAllText(path) + "/api/sendNotification";
            }
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            client = new HttpClient(clientHandler);
        }
        private class myRequest
        {
            public string tulaKey = string.Empty;
        }

        private class myPost
        {
            public uint tulaData1;
            public string tulaData2 = string.Empty;
            public string tulaData3 = string.Empty;
            public string tulaData4 = string.Empty;
            public string tulaData5 = string.Empty;
            public string tulaData6 = string.Empty;
            public string tulaData7 = string.Empty;
            public string tulaData8 = string.Empty;
            public string tulaData9 = string.Empty;
        }

        public enum TypeInfor
        {
            MACHINE,
            MACHINE_PLAN,
            SPARE_PART,
            MACHINE_LIST_NG,
            NOTI_NG,
        };
        private async Task<string> get(TypeInfor type_plan, string tulaKey, string tulaData1 = null, string tulaData2 = null)
        {
            if (type_plan == TypeInfor.MACHINE_PLAN)
            {
                Url = Url_maintenance_plan;
            }
            else if (type_plan == TypeInfor.SPARE_PART)
            {
                Url = Url_spare_part;
            }
            else if (type_plan == TypeInfor.MACHINE)
            {
                Url = Url_machine;
            }
            else
            {
                return string.Empty;
            }
            var obj = new myRequest
            {
                tulaKey = tulaKey,

            };
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            var contentdata = new StringContent(content);

            var response = await client.PostAsync(Url, contentdata);

            return responseString = await response.Content.ReadAsStringAsync();

        }

        private async Task<string> getImage(string url)
        {
            string dirReplace = "C:\\xampp\\htdocs\\TestPHP";
            string response = string.Empty;
            if (System.IO.File.Exists(url))
            {
                response = System.IO.File.ReadAllText(url);
            }
            else if (url.Contains(dirReplace))
            {
                url = url.Replace(dirReplace, localHost);
                response = await client.GetStringAsync(url);
            }
            else
            {
                url = url.Replace("C:/xampp/htdocs/TestPHP", localHost);
                response = await client.GetStringAsync(url);
            }
            return response;
        }

        private async Task<string> set(TypeInfor type_plan, uint tulaData1, string tulaData2 = "",
                        string tulaData3 = "", string tulaData4 = "", string tulaData5 = "", string tulaData6 = "",
                        string tulaData7 = "", string tulaData8 = "", string tulaData9 = "")
        {
            if (type_plan == TypeInfor.MACHINE_PLAN)
            {
                Url = Url_maintenance_plan;
            }
            else if (type_plan == TypeInfor.SPARE_PART)
            {
                Url = Url_spare_part;
            }
            else if (type_plan == TypeInfor.MACHINE)
            {
                Url = Url_machine;
            }
            else
            {
                return string.Empty;
            }
            var obj = new myPost
            {
                tulaData1 = tulaData1,
                tulaData2 = tulaData2,
                tulaData3 = tulaData3,
                tulaData4 = tulaData4,
                tulaData5 = tulaData5,
                tulaData6 = tulaData6,
                tulaData7 = tulaData7,
                tulaData8 = tulaData8,
                tulaData9 = tulaData9,
            };
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            var contentdata = new StringContent(content);

            var response = await client.PostAsync(Url, contentdata);

            return responseString = await response.Content.ReadAsStringAsync();

        }
        private async Task<string> set(TypeInfor type_plan, string jsonText)
        {
            if (type_plan == TypeInfor.MACHINE_LIST_NG)
            {
                Url = Url_machineStatusNG;
            }
            else if (type_plan == TypeInfor.NOTI_NG)
            {
                Url = Url_notiNG;
            }
            else
            {
                return string.Empty;
            }

            var response = await client.PostAsJsonAsync(Url, jsonText);

            return responseString = await response.Content.ReadAsStringAsync();

        }
        private async Task<string> delete(TypeInfor type_plan, string tulaKey)
        {
            if (type_plan == TypeInfor.SPARE_PART)
            {
                Url = Url_delete_spare_part;
            }
            else if (type_plan == TypeInfor.MACHINE_PLAN)
            {
                Url = Url_delete_maintenance_plan;
            }
            else
            {
                return string.Empty;
            }
            var obj = new myRequest
            {
                tulaKey = tulaKey,
            };
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            var contentdata = new StringContent(content);

            var response = await client.PostAsync(Url, contentdata);

            return responseString = await response.Content.ReadAsStringAsync();

        }

        public string GetData(TypeInfor type_plan, string tulaKey, string tulaData1 = null, string tulaData2 = null)
        {
            Task<string> task = Task.Run<string>(async () => await get(type_plan, tulaKey, tulaData1, tulaData2));
            try
            {
                return task.Result;
            }
            catch (Exception)
            {
                throw;
                return string.Empty;
            }
        }
        public string GetDataImage(string url)
        {
            Task<string> task = Task.Run<string>(async () => await getImage(url));
            try
            {
                return task.Result;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public string SetData(TypeInfor type_plan, uint tulaData1, string tulaData2 = "",
                        string tulaData3 = "", string tulaData4 = "", string tulaData5 = "", string tulaData6 = "",
                        string tulaData7 = "", string tulaData8 = "", string tulaData9 = "")
        {
            Task<string> task = Task.Run<string>(async () => await set(type_plan, tulaData1, tulaData2, tulaData3, tulaData4, tulaData5,
                                                                tulaData6, tulaData7, tulaData8, tulaData9));
            try
            {
                return task.Result;
            }
            catch
            {

                return string.Empty;
            }
        }

        public string SetData(TypeInfor type_plan, string text)
        {
            Task<string> task = Task.Run<string>(async () => await set(type_plan, text));
            try
            {
                return task.Result;
            }
            catch
            {

                return string.Empty;
            }
        }

        public string DeleteData(TypeInfor type_plan, string tulaKey)
        {
            Task<string> task = Task.Run<string>(async () => await delete(type_plan, tulaKey));
            try
            {
                return task.Result;
            }
            catch
            {

                return string.Empty;
            }
        }

        public string sendNotification(string machineJson)
        {
            Task<string> task = Task.Run<string>(async () => await set(TypeInfor.NOTI_NG, machineJson));
            try
            {
                return task.Result;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}

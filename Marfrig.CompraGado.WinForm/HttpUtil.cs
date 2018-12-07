using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace Marfrig.CompraGado.WinForm
{
    public class HttpUtil
    {
        public static List<T> GetAll<T>(string url)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url))
                {
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var fileJsonString = response.Result.Content.ReadAsStringAsync().Result;

                        return JsonConvert.DeserializeObject<T[]>(fileJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro");
                        return null;
                    }
                }
            }
        }

        public static bool Post<T>(string url, T item)
        {
            HttpClient client = new HttpClient();

            try
            {
                string jsonObject = JsonConvert.SerializeObject(item);

                HttpResponseMessage responsePost = client.PostAsync(url, new StringContent(jsonObject, Encoding.UTF8, "application/json")).Result;

                if (responsePost.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }

        public static bool Put<T>(string url, T item)
        {
            HttpClient client = new HttpClient();

            try
            {
                string jsonObject = JsonConvert.SerializeObject(item);

                HttpResponseMessage responsePut = client.PutAsync(url, new StringContent(jsonObject, Encoding.UTF8, "application/json")).Result;

                if (responsePut.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }

        public static bool Delete(string url, int id)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage responseDelete = client.DeleteAsync(url + id).Result;

                if (responseDelete.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}

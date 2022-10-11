using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
        public class AccountController : Controller
        {
            HttpClient HttpClient;
            string addressLogin, addressRegist, addressForgotPassword;
            public AccountController()
            {
                this.addressLogin = "https://localhost:44308/api/Account/Login";
                this.addressRegist = "https://localhost:44308/api/Account/Register";
                this.addressForgotPassword = "https://localhost:44308/api/Account/ForgotPassword";
            }

            public IActionResult Login()
            {
                return View();
            }


            [HttpPost]
            public async Task<IActionResult> Login(Login login)
            {
                HttpClient = new HttpClient
                {
                    BaseAddress = new Uri(addressLogin)
                };

                StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
                var result = HttpClient.PostAsync(addressLogin, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                    HttpContext.Session.SetString("Role", data.data.role);

                if (HttpContext.Session.GetString("Role").Equals("Kepala Bagian Produksi"))
                    return RedirectToAction("Index", "Kabag");
                else if (HttpContext.Session.GetString("Role").Equals("ManKeu"))
                    return RedirectToAction("Index", "ManKeu");
                else if (HttpContext.Session.GetString("Role").Equals("Manager"))
                    return RedirectToAction("Index", "Manager");
                else
                    return RedirectToAction("Unauthorized", "ErrorPage");
            }
                return View();
            }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(Register register)
            {
                HttpClient = new HttpClient
                {
                    BaseAddress = new Uri(addressRegist)
                };
                StringContent content = new StringContent(JsonConvert.SerializeObject(register), Encoding.UTF8, "application/json");
                var result = HttpClient.PostAsync(addressRegist, content).Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Login", "Account");
                return View();
            }

            public IActionResult ForgotPassword()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
            {
                HttpClient = new HttpClient
                {
                    BaseAddress = new Uri(addressForgotPassword)
                };

                StringContent content = new StringContent(JsonConvert.SerializeObject(forgotPassword), Encoding.UTF8, "application/json");
                var result = HttpClient.PostAsync(addressForgotPassword, content).Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Login", "Account");
                return View();
            }
        }
}

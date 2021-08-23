using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Controllers {
    public class ColaboradorController : Controller {
        private static HttpClient _httpClient;

        public ColaboradorController() {
            _httpClient = new HttpClient();
        }
        // GET: Colaborador
        public async Task<IActionResult> Index() {
            List<Colaborador> colaboradores = new();
            HttpResponseMessage Res = await GerarHttpClient().GetAsync("colaborador");

            if (Res.IsSuccessStatusCode) {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                colaboradores = JsonConvert.DeserializeObject<List<Colaborador>>(EmpResponse);
            }

            foreach (var item in colaboradores) {
                var nextBirthday = item.DataNascimento.AddYears(DateTime.Today.Year - item.DataNascimento.Year);
                if (nextBirthday < DateTime.Today) {
                    nextBirthday = nextBirthday.AddYears(1);
                }
                item.DiasParaAniversario = (nextBirthday - DateTime.Today).Days;
            }


            return View(colaboradores);
        }

        //GET: Colaborador/Details/5
        public async Task<IActionResult> Details(string id) {
            Colaborador colaborador = new();
            HttpResponseMessage Res = await GerarHttpClient().GetAsync($"colaborador/{id}");

            if (Res.IsSuccessStatusCode) {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                colaborador = JsonConvert.DeserializeObject<Colaborador>(EmpResponse);
            }

            return View(colaborador);
        }

        // GET: Colaborador/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Colaborador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,Nome,NomeMae,NomePai,Email,Telefone,DataNascimento")] Colaborador colaborador) {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(colaborador), Encoding.UTF8, "application/json");
            HttpResponseMessage Res = await GerarHttpClient().PostAsync("colaborador", httpContent);

            if (!Res.IsSuccessStatusCode) {
                ModelState.AddModelError(string.Empty, "CPF já cadastrado");
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Colaborador/Delete/5
        public async Task<IActionResult> Delete(string id) {
            Colaborador colaborador = new();
            HttpResponseMessage Res = await GerarHttpClient().GetAsync($"colaborador/{id}");

            if (Res.IsSuccessStatusCode) {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                colaborador = JsonConvert.DeserializeObject<Colaborador>(EmpResponse);
            }

            return View(colaborador);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            HttpResponseMessage Res = await GerarHttpClient().DeleteAsync($"colaborador/{id}");

            return RedirectToAction(nameof(Index));
        }

        private HttpClient GerarHttpClient() {
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return _httpClient;
        }
    }
}

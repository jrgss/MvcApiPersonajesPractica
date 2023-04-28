using Microsoft.AspNetCore.Mvc;
using MvcApiPersonajesPractica.Models;
using MvcApiPersonajesPractica.Services;

namespace MvcApiPersonajesPractica.Controllers
{
    public class PersonajesController : Controller
    {
        private ServicePersonajes service;
        public PersonajesController(ServicePersonajes service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }
        public async Task<IActionResult> Details(int id)
        {
            Personaje per = await this.service.FindPersonaje(id);
            return View(per);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Personaje per)
        {
            await this.service.InsertarPersonaje(per.IdPersonaje, per.Nombre, per.Imagen, per.IdSerie);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Personaje per = await this.service.FindPersonaje(id);
            return View(per);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Personaje per)
        {
            await this.service.UpdatePersonaje(per.IdPersonaje, per.Nombre, per.Imagen, per.IdSerie);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeletePersonaje(id);
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbstractFactory.Core;
using AbstractFactory.MVC;
using AbstractFactory.MVC.Repository.IRepository;
using AbstractFactory.MVC.Models;

namespace AbstractFactory.MVC.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ICarroRepository carroRepository;

        public CarrosController(ICarroRepository carroRepository)
        {
            this.carroRepository = carroRepository;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            return View(await carroRepository.ObtenerCarrosAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await carroRepository.ObtenerCarroPorIdAsync(id.Value);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Gama")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                await carroRepository.CrearCarroAsync(carro);
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await carroRepository.ObtenerCarroPorIdAsync(id.Value);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Gama")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await carroRepository.EditarCarroAsync(carro);
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await carroRepository.ObtenerCarroPorIdAsync(id.Value);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await carroRepository.ObtenerCarroPorIdAsync(id);
            if (carro != null)
            {
                await carroRepository.EliminarCarroAsync(carro);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

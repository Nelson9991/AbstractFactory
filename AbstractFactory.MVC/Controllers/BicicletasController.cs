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

namespace AbstractFactory.MVC.Controllers
{
    public class BicicletasController : Controller
    {
        private readonly IBicicletaRepository bicicletaRepository;

        public BicicletasController(IBicicletaRepository bicicletaRepository)
        {
            this.bicicletaRepository = bicicletaRepository;
        }

        // GET: Bicicletas
        public async Task<IActionResult> Index()
        {
            return View(await bicicletaRepository.ObtenerBicicletasAsync());
        }

        // GET: Bicicletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await bicicletaRepository.ObtenerBicicletaPorIdAsync(id.Value);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // GET: Bicicletas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Gama")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                await bicicletaRepository.CrearBicicletaAsync(bicicleta);
                return RedirectToAction(nameof(Index));
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await bicicletaRepository.ObtenerBicicletaPorIdAsync(id.Value);
            if (bicicleta == null)
            {
                return NotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Marca,Modelo,Gama")] Bicicleta bicicleta
        )
        {
            if (id != bicicleta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await bicicletaRepository.EditarBicicletaAsync(bicicleta);
                return RedirectToAction(nameof(Index));
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await bicicletaRepository.ObtenerBicicletaPorIdAsync(id.Value);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicicleta = await bicicletaRepository.ObtenerBicicletaPorIdAsync(id);
            if (bicicleta != null)
            {
                await bicicletaRepository.EliminarBicicletaAsync(bicicleta);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

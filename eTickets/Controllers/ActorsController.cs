using eTickets.Data;
using eTickets.Models;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

//using eTickets.Data.Static;
//using Microsoft.AspNetCore.Authorization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actor/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetailts = await _service.GetByIdAsync(id);

            if (actorDetailts == null) return View("NotFound");
            return View(actorDetailts);
        }

        // Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetailts = await _service.GetByIdAsync(id);

            if (actorDetailts == null) return View("NotFound");
            return View(actorDetailts);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetailts = await _service.GetByIdAsync(id);

            if (actorDetailts == null) return View("NotFound");
            return View(actorDetailts);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetailts = await _service.GetByIdAsync(id);

            if (actorDetailts == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

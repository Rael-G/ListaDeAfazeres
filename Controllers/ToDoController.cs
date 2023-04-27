using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaDeAfazeres.Data;
using ListaDeAfazeres.Models;

namespace ListaDeAfazeres.Controllers
{
	public class ToDoController : Controller
	{
		private readonly AppDbContext _context;

		public ToDoController(AppDbContext context)
		{
			_context = context;
		}

		// GET: ToDo
		public async Task<IActionResult> Index()
		{
			var todoList = await _context.ToDo
			.Include(td => td.Notes)
			.AsNoTracking()
			.ToListAsync();

			return _context.ToDo != null ?
						  View(todoList) :
						  Problem("Entity set 'AppDbContext.ToDo'  is null.");
		}

		// GET: ToDo/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.ToDo == null)
			{
				return NotFound();
			}

			var toDo = await _context.ToDo
				.FirstOrDefaultAsync(m => m.Id == id);
			if (toDo == null)
			{
				return NotFound();
			}

			return View(toDo);
		}

		// GET: ToDo/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: ToDo/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ToDo toDo)
		{
			if (ModelState.IsValid)
			{
				Console.WriteLine("is Valid");
				_context.ToDo.Add(toDo);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			Console.WriteLine("is not Valid");
			return View(toDo);
		}

		// GET: ToDo/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.ToDo == null)
			{
				return NotFound();
			}

			var toDo = await _context.ToDo.FindAsync(id);
			if (toDo == null)
			{
				return NotFound();
			}
			return View(toDo);
		}

		// POST: ToDo/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,IsComplete")] ToDo toDo)
		{
			if (id != toDo.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(toDo);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ToDoExists(toDo.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(toDo);
		}

		// GET: ToDo/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.ToDo == null)
			{
				return NotFound();
			}

			var toDo = await _context.ToDo
				.FirstOrDefaultAsync(m => m.Id == id);
			if (toDo == null)
			{
				return NotFound();
			}

			return View(toDo);
		}

		// POST: ToDo/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.ToDo == null)
			{
				return Problem("Entity set 'AppDbContext.ToDo'  is null.");
			}
			var toDo = await _context.ToDo.FindAsync(id);
			if (toDo != null)
			{
				_context.ToDo.Remove(toDo);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ToDoExists(int id)
		{
			return (_context.ToDo?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}

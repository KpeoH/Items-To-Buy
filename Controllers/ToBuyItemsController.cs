using Microsoft.AspNetCore.Mvc;
using HTTPswagerTEST.Models;
using HTTPswagerTEST;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HTTPswagerTEST.Controllers
{
	[ApiController]
	//[Produces("application/json")]
	[Route("[controller]")]
	public class ToBuyItemsController : ControllerBase
	{
		private readonly ToBuyItemsContext _context;


		public ToBuyItemsController(ToBuyItemsContext context)
		{
			_context = context;

			if (_context.ToBuyItems.Count() == 0 )
			{
				_context.ToBuyItems.Add(new ToBuyItems { Id = 1, Name = "Кириешки", Quantity = 1, IsBought = false});
				_context.SaveChanges();
			}
		}

		/// <summary>
		/// Выводит список всех покупок в списке
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult<List<ToBuyItems>> GetAll()
		{
			return _context.ToBuyItems.ToList();
		}

		/// <summary>
		/// Создаём новую покупку
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult<ToBuyItems> Create(ToBuyItems item)
		{
			_context.ToBuyItems.Add(item);
			_context.SaveChanges();

			return Ok("Готово");
		}

		/// <summary>
		/// Вставляем новую инфу в покупку
		/// </summary>
		/// <param name="id"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public IActionResult Update(int id, ToBuyItems item)
		{
			if (item == null || item.Id != id)
				return BadRequest();

			var tobuy = _context.ToBuyItems.Find(id);

			if (tobuy == null)
				return NotFound();

			tobuy.IsBought = item.IsBought;
			tobuy.Name = item.Name;
			tobuy.Quantity = item.Quantity;

			_context.ToBuyItems.Update(tobuy);
			_context.SaveChanges();

			return Ok($"Всё гуд, новая информация отправилась");
		}

		/// <summary>
		/// Меняем нужное кол-во товара
		/// </summary>
		/// <param name="id"></param>
		/// <param name="quantity"></param>
		/// <returns></returns>
		[HttpPatch("{quantity}")]
		public IActionResult Patch(int id, int quantity)
		{
			var tobuy = _context.ToBuyItems.Find(id);
			if (tobuy == null)
				return NotFound();

			tobuy.Quantity = quantity;
			_context.ToBuyItems.Update(tobuy);
			_context.SaveChanges();

			return Ok($"Теперь нам нужно {quantity} штучек!");
		}

		/// <summary>
		/// Меняем Cтатус (куплен или нет)
		/// </summary>
		/// <param name="id"></param>
		/// <param name="isBought"></param>
		/// <returns></returns>
		[HttpPatch("{id}/isBought")]
		public IActionResult Patch(int id, bool isBought)
		{
			var tobuy = _context.ToBuyItems.Find(id);
			if (tobuy == null)
				return NotFound();

			tobuy.IsBought = isBought;
			_context.ToBuyItems.Update(tobuy);
			_context.SaveChanges();

			return Ok($"Статус товара изменён на {isBought}");
		}

		/// <summary>
		/// Удаляем негодяя!
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var tobuy = _context.ToBuyItems.Find(id);

			if (tobuy == null)
				return NotFound();

			_context.ToBuyItems.Remove(tobuy);
			_context.SaveChanges();

			return Ok($"Товар с номером {id} успешно удалён");
		}

	}
}

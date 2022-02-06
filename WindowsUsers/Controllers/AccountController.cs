using Microsoft.AspNetCore.Mvc;
using System;
using System.Management;

namespace WindowsUsers.Controllers
{
    /// <summary>
    /// Котроллер, выполняет роль поиска пользователя в Windows
    /// </summary>
    [Route("Users/[controller]")]
	[ApiController]
	public class AccountController
		: ControllerBase
	{
		/// <summary>
		/// Отправляет запрос на поиск пользователя
		/// </summary>
		/// <param name="name">Имя пользователя</param>
		/// <returns>Возвращает страницу с результатом поиска</returns>
		[HttpGet]
		public IActionResult Account([FromQuery] String name)
		{
			if (name is null || name.Trim() == String.Empty)
				return NotFound("имя не может быть пустым!");

			var contentFile = System.IO.File.ReadAllText("./Views/Account.html");

			/// проверяем, существует ли пользователь
			var result = IsAccountExist(name);

			/// добавляем результат в файл
			contentFile = contentFile.Insert(contentFile.IndexOf("msg") + 5, result ? $"Пользователь <b>{name}</b> есть" : $"Пользователя <b>{name}</b> нет");  ;

			return Content(contentFile, "text/html");
		}

		/// <summary>
		/// Проверяет, существует ли пользователь в windows
		/// </summary>
		/// <param name="name">Имя пользователя</param>
		/// <returns>true - пользователь существует. false - пользователя нет.</returns>
		private Boolean IsAccountExist(String name)
		{
			/// Запрос на получение всех пользователей
			var searcher = new ManagementObjectSearcher("root\\CIMV2",
					  "SELECT * FROM Win32_UserAccount");

			/// ищем пользователя
			foreach (ManagementObject envVar in searcher.Get())
			{ 			
				if (envVar["Name"].ToString() == name) /// если нашли, то возвращаем true
					return true;
			}

			/// если не нашли, то возвращаем false
			return false;
		}
	}
}

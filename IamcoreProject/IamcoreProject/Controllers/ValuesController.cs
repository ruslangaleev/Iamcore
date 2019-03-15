using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IamcoreProject.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IamcoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(IWritableOptions<ConfigModel> options)
        {
            var valueString = options.Value.FieldString;
            var valueInt = options.Value.Fieldint;

            options.Update(t =>
            {
                t.FieldString = "value1";
                t.Fieldint = 1;
            });
        }

        /// <summary>
        /// Вернет значения
        /// </summary>
        /// <returns>Коллекция значений.</returns>
        /// <response code="200">Вернет список значений.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Конкатенирует строку.
        /// </summary>
        /// <remarks>
        /// Образец запроса:
        ///
        ///     POST /api/Values/
        ///     {
        ///        value
        ///     }
        ///
        /// </remarks>
        /// <param name="value">Значение для конкатенации.</param>
        /// <returns>Вернет сконтаренированную строку.</returns>
        /// <response code="200">Успешно сконтактенированная строка.</response>
        /// <response code="400">Значение пустое.</response> 
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return BadRequest();
            }

            return Ok(new
            {
                CreateAt = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"),
                UpdateAt = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"),
                Value = $"{value}{value}"
            });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HallOfFame.Models;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace HallOfFame.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly CompetenciesContext _context;

        public PersonController(CompetenciesContext context)
        {
            _context = context;
        }
        
        // GET: api/v1/persons Получение всех сотрудников
        [Route("~/api/v1/persons")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return Ok(await _context.Persons.ToListAsync());
        }

        // GET: api/v1/person/id Получить конкретного сотрудника
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                errors["Others"] = "Сущность не найдена";
                return NotFound(errors);
            }

            return Ok(person);
        }

        // PUT: api/v1/person/id Обновление данных конкретного сотрудника
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(long id, Person updatedPerson)
        {
            if (id != updatedPerson.Id)
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                errors["Others"] = "Неверный запрос";
                return BadRequest(errors);
            }


            var person = await _context.Persons.FindAsync(id);

            //обновляем поля у сотрудника
            _context.Entry(person).CurrentValues.SetValues(updatedPerson);

            //получаем текущие навыки сотрудника
            var personSkills = person.Skills.ToList();

            foreach (var personSkill in personSkills)
            {
                var skill = updatedPerson.Skills.SingleOrDefault(s => s.Name == personSkill.Name);
                if (skill != null)
                {
                    //обновляем поле у навыка сотрудника
                    _context.Entry(personSkill).CurrentValues.SetValues(skill);
                }
                else
                {
                    //удаляем, если навыка нет
                    _context.Remove(personSkill);
                }
            }

            //добавляем новые навыки
            foreach (var skill in updatedPerson.Skills)
            {
                if (personSkills.All(s => s.Name != skill.Name))
                {
                    person.Skills.Add(skill);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!PersonExists(id))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    errors["Others"] = "Сущность не найдена";
                    return NotFound(errors);
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return Ok(person);
        }

        // POST: api/v1/person Добавление нового сотрудника
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            
            return Ok(person);
        }

        // DELETE: api/v1/person/id  Удаление существующего сотрудника
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(long id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                errors["Others"] = "Сущность не найдена";
                return NotFound(errors);
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(long id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}

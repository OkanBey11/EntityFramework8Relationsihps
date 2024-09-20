using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework8Relationsihps.Data;
using EntityFramework8Relationsihps.Data.DTOs;
using EntityFramework8Relationsihps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework8Relationsihps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TlouControllers : ControllerBase
    {
        private readonly DataContext _context;

        public TlouControllers(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int id){
            var character = await _context.Characters
            .Include(c => c.Backpack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);

            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request){
            var newCharacter = new Character
            {
                Name = request.Name
            };

            var backpack = new Backpack { Description = request.Backpack.Description, Character = newCharacter};
            var weapons = request.Weapons.Select(w => new Weapon {Name = w.Name, Character = newCharacter}).ToList();
            var factions = request.Factions.Select(f => new Faction{Name = f.Name, Characters = new List<Character> {newCharacter}} ).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(c => c.Backpack).Include(c => c.Weapons).ToListAsync());
        }
    }
}
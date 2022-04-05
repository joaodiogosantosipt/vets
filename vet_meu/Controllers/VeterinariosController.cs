using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vets.Models;
using vet_meu.Data;
using Microsoft.AspNetCore.Http;

namespace vet_meu.Controllers
{
    public class VeterinariosController : Controller
    {
        /// <summary>
        ///  cria uma instancia de accesso à base de dados
        /// </summary>
        private readonly ApplicationDbContext _context;


        public VeterinariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veterinarios
        public async Task<IActionResult> Index()
        {
           /* acesso à base de dados
            * SELECT *
            * FROM VETERINARIOS
            * 
            * e, depois estamos a enviar os dados para a view
            */
            
            return View(await _context.Veterinarios.ToListAsync());
        }

        // GET: Veterinarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarios = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarios == null)
            {
                return NotFound();
            }

            return View(veterinarios);
        }

        // GET: Veterinarios/Create

        /// <summary>
        /// usado para o primeiro accesso à view 'create', em modo HTTP GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// metodo usado para recuperar os dados enviados pelos utilizadores
        /// do browser para o server
        /// </summary>
        /// <param name="veterinarios"></param>
        /// <returns></returns>
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NumCedulaProf,Fotografia")] Veterinarios veterinarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinarios);
        }

        // GET: Veterinarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarios = await _context.Veterinarios.FindAsync(id);
            if (veterinarios == null)
            {
                return NotFound();
            }
            return View(veterinarios);
        }

        // POST: Veterinarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NumCedulaProf,Fotografia")] Veterinarios veterinario, IFormFile fotovet)
        {/*
          * algoritmo para processar ao ficheiro com a imagem
          * 
          * se ficheiro imagem for nulo
          *     atribuir uma imagem generica ao veterinario
          * else
          *     será que o ficheiro é uma imagem?
          *     se não for
          *         criar mensagem de erro
          *         devolver o controlo da app à view
          *     else
          *         - definir o nome a atraibuir à imagem
          *         - atribuir aos dados do novo vet, o nome do ficheiro da imagem
          *         - guardar a imagem no disco rigido do server
          */

            if (fotovet == null)
            {
                veterinario.Fotografia = "noVet.png";
            }
            else
            {
                if(!(fotovet.ContentType=="image/png" || fotovet.ContentType == "image/jpeg"))
                {
                    //criar mensagem de erro
                    ModelState.AddModelError("", "Por favor, adicione um ficheiro .png ou .jpg");
                    //devolver o controlo da app à view
                    //fornecendo-lhe os dados que o utilizador ja tinha preenchido no formulario
                    return View(veterinario);
                }
                else
                {
                    //temos ficheiro e é uma imagem...

                }

            }
            if (id != veterinario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinariosExists(veterinario.Id))
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
            return View(veterinario);
        }

        // GET: Veterinarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinarios = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarios == null)
            {
                return NotFound();
            }

            return View(veterinarios);
        }

        // POST: Veterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinarios = await _context.Veterinarios.FindAsync(id);
            _context.Veterinarios.Remove(veterinarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinariosExists(int id)
        {
            return _context.Veterinarios.Any(e => e.Id == id);
        }
    }
}

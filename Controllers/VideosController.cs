using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using video.Models;

namespace video.Controllers
{
    public class VideosController : Controller
    {
        private readonly Contexto _context;

        public VideosController(Contexto context)
        {
            _context = context;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videos.ToListAsync());
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,VideoAutor,VideoTitulo,LocalGravação,VideoTipo,VideoExtencao,VideoDuracao,VideoAssunto,VideoDescricao")] Video video, IFormFile arquivo)
        {
            var fileName = arquivo.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/video", fileName);

            if (video.VideoDescricao != null)
            {
                video.VideoTipo = verificarExtensao(fileName);//grava no bd a extenção do arquivo recebido
                using (var localFile = System.IO.File.OpenWrite(filePath))
                using (var uploadingFile = arquivo.OpenReadStream())
                {
                    uploadingFile.CopyTo(localFile);
                }
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        public string verificarExtensao(string nomeArquivo)
        {
            string extensaoArquivo = System.IO.Path.GetExtension(nomeArquivo).ToLower();
            string[] validacaoLista = { ".mp4", ".m4v", ".mov" };

            foreach (string extensao in validacaoLista)
            {
                if (extensao == extensaoArquivo)
                    return extensao;
            }
            return "none";
        }
        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,VideoAutor,VideoTitulo,LocalGravação,VideoTipo,VideoExtencao,VideoDuracao,VideoAssunto,VideoDescricao")] Video video)
        {
            if (id != video.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.VideoID))
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
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Videos == null)
            {
                return Problem("Entity set 'Contexto.Videos'  is null.");
            }
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(e => e.VideoID == id);
        }
    }
}

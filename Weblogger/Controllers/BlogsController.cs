using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weblogger.Data;
using Weblogger.Models;

namespace Weblogger.Controllers
{
    public class BlogsController : Controller
    {
        public ApplicationDbContext _db;
        public BlogsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var blogs = _db.Blogs.ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            Blog Weblog = new Blog();
            //Weblog.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            return View(Weblog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _db.Add(blog);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var blog = await _db.Blogs.SingleOrDefaultAsync(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
        //Edit Get
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var blog = await _db.Blogs.SingleOrDefaultAsync(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        //Edit Get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Blog Weblog)
        {
            if (id!=Weblog.Id)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            _db.Update(Weblog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Delete Get
        public IActionResult Delete(int id)
        {
            var blog = _db.Blogs.SingleOrDefault(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        //Delete Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var blog = _db.Blogs.SingleOrDefault(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            _db.Remove(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                _db.Dispose();
            }
        }




    }
}
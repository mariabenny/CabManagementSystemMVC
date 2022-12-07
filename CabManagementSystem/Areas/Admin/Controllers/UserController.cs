using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CabManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList());
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(MovieViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    _db.Movies.Add(new Movie()
        //    {
        //        Title = model.Title,
        //        Director = model.Director,
        //        Language = model.Language,
        //        ReleaseDate = model.ReleaseDate,
        //        Summary = model.Summary,
        //    });
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user == null)
                return NotFound();

            return View(new ApplicationUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ApplicationUser model)
        {
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user == null)
                return NotFound();

            _db.ApplicationUsers.Remove(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

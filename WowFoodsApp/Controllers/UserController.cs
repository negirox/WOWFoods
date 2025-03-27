using Microsoft.AspNetCore.Mvc;
using WowFoodsViewModels.Models;

namespace WowFoodsApp.Controllers
{
    public class UserController : Controller
    {
        
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //IUserDAL userDAL = new UserDAL();

                    // Create a UserBLL object and populate it with the form data
                    //var user = new UserBLL
                    //{
                    //    first_name = model.FirstName,
                    //    last_name = model.LastName,
                    //    email = model.Email,
                    //    username = model.Username,
                    //    password = model.Password,
                    //    contact = model.Contact,
                    //    address = model.Address,
                    //    gender = model.Gender,
                    //    user_type = model.UserType.ToString(),
                    //    added_date = DateTime.Now,
                    //    added_by = 1 // Assuming the current user ID is 1 for this example
                    //};

                    // Insert the user into the database
                    //userDAL.Insert(user);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }


        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

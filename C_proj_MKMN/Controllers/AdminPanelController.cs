﻿using C_proj_MKMN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace C_proj_MKMN.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly UserManager<UserModel> _userManager;

        public AdminPanelController(UserManager<UserModel> userManager)
        {
            this._userManager = userManager;
        }

        // GET: AdminPanelController
        public ActionResult GetUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public ActionResult Index()
        {
           
            return View();
        }

        // GET: AdminPanelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminPanelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AdminPanelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminPanelController/Edit/5
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

        // GET: AdminPanelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminPanelController/Delete/5
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

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Inpitsu.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Inpitsu.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public RedirectToActionResult Cansel()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }
        public async Task<IActionResult> Edit(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            return View(role);
        }
        [HttpPost]
        public async Task<RedirectToActionResult> SubmitEdit(string Id, string name)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role != null)
            {
                role.Name = name;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }
            return RedirectToAction("Edit");
        }
        public async Task<RedirectToActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                
                if(role.Name == "banned")
                {
                    var users = await _userManager.GetUsersInRoleAsync(role.Name);
                    if (users != null)
                    {
                    
                        foreach (var user in users)
                        {
                            user.LockoutEnabled = false;
                            user.LockoutEnd = null;
                            await _userManager.UpdateAsync(user);
                            await _userManager.RemoveFromRoleAsync(user, "banned");
                        }
                    }
                }
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}

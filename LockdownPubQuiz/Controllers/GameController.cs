using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using LockdownPubQuiz.Core;
using LockdownPubQuiz.Core.Models;
using LockdownPubQuiz.Core.Repositories;
using LockdownPubQuiz.DAL.Authentication;
using LockdownPubQuiz.DAL.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LockdownPubQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public LockdownPubQuizDbContext dbContext;


        public GameController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, LockdownPubQuizDbContext dbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost]
        [Route("join-game")]
        public async Task<IActionResult> JoinGame([FromBody] Player model)
        {
            try
            {
                    dbContext.Add(model);
                    await dbContext.SaveChangesAsync();
                    return Ok(new Response { Status = "Success", Message = "Game joined successfully!" });
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("add-question")]
        public async Task<IActionResult> AddQuestion([FromBody] Question model)
        {
            try
            {
                dbContext.Add(model);
                await dbContext.SaveChangesAsync();
                return Ok(new Response { Status = "Success", Message = "Question Added successfully!" });
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("create-game")]
        public async Task<IActionResult> CreateGame([FromBody] Game model)
        {
            try
            {
                dbContext.Add(model);
                await dbContext.SaveChangesAsync();
                return Ok(new Response { Status = "Success", Message = "Game Created successfully!" });
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }
    }
}

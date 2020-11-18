using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using LockdownPubQuiz.Core;
using LockdownPubQuiz.Core.Repositories;
using LockdownPubQuiz.DAL.Authentication;
using LockdownPubQuiz.DAL.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


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



        [AllowAnonymous]
        [HttpGet]
        [Route("get-games")]
        public IActionResult GetGames()
        {
            try
            {
                List<Game> gamesList = new List<Game>();
                return Ok(gamesList);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("join-game")]
        public async Task<IActionResult> JoinGame([FromBody] Game model)
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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

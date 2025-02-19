﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKM_API.Context;
using SIBKM_API.Models;
using SIBKM_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        MyContext myContext;

        public UsersController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var data = myContext.Users.ToList();
            return Ok(new { status = 200, message = "data has been collected", data = data });
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var data = myContext.Users.Find(id);
            return Ok(new { status = 200, message = "data has been collected", data = data });
        }
        [HttpPost]
        public ActionResult Post(ViewModels.UserVM userVM)
        {
            User user = new User(userVM);
            myContext.Users.Add(user);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                return Ok(new { status = 200, message = "data has been collected" });
            }
            return BadRequest(new { status = 400, message = "data has not been updated" });
        }
        [HttpPut]
        public ActionResult Put(ViewModels.UserVM userVM)
        {
            User user = new User(userVM);
            myContext.Entry(user).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                return Ok(new { status = 200, message = "data has been collected" });
            }
            return BadRequest(new { status = 400, message = "data has not been updated" });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = myContext.Users.Find(id);
            myContext.Users.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                return Ok(new { status = 200, message = "data has been deleted" });
            }
            return BadRequest(new { status = 400, message = "data has not been deleted" });
        }

    }
}


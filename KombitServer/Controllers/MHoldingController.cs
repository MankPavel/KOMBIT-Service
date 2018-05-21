﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KombitServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KombitServer.Controllers
{
  [Route ("api/holding")]
  public class MHoldingController : Controller
  {
    private readonly KombitDBContext _context;
    public MHoldingController (KombitDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<MHolding> Get ()
    {
      var holding = _context.MHolding.ToList ();
      return holding;
    }

    [HttpGet ("{id}")]
    public IActionResult Get (int? id)
    {
      if (id == null)
      {
        return BadRequest ();
      }
      var holding = _context.MHolding.FirstOrDefault (x => x.Id == id);
      if (holding == null)
      {
        return NotFound ();
      }
      return Ok (holding);
    }

  }

}
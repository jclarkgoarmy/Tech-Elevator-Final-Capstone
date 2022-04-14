﻿using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Capstone.DAO.Interfaces;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryDAO itineraryDAO;

        public ItineraryController(IItineraryDAO _itineraryDAO)
        {
            itineraryDAO = _itineraryDAO;
        }

        [HttpPost("add")]
        public IActionResult AddItinerary(Itinerary itinerary)
        {
            bool result = itineraryDAO.AddItinerary(itinerary);
            if (result == true)
            {
                return Ok("itinerary added successfully");
            }
            else
            {
                return BadRequest("There was a problem adding that to your itinerary.");
            }
        }

        [HttpDelete("delete/{itineraryId}")]
        public IActionResult DeleteItinerary(int itineraryId)
        {
            bool result = itineraryDAO.DeleteItinerary(itineraryId);
            if (result == true)
            {
                return Ok("Itinerary deleted successfully");
            }
            else
            {
                return BadRequest("There was a problem deleting that from your itinerary.");
            }
        }

        [HttpPut("edit")]
        public IActionResult EditItinerary(Itinerary itinerary)
        {
            bool result = itineraryDAO.EditItinerary(itinerary);
            if (result == true)
            {
                return Ok("itinerary edited successfully");
            }
            else
            {
                return BadRequest("There was a problem in changing your itinerary.");
            }
        }

        [HttpGet("fetch/{id}")]
        public IActionResult GetItineraries(int id)
        {
            List<Itinerary> result = itineraryDAO.RetrieveItineraries(id);
            try
            { return Ok(result); }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error in GetItineraries - " + ex.Message });
            }

        }

        //[HttpGet("fetch/{userId}/{itineraryId}")]
        //public IActionResult GetItineraryDetails(int userId, int itineraryId)
        //{
        //    List<Landmark> result = itineraryDAO.RetrieveItineraryDetails(userId, itineraryId);
        //    try
        //    { return Ok(result); }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Server error in GetItineraries - " + ex.Message });
        //    }

        //}
    }
}
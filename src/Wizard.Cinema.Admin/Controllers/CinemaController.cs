﻿using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Repository.Condition;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api")]
    [Authorize]
    [ApiController]
    public class CinemaController : BaseController
    {
        private readonly CityService _cityService;
        private readonly HallService _hallService;
        private readonly CinemaService _cinemaService;

        public CinemaController(CityService cityService, HallService hallService, CinemaService cinemaService)
        {
            this._cityService = cityService;
            this._hallService = hallService;
            this._cinemaService = cinemaService;
        }

        [HttpGet("city")]
        public IActionResult SearchCity(string keyword)
        {
            if (keyword.IsNullOrEmpty())
                return Ok(Array.Empty<object>());

            IEnumerable<CityResponse.City> citys = this._cityService.Search(keyword);
            return Ok(citys.Take(7));
        }

        [HttpGet("city/{cityId}/cinemas")]
        public IActionResult SearchCinema(int cityId, string keyword, int page = 1, int size = 10)
        {
            if (size <= 0)
                return Ok(new PagedData<object>());

            PagedData<Remote.Models.Cinema> cinemas = this._cinemaService.GetByCityId(new SearchCinemaCondition()
            {
                CityId = cityId,
                Keyword = keyword,
                PageSize = size,
                PageNow = page
            });

            return Ok(new PagedData<object>
            {
                PageNow = cinemas.PageNow,
                PageSize = cinemas.PageSize,
                TotalCount = cinemas.TotalCount,
                Records = cinemas.Records.Select(x => new
                {
                    x.CinemaId,
                    x.Name,
                    x.Address
                })
            });
        }

        [HttpGet("cinemas/{cinemaId}/halls")]
        public IActionResult GetHallByCinemaId(int cinemaId)
        {
            if (cinemaId <= 0)
                return Ok(Enumerable.Empty<Hall>());

            IEnumerable<Hall> halls = this._hallService.GetByCinemaId(cinemaId);
            return Ok(halls);
        }

        [HttpGet("halls/{hallId}")]
        public IActionResult GetHall(int hallId)
        {
            Hall hall = _hallService.GetById(hallId);
            if (hall == null)
                return Fail("找不到影厅");

            return Ok(hall);
        }
    }
}

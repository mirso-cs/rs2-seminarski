using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Source.net.infrastructure.Dtos;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using Source.net.services.Services.Interfaces;

namespace Source.net.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : CRUDController<
            Rating,
            RatingDto,
            RatingDto,
            RatingView,
            RatingFilters
        >
    {
        public RatingController(RatingService service): base(service)
        {

        }
    }
}
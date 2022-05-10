using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBPApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NBPApp.Controllers
{
    public class CurrencyController : Controller
    {
        public readonly IMapper _mapper;

        public CurrencyController(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static readonly List<CurrencyDto> currents = new List<CurrencyDto>
        {
            new CurrencyDto {
                Currency = "bat (Tajlandia)",
                Code = "THB",
                Mid = 0.128m,
                EffectiveDate = DateTime.Parse("2022-05-10")
            },
            new CurrencyDto {
                Currency = "dolar amerykański",
                Code = "USD",
                Bid = 4.4044m,
                Ask = 4.4934m,
                EffectiveDate = DateTime.Parse("2022-05-10"),
                TradingDate = DateTime.Parse("2022-05-09")
            }
        };

        public IActionResult Index(string code = "")
        {
            var model = currents.Select(c => _mapper.Map<CurrencyViewModel>(c));
            return View(model);
        }
    }
}

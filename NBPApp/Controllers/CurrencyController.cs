using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBPApp.Models;
using NBPApp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NBPApp.Controllers
{
    public class CurrencyController : Controller
    {
        public readonly IMapper _mapper;
        private readonly ICurrentRepository currentRepository;

        public CurrencyController(IMapper mapper, ICurrentRepository currentRepository)
        {
            _mapper = mapper;
            this.currentRepository = currentRepository;
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
            //var model = currentRepository.GetAll().Select(c => _mapper.Map<CurrencyViewModel>(c));
            var model = currents.Select(c => _mapper.Map<CurrencyViewModel>(c));
            return View(model);
        }
    }
}

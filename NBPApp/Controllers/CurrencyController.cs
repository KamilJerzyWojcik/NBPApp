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
        private readonly ICurrencyRepository currentRepository;

        public CurrencyController(IMapper mapper, ICurrencyRepository currentRepository)
        {
            _mapper = mapper;
            this.currentRepository = currentRepository;
        }

        public IActionResult Index(string code = "")
        {
            var model = currentRepository.GetAll().Select(c => _mapper.Map<CurrencyViewModel>(c));
            return View(model);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBPApp.Models;
using NBPApp.Models.Repositories;
using NBPApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBPApp.Controllers
{
    public class CurrencyController : Controller
    {
        public readonly IMapper _mapper;
        private readonly ICurrencyRepository currentRepository;
        private readonly INBPService NBPService;

        public CurrencyController(IMapper mapper, ICurrencyRepository currentRepository, INBPService NBPService)
        {
            _mapper = mapper;
            this.currentRepository = currentRepository;
            this.NBPService = NBPService;
        }

        public async Task<IActionResult> Update()
        {
            var data = await NBPService.GetCurrenciesData();
            currentRepository.UpdateRange(data);
            return Redirect(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            if(currentRepository.GetAll().Count() == 0)
            {
                var data = await NBPService.GetCurrenciesData();
                currentRepository.AddRange(data);
            }  
            
            var model = currentRepository.GetAll().Select(c => _mapper.Map<CurrencyViewModel>(c));
            return View(model);
        }
    }
}

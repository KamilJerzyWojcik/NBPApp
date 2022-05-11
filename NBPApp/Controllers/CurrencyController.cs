using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBPApp.Models;
using NBPApp.Models.Repositories;
using NBPApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NBPApp.Controllers
{
    public class CurrencyController : Controller
    {
        public readonly IMapper _mapper;
        private readonly ICurrencyRepository currentRepository;
        private readonly INBPApiClient nBPApiClient;

        public CurrencyController(IMapper mapper, ICurrencyRepository currentRepository, INBPApiClient nBPApiClient)
        {
            _mapper = mapper;
            this.currentRepository = currentRepository;
            this.nBPApiClient = nBPApiClient;
        }

        public IActionResult Update()
        {
            var data = nBPApiClient.Get();
            currentRepository.UpdateRange(data);
            return Redirect(nameof(Index));
        }

        public IActionResult Index()
        {
            if(currentRepository.GetAll().Count() == 0)
            {
                var data = nBPApiClient.Get();
                currentRepository.AddRange(data);
            }  
            
            var model = currentRepository.GetAll().Select(c => _mapper.Map<CurrencyViewModel>(c));
            return View(model);
        }
    }
}

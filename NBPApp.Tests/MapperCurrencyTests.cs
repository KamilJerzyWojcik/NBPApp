using AutoMapper;
using NBPApp.Models;
using NBPApp.Models.Mappers;
using System;
using Xunit;

namespace NBPApp.Tests
{
    public class MapperCurrencyTests
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CurrencyBaseToViewModelProfile>());
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void AutoMapper_Is_Map_Correct_Mid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CurrencyBaseToViewModelProfile>());
            var mapper = config.CreateMapper();
            var toMap = new CurrencyDto
            {
                Currency = "bat (Tajlandia)",
                Code = "THB",
                Mid = 0.128m,
                EffectiveDate = DateTime.Parse("2022-05-10")
            };

            var mapped = mapper.Map<CurrencyDto, CurrencyViewModel>(toMap);

            Assert.Equal(mapped.Code, toMap.Code);
            Assert.Equal(mapped.Currency, toMap.Currency);
            Assert.Equal(mapped.EffectiveDate, toMap.EffectiveDate);
            Assert.Equal(mapped.Mid, toMap.Mid);
        }

        [Fact]
        public void AutoMapper_Is_Map_Correct_When_Bid_and_Ask()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CurrencyBaseToViewModelProfile>());
            var mapper = config.CreateMapper();
            var toMap = new CurrencyDto
            {
                Currency = "bat (Tajlandia)",
                Code = "THB",
                Bid = 0.128m,
                Ask = 0.1m,
                EffectiveDate = DateTime.Parse("2022-05-10")
            };

            var mapped = mapper.Map<CurrencyDto, CurrencyViewModel>(toMap);

            Assert.Equal(mapped.Code, toMap.Code);
            Assert.Equal(mapped.Currency, toMap.Currency);
            Assert.Equal(mapped.EffectiveDate, toMap.EffectiveDate);
            Assert.Equal(mapped.Mid, (toMap.Bid + toMap.Ask) / 2);
        }


    }
}

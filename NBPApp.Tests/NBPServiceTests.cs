using Moq;
using NBPApp.Models;
using NBPApp.Services;
using System.Threading.Tasks;
using Xunit;

namespace NBPApp.Tests
{
    public class NBPServiceTests
    {
        [Fact]
        public async void When_Not_Succes_Response_Do_Not_Get_Data()
        {
            var mocClient = new Mock<INBPApiClient>();
            mocClient.Setup(m => m.GetResponse(It.IsAny<string>())).Returns(Task.FromResult(new Response { IsSuccess = false }));

            var nbpService = new NBPService(mocClient.Object);

            var result = await nbpService.GetCurrenciesData();

            Assert.Empty(result);
            mocClient.Verify(x => x.GetData(It.IsAny<Response>()), Times.Never);
            mocClient.Verify(x => x.GetDataRange(It.IsAny<Response>()), Times.Never);
        }

        [Fact]
        public async void When_Succes_Response_Do_Get_Data()
        {
            var mocClient = new Mock<INBPApiClient>();
            mocClient.Setup(m => m.GetResponse(It.IsAny<string>())).Returns(Task.FromResult(new Response { IsSuccess = true }));

            var nbpService = new NBPService(mocClient.Object);

            var result = await nbpService.GetCurrenciesData();

            Assert.Empty(result);
            mocClient.Verify(x => x.GetData(It.IsAny<Response>()), Times.Exactly(2));
            mocClient.Verify(x => x.GetDataRange(It.IsAny<Response>()), Times.Once);
        }

    }
}

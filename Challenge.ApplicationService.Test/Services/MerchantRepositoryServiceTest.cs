using Challenge.ApplicationService.Services;
using Challenge.Domain.Models;
using Challenge.Domain.Repositories;
using FakeItEasy;
using FluentAssertions;
using System.Text;

namespace Challenge.ApplicationService.Test.Services
{
    [TestFixture]
    public class MerchantApplicationServiceTest
    {
        MerchantApplicationService Sut { get; set; }

        IMerchantRepository MerchantRepository { get; set; }

        [SetUp]
        public void SetUp()
        {
            MerchantRepository = A.Fake<IMerchantRepository>();
            Sut = new MerchantApplicationService(MerchantRepository);
        }

        [Test]
        public async Task ShouldGetAllMerchants()
        {
            var merchants = await Sut.GetAll();
            merchants.Should().NotBeNull();
            A.CallTo(() => MerchantRepository.GetAllAsync()).MustHaveHappened();
        }

    }
}

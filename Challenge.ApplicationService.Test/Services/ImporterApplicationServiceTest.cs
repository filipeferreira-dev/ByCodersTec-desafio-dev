using Challenge.ApplicationService.Services;
using Challenge.Domain.Models;
using Challenge.Domain.Repositories;
using FakeItEasy;
using FluentAssertions;
using System.Text;

namespace Challenge.ApplicationService.Test.Services
{
    [TestFixture]
    public class ImporterApplicationServiceTest
    {
        ImporterApplicationService Sut { get; set; }

        IMerchantRepository MerchantRepository { get; set; }

        [SetUp]
        public void SetUp()
        {
            MerchantRepository = A.Fake<IMerchantRepository>();
            Sut = new ImporterApplicationService(MerchantRepository);
        }

        [Test]
        public void ShouldNotThrowException()
        {
            _ = Sut.Invoking(s => s.ImportAsync(null)).Should().NotThrowAsync();
        }

        [Test]
        public async Task ShouldImportFileSuccessfully()
        {
            var content = "3201903010000012200845152540736777****1313172712MARCOS PEREIRAMERCADO DA AVENIDA";
            var fakeFile = new MemoryStream(Encoding.UTF8.GetBytes(content));

            await Sut.ImportAsync(fakeFile);

            A.CallTo(() => MerchantRepository.AddRangeAsync(A<IEnumerable<Merchant>>.That.Not.IsEmpty())).MustHaveHappened();
        }
    }
}

using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.SaleProject.Pages;

public class Index_Tests : SaleProjectWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MysqlDemo.Pages
{
    public class Index_Tests : MysqlDemoWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}

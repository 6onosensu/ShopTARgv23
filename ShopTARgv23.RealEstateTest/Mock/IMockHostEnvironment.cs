using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ShopTARgv23.RealEstateTest.Mock
{
    public class IMockHostEnvironment : IHostEnvironment
    {
        public string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContentRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IHostEnvironment.EnvironmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}

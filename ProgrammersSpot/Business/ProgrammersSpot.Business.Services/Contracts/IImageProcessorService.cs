using System.IO;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IImageProcessorService
    {
        MemoryStream ProcessImage(byte[] photoBytes, int width, int height, string fileFormat, int qualityPercentage);
    }
}

using Bytes2you.Validation;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using ProgrammersSpot.Business.Services.Contracts;
using System.Drawing;
using System.IO;

namespace ProgrammersSpot.Business.Services
{
    public class ImageProcessorService : IImageProcessorService
    {
        private ImageFactory imageFactory;

        public ImageProcessorService(ImageFactory imgFactory)
        {
            Guard.WhenArgument(imgFactory, "imageFactory").IsNull().Throw();
            this.imageFactory = imgFactory;
        }

        public MemoryStream ProcessImage(byte[] photoBytes, int width, int height, string fileFormat, int qualityPercentage)
        {
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                MemoryStream outStream = new MemoryStream();
                using (this.imageFactory)
                {
                    fileFormat = fileFormat.ToLower();
                    ISupportedImageFormat format = null;
                    if (fileFormat == ".jpg" || fileFormat == ".jpeg")
                    {
                        format = new JpegFormat { Quality = qualityPercentage };
                    }
                    else if (fileFormat == ".png")
                    {
                        format = new PngFormat { Quality = qualityPercentage };
                    }
                    else
                    {
                        return null;
                    }
                    
                    Size size = new Size(width, height);

                    this.imageFactory.Load(inStream)
                        .Resize(size)
                        .Format(format)
                        .Save(outStream);

                    return outStream;
                }
            }
        }
    }
}

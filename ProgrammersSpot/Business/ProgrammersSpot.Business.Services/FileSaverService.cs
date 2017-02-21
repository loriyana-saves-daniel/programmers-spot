using ProgrammersSpot.Business.Services.Contracts;
using System;
using System.IO;

namespace ProgrammersSpot.Business.Services
{
    public class FileSaverService : IFileSaverService
    {
        public string SaveFile(MemoryStream fileToSave, string dirToSaveIn, string fileName, bool shouldReplaceFile = false)
        {
            Directory.CreateDirectory(dirToSaveIn);
            string filePath = Path.Combine(dirToSaveIn, fileName);
            if (!shouldReplaceFile && File.Exists(filePath))
            {
                int indexOfExtension = fileName.LastIndexOf(Path.GetExtension(fileName));
                fileName = fileName.Insert(indexOfExtension, Guid.NewGuid().ToString());
                filePath = Path.Combine(dirToSaveIn, fileName);
            }

            using (FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write))
            {
                using (fileToSave)
                {
                    byte[] bytes = new byte[fileToSave.Length];
                    fileToSave.Read(bytes, 0, (int)fileToSave.Length);
                    file.Write(bytes, 0, bytes.Length);
                    file.Flush();
                }
            }

            return fileName;
        }
    }
}

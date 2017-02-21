using System.IO;

namespace ProgrammersSpot.Business.Services.Contracts
{
    public interface IFileSaverService
    {
        /// <summary>
        /// Writes file to disk.
        /// </summary>
        /// <returns>New file name if the passed one already exists.</returns>
        string SaveFile(MemoryStream fileToSave, string dirToSaveIn, string fileName, bool shouldReplaceFile = false);
    }
}

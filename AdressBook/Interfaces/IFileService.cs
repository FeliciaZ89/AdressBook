namespace AdressBook.Services
{
    public interface IFileService
    {
       


        /// <summary>
        /// Save content to a specificed location(filepath).
        /// </summary>
        /// <param name="filePath">Enter the filepath with extension (c:\agenda\adressbook\content.json)</param>
        /// <param name="content">Enter the content as a string</param>
        /// <returns>Returns true if saved, otherwise false</returns>
        bool SaveContentToFile(string filePath, string content);

        /// <summary>
        /// Get content (as string) from a specified filepath
        /// </summary>
        /// <param name="filePath">Enter the filepath with extension (c:\agenda\adressbook\content.json)</param>
        /// <returns>If the file exists,returns file content (as string) ,returns null if failed.</returns>
        string GetContentFromFile(string filePath);
    }
}
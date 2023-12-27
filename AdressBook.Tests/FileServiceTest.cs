

using AdressBook.Services;

namespace AdressBook.Tests;

public class FileServiceTest
{
    [Fact]
    public void SaveContentToFileShould_SaveAContactToTheFile_ThenReturnTrue()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\Agenda\AdressBook\content.json";
        string content = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(filePath, content);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetContentFromFileShould_ReturnTrue_IfTheFileExists()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\Agenda\AdressBook\content.json";
        string content = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(filePath, content);

        // Assert
        Assert.True(result);
    }
}

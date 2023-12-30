

using AdressBook.Services;

namespace AdressBook.Tests;

public class FileServiceTest
{
    [Fact]
    public void SaveContentToFileShould_SaveAContactToTheFile_ThenReturnTrue()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\Agenda\AdressBook\testcontent.txt";
        string content1 = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(filePath, content1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SaveContentToFileShould_ReturnFalse_IfFilePathDoNotExists()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\Agenda\AdressBook\Test\testcontent.txt";
        string content1 = "Test content";

        // Act
        bool result = fileService.SaveContentToFile(filePath, content1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetContentFromFileShould_ReturnFileContent_WhenFileExists()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\Agenda\AdressBook\testcontent.txt";
        string expectedContent = "Test content";

        // Create the file with test content
        File.WriteAllText(filePath, expectedContent);

        // Act
        string result = fileService.GetContentFromFile(filePath);

        // Assert
        Assert.Equal(expectedContent, result);
    }

    [Fact]
    public void GetContentFromFileShould_ReturnNull_WhenFileDoesNotExist()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"C:\Agenda\AdressBook\Test\testcontent.txt";

        // Act
        string result = fileService.GetContentFromFile(filePath);

        // Assert
        Assert.Null(result);
    }

}

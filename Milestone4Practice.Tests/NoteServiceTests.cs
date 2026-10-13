using Xunit;

namespace Milestone4Practice.Tests;
// using Milestone4Practice;

public class NoteServiceTests
{
    [Fact]
    public async Task SaveNoteAsync_ReturnsTask()
    {
        // arrange
        NoteService noteService = new();
        
        // act
        await noteService.SaveNoteAsync("place.txt", "hello friend");
        string note = await noteService.LoadNoteAsync("place.txt");
        
        
        // 
        Assert.Equal("hello friend", note);
    }

    [Fact]
    public async Task NoteExists_ReturnsTrue_AfterFileIsCreated()
    {
        // arrange
        NoteService noteService = new();
        string path = "exists-test.txt";

        await noteService.SaveNoteAsync(path, "hello");
        
        // act
        bool result = noteService.NoteExists(path);
        
        // assert
        Assert.True(result);
        
        // cleanup
        File.Delete(path);

    }

    [Fact]
    public async Task AppendNoteAsync_AppendsNewLine()
    {
        // arrange
        NoteService noteService = new();
        string path = "append-test.txt";
        
        await noteService.SaveNoteAsync(path, "hello friend");
        
        // act

        await noteService.AppendNoteAsync(path, "this is a new line friend");
        
        
        string[] notes = await File.ReadAllLinesAsync(path);

        Assert.Equal(2, notes.Length);
        Assert.Equal("hello friend", notes[0]);
        Assert.Equal("this is a new line friend", notes[1]);
        
        // cleanup
        File.Delete(path);
    }
    
    // note; rule
    // arrange everything that a test needs inside that test. don't depend
    // on another test running first.

    [Fact]
    public async Task LoadNoteAsync_From_NonExistentFile_Throws()
    {
        NoteService noteService = new();
        await Assert.ThrowsAsync<FileNotFoundException>(async () =>
        {
            await noteService.LoadNoteAsync("no_path.txt");
        });

    }
    
}
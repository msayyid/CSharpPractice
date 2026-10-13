namespace Milestone4Practice;

public class NoteService
{
    // save and load simple notes from a file


    public async Task SaveNoteAsync(string path, string note)
    {
        await File.WriteAllTextAsync(path, note);
    }

    public async Task<string> LoadNoteAsync(string path)
    {
        string note = await File.ReadAllTextAsync(path);
        return note;
    }

    public bool NoteExists(string path)
    {
        return File.Exists(path);
    }

    public async Task AppendNoteAsync(string path, string note)
    {
        await File.AppendAllTextAsync(path, $"\n{note}");
    }
}
namespace GreatIdeas.MailServices;

public record FileToAttach(string FileName, int FileSize, byte[] Bytes, string FilePath);

namespace GreatIdeas.MailServices;

public record EmailModel(string To, string FromAddress, string FromName, string Subject, string Body);

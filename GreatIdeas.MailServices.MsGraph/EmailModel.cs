namespace GreatIdeas.MailServices.MsGraph;

public record EmailModel(string FromAddress, string To, string FromName, string Subject, string Body);

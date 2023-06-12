namespace ParanaBanco.TesteBackend.Domain.Exceptions;

public class EntryNotFoundException : Exception
{
    public EntryNotFoundException(string error) : base(error) { }
}
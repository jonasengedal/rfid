namespace Inc.SharedKernel.Interfaces;
public class NotFoundException(string message) : Exception(message)
{
}

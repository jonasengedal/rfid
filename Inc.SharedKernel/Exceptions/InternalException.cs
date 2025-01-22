namespace Inc.SharedKernel.Exceptions;

public class InternalException(string? message, Exception? e) : Exception(message, e){}

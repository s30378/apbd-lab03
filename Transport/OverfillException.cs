﻿namespace Transport;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) {}
}
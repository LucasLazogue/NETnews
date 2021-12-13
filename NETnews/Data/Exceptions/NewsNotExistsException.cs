using System;

public class NewsNotExistsException : Exception {
    public NewsNotExistsException() {
    }

    public NewsNotExistsException(string message)
        : base(message) {
    }

    public NewsNotExistsException(string message, Exception inner)
        : base(message, inner) {
    }
}
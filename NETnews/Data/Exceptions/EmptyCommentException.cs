using System;

public class EmptyCommentException : Exception {
    public EmptyCommentException() {
    }

    public EmptyCommentException(string message)
        : base(message) {
    }

    public EmptyCommentException(string message, Exception inner)
        : base(message, inner) {
    }
}

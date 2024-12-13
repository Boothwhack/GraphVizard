namespace GraphVizard;

public class GraphVizardException(string? message) : Exception(message);

/** Represents an error caused by an inconsistent internal state. Should never occur within normal usage. */
public class IllegalStateException(string message) : GraphVizardException(message);
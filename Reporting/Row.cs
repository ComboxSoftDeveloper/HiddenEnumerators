namespace HiddenEnumerators.Reporting;

/// <summary>
/// Плоская строка результата: один бенчмарк-кейс на одном рантайме.
/// </summary>
public sealed record Row(
    string ClassName,
    string Method,
    string Runtime,
    string Parameters,
    double MeanNs,
    long AllocatedBytes);

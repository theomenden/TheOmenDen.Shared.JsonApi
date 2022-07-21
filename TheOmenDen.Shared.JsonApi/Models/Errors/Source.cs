namespace TheOmenDen.Shared.JsonApi.Models.Errors;
/// <summary>
/// Container with information relevant to the source of a particular <see cref="Error"/>
/// </summary>
/// <param name="Pointer">The reference to a specific failure point - typically the data object or attribute</param
/// <param name="Parameter">A particular parameter used when the error was flagged</param>
/// <param name="Header">The name of a single request header which caused the error</param>
public sealed record Source(String Pointer, String Parameter, String Header);
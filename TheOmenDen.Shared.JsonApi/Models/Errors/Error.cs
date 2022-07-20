namespace TheOmenDen.Shared.JsonApi.Models.Errors;

/// <summary>
/// Container for an Error Object
/// </summary>
/// <param name="ReferenceId">The unique Id</param>
/// <param name="Source">The source of the error</param>
/// <param name="Code">The status code for the error</param>
/// <param name="Title">A short summary of the problem</param>
/// <param name="Detail">An explanation of the problem</param>
/// <param name="Links">An array of <see cref="Link"/>s offering more details for the particular error</param>
public record Error(Guid ReferenceId, Source Source, Int32 Code, String Title, String Detail, Link[] Links);

namespace Requirements_Management_Infrastructure.Data.Models.Enums
{
    public enum RequirementsDependancyScale
    {
        CompleteIncompatibility = -4,
        HighIncompatibility = -3,
        AverageIncompatibility = -2,
        LowIncompatibility = -1,
        Independent = 0, // this would never be used, since there won't be an entity in <RequirementsDependancy> that uses it
        LowOverlap = 1,
        MediumOverlap = 2,
        MostlyOverlapping = 3,
        CompletelyOverlapping = 4
    }
}

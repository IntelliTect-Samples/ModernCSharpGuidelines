// GUIDELINE
// 👍 DO use file scoped namespace declarations
namespace ModernCSharpGuidelines;

public class FinglePrintTests
{
    // REMINDER
    public record class FingerPrint(string CreatedBy, string? ModifiedBy = null);

    [Fact]
    public void FingerPrintCreatedByCouldBeNull()
    {
        Assert.Null(new FingerPrint(null!).CreatedBy);
        Assert.Null(new FingerPrint(null!) { CreatedBy = null!}.CreatedBy);

        // Init properties cannot be assigned afer construction
        // FingerPrint fingerPrint = new (null!);
        // fingerPrint.CreatedBy = null!;
    }

    // REMINDER
    public record struct FingerPrintData(string CreatedBy, string? ModifiedBy = null);

    [Fact]
    public void FingerPrintDataCreatedByCouldBeNull()
    {
        Assert.Null(new FingerPrintData(null!).CreatedBy);
        Assert.Null(new FingerPrintData(null!) { CreatedBy = null! }.CreatedBy);

        // Init properties cannot be assigned afer construction
        FingerPrintData fingerPrint = new (null!);
        fingerPrint.CreatedBy = null!;
    }


    // GUIDELINE     
    // 👍 CONSIDER defining record structs with readonly
    //        (See Why C# Tuples Get to Break the Guidelines at https://bit.ly/3oHIu59)

    // GUIDELINE
    // ⛔ AVOID positional parameters when validation of properties is required

    // GUIDELINE
    // 👍 DO use record structs (rather than a plain struct) when defining a struct
    readonly public record struct FinglePrint
    {
        // GUIDELINE
        // DO use a nullable backing field and return it in the getter with a 
        // null-forgiveness operator in a non-nullable reference type property
        readonly private string? _CreatedBy = null;
        public string CreatedBy
        {
            get { return _CreatedBy!; }
            // GUIDELINE
            // DO check for null in the setter of a non-nullable property
            init
            {
                // GUIDELINE
                // CONSIDER using System.ArgumentNullException.ThrowIfNull()
                //      to validate non-nullable parameters.

                // ArgumentNullException.ThrowIfNull(value) less
                // efficient for null, empty, or whitespace validation.
                Guard.ThrowIfNullEmptyOrWhitespace(value);
                _CreatedBy = value;
            }
        }

        public string? ModifiedBy { get; init; } = null;

        public FinglePrint(string createdBy, string? modifiedBy = null)
        {
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
        }

        // GUIDELINE
        // ⚖ DO declare struct methods as readonly
        readonly public override string ToString() =>
            ModifiedBy is null ? $"Created by { CreatedBy }." :
                $"Created by { CreatedBy }. and modified by { ModifiedBy }";
    }

    [Fact]
    public void Create()
    {
        // GUIDELINE
        // ⚖ DO favor target type new over var when invoking constructors
        FinglePrint _ = new("Inygo");
    }

    private static FinglePrint CreateFinglePrint(
            string createdBy = "Inygo",
            string? modifiedBy = "Humperdink"
        ) => new(createdBy)
        {
            ModifiedBy = modifiedBy
        };

    [Fact]
    public void UpdateProperties()
    {
        FinglePrint? finglePrint = CreateFinglePrint();
        //finglePrint.CreatedBy = "Kevin";
        //finglePrint.ModifiedBy = "Humperdink";
        
        Assert.NotNull(finglePrint.Value.CreatedBy);
    }

    [Fact]
    public void CloneRecord()
    {
        FinglePrint finglePrint = CreateFinglePrint();

        FinglePrint clone = finglePrint with { ModifiedBy = "Buttercup" };

        Assert.Equal("Buttercup", clone.ModifiedBy);
    }
}


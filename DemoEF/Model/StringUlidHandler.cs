using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoEF.Model
{
    public class StringUlidHandler : ValueConverter<Ulid, string>
    {
        private static readonly ConverterMappingHints defaultHints = new ConverterMappingHints(size: 26);

        public StringUlidHandler(ConverterMappingHints mappingHints = null)
            : base(
                    convertToProviderExpression: x => x.ToString(),
                    convertFromProviderExpression: x => Ulid.Parse(x),
                    mappingHints: defaultHints.With(mappingHints))
        {
        }
    }
}

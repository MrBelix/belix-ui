using System.Text;

namespace Belix.UI.Utilities;

public readonly record struct ClassBuilder
{
    private const char Separator = ' ';
    private readonly StringBuilder _stringBuilder;

    public ClassBuilder()
    {
        _stringBuilder = new StringBuilder();
    }

    public ClassBuilder AddClass(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            if (_stringBuilder.Length > 0)
            {
                _stringBuilder.Append(Separator);
            }
            _stringBuilder.Append(value.Trim());
        }

        return this;
    }

    public ClassBuilder AddClass(string value, bool condition) => condition
        ? AddClass(value)
        : this;

    public string Build()
    {
        return _stringBuilder.ToString();
    }

    public override string ToString() => Build();
}
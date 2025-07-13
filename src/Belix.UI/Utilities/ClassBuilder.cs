using System.Text;

namespace Belix.UI.Utilities
{
    /// <summary>
    /// Fluent CSS class builder using StringBuilder, safe for struct initialization.
    /// </summary>
    public readonly record struct ClassBuilder
    {
        private const char Separator = ' ';
        private readonly StringBuilder _stringBuilder;

        /// <summary>
        /// Creates an empty builder.
        /// </summary>
        public ClassBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        /// <summary>
        /// Creates a builder initialized with a starting value.
        /// </summary>
        public ClassBuilder(string? initial) : this()
        {
            if (!string.IsNullOrWhiteSpace(initial))
            {
                AddClass(initial);
            }
        }

        /// <summary>
        /// Appends a class name if non-empty, prefixing a separator if needed.
        /// </summary>
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

        /// <summary>
        /// Conditionally appends a class name.
        /// </summary>
        public ClassBuilder AddClass(string value, bool condition)
            => condition ? AddClass(value) : this;

        /// <summary>
        /// Returns the combined class string.
        /// </summary>
        public string Build() => _stringBuilder?.ToString() ?? string.Empty;

        public override string ToString() => Build();
    }
}
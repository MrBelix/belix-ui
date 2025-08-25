using Belix.UI.Utilities;

namespace Belix.UI.Components.Theming;

public sealed record ThemeColor(
    Color Color,
    Color OnColor,
    Color ContainerColor,
    Color OnContainerColor);
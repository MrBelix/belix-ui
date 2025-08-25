using Microsoft.AspNetCore.Components;

namespace Belix.UI.Components.Theming;

public partial class ThemeProvider : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public required ThemeContext Context { get; set; }
}
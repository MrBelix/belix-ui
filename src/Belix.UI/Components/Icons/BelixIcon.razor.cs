using Belix.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Belix.UI.Components.Icons;

public partial class BelixIcon : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public IconName Name { get; set; }

    [Parameter]
    public bool Filled { get; set; }

    private string IconName => Name.ToString();

    private string CssClassName => new ClassBuilder("belix-icon")
        .AddClass("belix-icon-filled", Filled)
        .Build();
}
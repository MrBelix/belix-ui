using BelixUI.Enums;
using Microsoft.AspNetCore.Components;

namespace BelixUI.Components.Button;

public partial class BelixButton : ComponentBase
{
    [Parameter]
    [EditorRequired]
    public string Text { get; set; } = string.Empty;

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public ButtonVariant Variant { get; set; } = ButtonVariant.Filled;

    [Parameter]
    public Color Color { get; set; } = Color.Primary;

    [Parameter]
    public Size Size { get; set; } = Size.Medium;

    private string CssClasses => $"belix-button {Enum.GetName(typeof(ButtonVariant), Variant).ToLowerInvariant()} {Enum.GetName(typeof(Size), Size).ToLowerInvariant()} {Enum.GetName(typeof(Color), Color).ToLowerInvariant()}";
}
using System.Globalization;

namespace Belix.UI.Utilities;

public readonly record struct Color
{
    private readonly byte _r = 0;
    private readonly byte _g = 0;
    private readonly byte _b = 0;
    private readonly byte _a = 0;
    
    private bool IsOpaque => _a == 255;
    
    private bool IsTransparent => _a == 0;
    
    private double Af => _a / 255.0;

    public Color(byte r, byte g, byte b)
    {
        _r = r;
        _g = g;
        _b = b;
    }

    public Color(byte r, byte g, byte b, byte a)
    {
        _r = r;
        _g = g;
        _b = b;
        _a = a;
    }
    
    public string ToHex(bool includeAlpha = false)
    {
        if (!includeAlpha || IsOpaque)
            return string.Create(7, this, (span, c) => HexWriteRgb(span, c._r, c._g, c._b));
        return string.Create(9, this, (span, c) => HexWriteRgba(span, c._r, c._g, c._b, c._a));
    }
    
    public string ToCssRgb() => IsOpaque
        ? $"rgb({_r}, {_g}, {_b})"
        : $"rgba({_r}, {_g}, {_b}, {Af.ToString(CultureInfo.InvariantCulture)})";
    
    private static void HexWriteRgb(Span<char> dest, byte r, byte g, byte b)
    {
        dest[0] = '#';
        ByteToHex(r, dest.Slice(1));
        ByteToHex(g, dest.Slice(3));
        ByteToHex(b, dest.Slice(5));
    }
    private static void HexWriteRgba(Span<char> dest, byte r, byte g, byte b, byte a)
    {
        HexWriteRgb(dest, r, g, b);
        ByteToHex(a, dest.Slice(7));
    }
    
    private static void ByteToHex(byte value, Span<char> dest)
    {
        const string hex = "0123456789abcdef";
        dest[0] = hex[(value >> 4) & 0xF];
        dest[1] = hex[value & 0xF];
    }
}
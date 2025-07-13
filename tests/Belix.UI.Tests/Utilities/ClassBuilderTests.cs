using Belix.UI.Utilities;
using JetBrains.Annotations;

namespace Belix.UI.Tests.Utilities;

[TestSubject(typeof(ClassBuilder))]
public class ClassBuilderTests
{
    [Fact]
    public void Build_EmptyBuilder_ReturnsEmptyString()
    {
        var builder = new ClassBuilder();
        Assert.Equal(string.Empty, builder.Build());
    }

    [Fact]
    public void AddClass_SingleValue_AppendsValue()
    {
        var builder = new ClassBuilder();
        var result = builder.AddClass("btn").Build();
        Assert.Equal("btn", result);
    }

    [Fact]
    public void AddClass_MultipleValues_SeparatedBySpace()
    {
        var builder = new ClassBuilder();
        var result = builder
            .AddClass("btn")
            .AddClass("active")
            .Build();

        Assert.Equal("btn active", result);
    }

    [Theory]
    [InlineData(true, "btn")]
    [InlineData(false, "")]
    public void AddClass_WithCondition_AddsOnlyWhenTrue(bool condition, string expected)
    {
        var builder = new ClassBuilder();
        var result = builder.AddClass("btn", condition).Build();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsSameAsBuild()
    {
        var builder = new ClassBuilder().AddClass("foo");
        Assert.Equal(builder.Build(), builder.ToString());
    }

    [Fact]
    public void Chaining_OnStruct_ShowsMutableUnderlyingBuilder()
    {
        // Since ClassBuilder is a record struct holding a single StringBuilder instance,
        // chaining will mutate that same instance under the covers.
        var builder1 = new ClassBuilder();
        var builder2 = builder1.AddClass("a");
        var builder3 = builder2.AddClass("b");

        // All three share the same internal SB, so:
        Assert.Equal("a b", builder1.Build());
        Assert.Equal("a b", builder2.Build());
        Assert.Equal("a b", builder3.Build());
    }
}
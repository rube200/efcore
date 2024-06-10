// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.CodeDom.Compiler;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Microsoft.VisualStudio.TextTemplating;
using Engine = Mono.TextTemplating.TemplatingEngine;

namespace Microsoft.EntityFrameworkCore.Scaffolding.Internal;

[PlatformSkipCondition(TestUtilities.Xunit.TestPlatform.Linux | TestUtilities.Xunit.TestPlatform.Mac, SkipReason = "CI time out")]
public class TextTemplatingEngineHostTest
{
    public static readonly Engine _engine = new();

    [ConditionalFact]
    public async Task Service_works()
    {
        var host = new TextTemplatingEngineHost(
            new ServiceCollection()
                .AddSingleton("Hello, Services!")
                .BuildServiceProvider());

        var result = await _engine.ProcessTemplateAsync(
            @"<#@ template hostSpecific=""true"" #><#= ((IServiceProvider)Host).GetService(typeof(string)) #>",
            host);

        Assert.Empty(host.Errors);
        Assert.Equal("Hello, Services!", result);
    }

    [ConditionalFact]
    public async Task Session_works()
    {
        var host = new TextTemplatingEngineHost { Session = new TextTemplatingSession { ["Value"] = "Hello, Session!" } };

        var result = await _engine.ProcessTemplateAsync(
            @"<#= Session[""Value""] #>",
            host);

        Assert.Empty(host.Errors);
        Assert.Equal("Hello, Session!", result);
    }

    [ConditionalFact]
    public async Task Session_works_with_parameter()
    {
        var host = new TextTemplatingEngineHost { Session = new TextTemplatingSession { ["Value"] = "Hello, Session!" } };

        var result = await _engine.ProcessTemplateAsync(
            @"<#@ parameter name=""Value"" type=""System.String"" #><#= Value #>",
            host);

        Assert.Empty(host.Errors);
        Assert.Equal("Hello, Session!", result);
    }

    [ConditionalFact]
    public async Task Include_works()
    {
        using var dir = new TempDirectory();
        File.WriteAllText(
            Path.Combine(dir, "test.ttinclude"),
            "Hello, Include!");

        var host = new TextTemplatingEngineHost { TemplateFile = Path.Combine(dir, "test.tt") };

        var result = await _engine.ProcessTemplateAsync(
            @"<#@ include file=""test.ttinclude"" #>",
            host);

        Assert.Empty(host.Errors);
        Assert.Equal("Hello, Include!", result);
    }

    [ConditionalFact]
    public void Error_works()
    {
        var host = new TextTemplatingEngineHost();

        _engine.ProcessTemplateAsync(
            @"<# Error(""Hello, Error!""); #>",
            host);

        var error = Assert.Single(host.Errors.Cast<CompilerError>());
        Assert.Equal("Hello, Error!", error.ErrorText);
    }

    [ConditionalFact]
    public async Task Directive_throws_when_processor_unknown()
    {
        var host = new TextTemplatingEngineHost();

        var ex = await Assert.ThrowsAsync<FileNotFoundException>(
            () => _engine.ProcessTemplateAsync(
                @"<#@ test processor=""TestDirectiveProcessor"" #>",
                host));

        Assert.Equal(DesignStrings.UnknownDirectiveProcessor("TestDirectiveProcessor"), ex.Message);
    }

    [ConditionalFact]
    public async Task ResolvePath_work()
    {
        using var dir = new TempDirectory();

        var host = new TextTemplatingEngineHost { TemplateFile = Path.Combine(dir, "test.tt") };

        var result = await _engine.ProcessTemplateAsync(
            @"<#@ template hostSpecific=""true"" #><#= Host.ResolvePath(""data.json"") #>",
            host);

        Assert.Empty(host.Errors);
        Assert.Equal(Path.Combine(dir, "data.json"), result);
    }

    [ConditionalFact]
    public void Output_works()
    {
        var host = new TextTemplatingEngineHost();

        _engine.ProcessTemplateAsync(
            @"<#@ output extension="".txt"" encoding=""us-ascii"" #>",
            host);

        Assert.Empty(host.Errors);
        Assert.Equal(".txt", host.Extension);
        Assert.Equal(Encoding.ASCII, host.OutputEncoding);
    }

    [ConditionalFact]
    public async Task Assembly_works()
    {
        var host = new TextTemplatingEngineHost();

        var result = await _engine.ProcessTemplateAsync(
            @"<#@ assembly name=""Microsoft.EntityFrameworkCore"" #><#= nameof(Microsoft.EntityFrameworkCore.DbContext) #>",
            host);

        Assert.Empty(host.Errors);
        Assert.Equal("DbContext", result);
    }
}

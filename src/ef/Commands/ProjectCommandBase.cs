// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Reflection;
using Microsoft.DotNet.Cli.CommandLine;
using Microsoft.EntityFrameworkCore.Tools.Properties;

namespace Microsoft.EntityFrameworkCore.Tools.Commands
{
    internal abstract class ProjectCommandBase : EFCommandBase
    {
        private CommandOption? _dataDir;
        private CommandOption? _projectDir;
        private CommandOption? _rootNamespace;
        private CommandOption? _language;
        private CommandOption? _nullable;
        private string? _efcoreVersion;

        protected CommandOption? Assembly { get; private set; }
        protected CommandOption? Project { get; private set; }
        protected CommandOption? StartupAssembly { get; private set; }
        protected CommandOption? StartupProject { get; private set; }
        protected CommandOption? WorkingDir { get; private set; }
        protected CommandOption? Framework { get; private set; }
        protected CommandOption? Configuration { get; private set; }

        protected string? EFCoreVersion
            => _efcoreVersion ??= System.Reflection.Assembly.Load("Microsoft.EntityFrameworkCore.Design")
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

        public override void Configure(CommandLineApplication command)
        {
            command.AllowArgumentSeparator = true;

            Assembly = command.Option("-a|--assembly <PATH>", Resources.AssemblyDescription);
            Project = command.Option("--project <PATH>", Resources.ProjectDescription);
            StartupAssembly = command.Option("-s|--startup-assembly <PATH>", Resources.StartupAssemblyDescription);
            StartupProject = command.Option("--startup-project <PATH>", Resources.StartupProjectDescription);
            _dataDir = command.Option("--data-dir <PATH>", Resources.DataDirDescription);
            _projectDir = command.Option("--project-dir <PATH>", Resources.ProjectDirDescription);
            _rootNamespace = command.Option("--root-namespace <NAMESPACE>", Resources.RootNamespaceDescription);
            _language = command.Option("--language <LANGUAGE>", Resources.LanguageDescription);
            _nullable = command.Option("--nullable", Resources.NullableDescription);
            WorkingDir = command.Option("--working-dir <PATH>", Resources.WorkingDirDescription);
            Framework = command.Option("--framework <FRAMEWORK>", Resources.FrameworkDescription);
            Configuration = command.Option("--configuration <CONFIGURATION>", Resources.ConfigurationDescription);

            base.Configure(command);
        }

        protected override void Validate()
        {
            base.Validate();

            if (!Assembly!.HasValue())
            {
                throw new CommandException(Resources.MissingOption(Assembly.LongName));
            }
        }

        protected IOperationExecutor CreateExecutor(string[] remainingArguments)
        {
            try
            {
                return new ReflectionOperationExecutor(
                    Assembly!.Value()!,
                    StartupAssembly!.Value(),
                    _projectDir!.Value(),
                    _dataDir!.Value(),
                    _rootNamespace!.Value(),
                    _language!.Value(),
                    _nullable!.HasValue(),
                    remainingArguments);
            }
            catch (FileNotFoundException ex)
                when (ex.FileName != null
                      && new AssemblyName(ex.FileName).Name == OperationExecutorBase.DesignAssemblyName)
            {
                throw new CommandException(
                    Resources.DesignNotFound(
                        Path.GetFileNameWithoutExtension(
                            StartupAssembly!.HasValue() ? StartupAssembly.Value() : Assembly!.Value())),
                    ex);
            }
        }
    }
}

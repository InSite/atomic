﻿using Atom.Common;

using Spectre.Console.Cli;

public class GenerationCommand : Command<GenerationSettings>
{
    public override int Execute(CommandContext context, GenerationSettings settings)
    {
        for (var i = 0; i < settings.Count; i++)
            Console.WriteLine(GuidFactory.Create());
        
        return 0;
    }
}

public class GenerationSettings : CommandSettings
{
    [CommandOption("--count")]
    public int? Count { get; set; }
}
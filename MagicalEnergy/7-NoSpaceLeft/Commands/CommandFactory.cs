using System.Collections.Immutable;
using Utils.Extensions;

namespace _7_NoSpaceLeft.Commands;

internal class CommandFactory
{
    private readonly IImmutableDictionary<string, Type> _commandTypes;

    public CommandFactory()
    {
        var commandType = typeof(ICommand);
        var commandTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(type => commandType.IsAssignableFrom(type))
            .Where(type => !type.IsInterface)
            .Where(type => !type.IsAbstract);

        _commandTypes = commandTypes
            .Select(Activator.CreateInstance)
            .Where(instance => instance is not null)
            .Select(instance => (ICommand)instance!)
            .ToImmutableDictionary(command => command.Input, command => command.GetType());
    }

    public ICommand? CreateCommand(string input)
    {
        if (input.IsNullOrWhiteSpace()) return null;

        string[] parsed = input.Split(' ').Where(p => p != "$").ToArray();

        if (!_commandTypes.TryGetValue(parsed[0], out var type)) return null;

        var command = (ICommand)Activator.CreateInstance(type)!;

        foreach (var parameter in parsed[1..])
        {
            command.Parameters.Add(parameter);
        }

        return command;
    }
}

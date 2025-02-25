using System.Text;

namespace BakasaCommon.Commands
{
    public class CommandBuilder
    {
        private StringBuilder _command;

        public CommandBuilder(string commandName)
        {
            _command = new StringBuilder();
            _command.Append(commandName);
            _command.Append("(");
        }

        public CommandBuilder AddParameter(string param)
        {
            if (_command.Length > 1 && _command[_command.Length - 1] != '(')
            {
                _command.Append(", ");
            }
            _command.Append($"\"{param}\"");
            return this;
        }

        public string Build()
        {
            _command.Append(")");
            return _command.ToString();
        }
    }
}

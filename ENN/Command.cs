using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENN.Runtime
{
    enum CommandType
    {
        Exit, Load, Run, Update, Save, Status, Help, Bad, Command, App
    }

    class Command
    {
        public CommandType BaseType { get; set; }
        public List<RawCommand> RawCommands { get; set; }
    }
}

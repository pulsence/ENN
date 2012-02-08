/*This file is part of ENN.
* Copyright (C) 2012  Tim Eck II
* 
* ENN is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as
* published by the Free Software Foundation, version 3 of the License.
* 
* ENN is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Lesser General Public License for more details.
* 
* You should have received a copy of the GNU Lesser General Public License
* along with ENN.  If not, see <http://www.gnu.org/licenses/>.*/

using System.Collections.Generic;

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

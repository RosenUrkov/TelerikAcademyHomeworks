using System;
using System.Collections.Generic;
using WarMachines.Engine;
using WarMachines.Interfaces;

namespace WarMachines.Tests.Engine.Mocks
{
    internal class CommandParserMock : CommandParser
    {
        public CommandParserMock(IReader reader):base(reader)
        {
                
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
        }
    }
}

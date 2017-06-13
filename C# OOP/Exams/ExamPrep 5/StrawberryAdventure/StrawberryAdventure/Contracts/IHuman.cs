using StrawberryAdventure.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace StrawberryAdventure.Contracts
{
    public interface IHuman : ICharacter
    {
        ICollection<IItem> Items { get; }

        void AddItem(IItem item);       
    }
}
namespace TradeAndTravel
{
    using System;
    using System.Linq;
    public class InteractionManagerExtended : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            var itemName = commandWords[2];
            if (actor != null)
            {
                if ((actor.Location.LocationType == LocationType.Mine)
                    && (actor.ListInventory().Any(x => x.ItemType == ItemType.Armor)))
                {
                    this.AddToPerson(actor, new Iron(itemName));
                }
                if ((actor.Location.LocationType == LocationType.Forest)
                    && (actor.ListInventory().Any(x => x.ItemType == ItemType.Weapon)))
                {
                    this.AddToPerson(actor, new Wood(itemName));
                }
            }
            foreach (var item in actor.ListInventory())
            {
                item.UpdateWithInteraction("gather");
            }

        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            var itemName = commandWords[3];
            if (actor != null)
            {
                var nessesaryItems = commandWords[2] == "weapon" ? Weapon.GetComposingItems() : Armor.GetComposingItems();
                if ((actor.ListInventory().Any(x => x.ItemType == nessesaryItems[0])) && (nessesaryItems.Count == 1))
                {
                    this.AddToPerson(actor, new Armor(itemName));                    
                                     
                }
                else if ((actor.ListInventory().Any(x => x.ItemType == nessesaryItems[0]))
                    && (actor.ListInventory().Any(x => x.ItemType == nessesaryItems[1]))) 
                {
                    this.AddToPerson(actor, new Weapon(itemName));
                }
            }
            foreach (var item in actor.ListInventory())
            {
                item.UpdateWithInteraction("craft");
            }

        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;                
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;            
        }

                
    }
}

namespace StrawberryAdventure.Utils
{
    using System;
   public  class InvalidGameValueException:ApplicationException
    {
        public InvalidGameValueException(string message, int min=Constants.MinIntGameValue, int max=Constants.MaxIntGameValue)
            :base(message)
        {
            this.Min = min;
            this.Max = max;
        }

        public int Min { get;private set; }
        public int Max { get;private set; }
    }
}

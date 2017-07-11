namespace HashSet
{
    public class LinkedNode<T>
    {
        public LinkedNode(T value, LinkedNode<T> next)
        {
            this.Value = value;
            this.Next = next;
        }

        public T Value { get; set; }

        public LinkedNode<T> Next { get; set; }

        public bool Contains(T value)
        {
            if(this.Value.Equals(value))
            {
                return true;
            }

            if(this.Next is null)
            {
                return false;
            }

            return this.Next.Contains(value);
        }
    }
}

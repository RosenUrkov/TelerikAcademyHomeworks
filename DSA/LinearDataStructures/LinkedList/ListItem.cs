namespace LinkedList
{
    public class ListItem<T>
    {
        public ListItem(T value, ListItem<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }

        public T Value { get; set; }

        public ListItem<T> Next { get; set; }
    }
}

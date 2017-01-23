namespace StringBuilder.Substring
{
    using System.Text;
    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder builder, int index, int length)
        {
            var subBuilder = new StringBuilder();
            string strBuilder = builder.ToString();

            //easy way            
            //subBuilder.Append(strBuilder.Substring(index, length));
            //return subBuilder;

            //hard way
            int counter = 0;
            while (counter<length)
            {
                subBuilder.Append(strBuilder[index + counter]);
                counter++;
            }
            return subBuilder;
        }
    }
}

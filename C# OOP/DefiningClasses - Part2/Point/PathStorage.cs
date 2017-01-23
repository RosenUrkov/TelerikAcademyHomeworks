namespace Structure
{
    using System.IO;
    using System.Text;

    public static class PathStorage
    {
        private static string path = @"../../pathStorage.txt";

        public static void SavePath(Path points)
        {
            using(var writer = new StreamWriter(path,true))
            {               
                writer.WriteLine(string.Join("  ",points.Points));                               
            }
        }

        public static string LoadPath()
        {
            var builder = new StringBuilder();
            using (var reader = new StreamReader(path))
            {                
                while (!reader.EndOfStream)
                {
                    builder.AppendLine(reader.ReadLine());
                    builder.AppendLine();
                }               
            }
            return builder.ToString().TrimEnd();
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

    public class Element : IElement
    {
        private ICollection<IElement> childElements;

        public Element(string name)
        {
            this.childElements = new List<IElement>();
            this.Name = name;
        }

        public Element(string name, string content) :this(name)
        {
            this.TextContent = content; 
        }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return new List<IElement>(this.childElements);
            }
        }

        public string Name { get; private set; }

        public string TextContent { get; set; }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }            

            if (!string.IsNullOrEmpty(this.TextContent))
            {
                output.Append(this.TextContent.Replace("&","&amp;").Replace("<","&lt;").Replace(">","&gt;"));
            }

            foreach (var element in childElements)
            {
                element.Render(output);
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            this.Render(builder);

            return builder.ToString().Trim();
        }
    }

    public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public class Table : Element, ITable, IElement
    {
        private IElement[,] indexer;

        public Table(int rows, int cols):base("table",null)
        {
            this.Rows = rows;
            this.Cols = cols;
            indexer = new Element[rows,cols];
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.indexer[row, col];
            }

            set
            {
                this.indexer[row, col] = value;
            }
        }

        public int Cols { get; private set; }

        public int Rows { get; private set; }

        public override void Render(StringBuilder output)
        {
            output.Append($"<{this.Name}>");

            for (int i = 0; i < this.indexer.GetLength(0); i++)
            {
                output.Append("<tr>");

                for (int j = 0; j < this.indexer.GetLength(1); j++)
                {
                    output.Append("<td>");

                    output.Append(indexer[i, j].ToString());

                    output.Append("</td>");
                }

                output.Append("</tr>");
            }

            output.Append($"</{this.Name}>");

        }
    }

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
            return new Element(name);
		}

		public IElement CreateElement(string name, string content)
		{
            return new Element(name, content);
		}

		public ITable CreateTable(int rows, int cols)
		{
            return new Table(rows, cols);
		}
	}

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}

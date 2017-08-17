using System;
using System.Collections.Generic;

namespace AhoCorasick
{
    public class Trie
    {
        private Dictionary<char, Trie> children;
        private string pattern;
        private Trie failLink;
        private Trie succesLink;

        public Trie()
        {
            this.children = new Dictionary<char, Trie>();
            this.pattern = null;
            this.failLink = null;
            this.succesLink = null;
        }

        public void AddString(string str)
        {
            var currentNode = this;
            foreach (var c in str)
            {
                if (!currentNode.children.ContainsKey(c))
                {
                    currentNode.children[c] = new Trie();
                }

                currentNode = currentNode.children[c];
            }

            currentNode.pattern = str;
        }

        public void Precompute()
        {
            var q = new Queue<Trie>();
            q.Enqueue(this);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                var successNode = node.failLink;
                while (successNode != null && successNode.pattern == null)
                {
                    successNode = successNode.failLink;
                }
                node.succesLink = successNode;

                foreach (var child in node.children)
                {
                    var failNode = node.failLink;
                    while (failNode != null && !failNode.children.ContainsKey(child.Key))
                    {
                        failNode = failNode.failLink;
                    }

                    child.Value.failLink = failNode == null
                        ? this
                        : failNode.children[child.Key];

                    q.Enqueue(child.Value);
                }
            }
        }

        public void AhoCorasick(string text)
        {
            var currentNode = this;
            for (int i = 0; i < text.Length; i++)
            {
                while (currentNode != null && !currentNode.children.ContainsKey(text[i]))
                {
                    currentNode = currentNode.failLink;
                }

                currentNode = currentNode == null
                    ? this
                    : currentNode.children[text[i]];

                if (currentNode.pattern != null)
                {
                    PrintMatch(i + 1 - currentNode.pattern.Length, currentNode.pattern);
                }
                var successNode = currentNode.succesLink;
                while (successNode != null)
                {
                    PrintMatch(i + 1 - successNode.pattern.Length, successNode.pattern);
                    successNode = successNode.succesLink;
                }
            }
        }

        public static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; ++i)
            {
                Console.Write(" ");
            }

            Console.WriteLine(pattern);
        }

        //public void Dfs()
        //{
        //    this.Dfs("");
        //}

        //private void Dfs(string str)
        //{
        //    if (this.failLink == null)
        //    {
        //        Console.WriteLine("root -> null");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{str} -> {this.failLink.PrintMe()}");
        //    }
        //    foreach (var child in children)
        //    {
        //        child.Value.Dfs(str + child.Key);
        //    }
        //}

        //private string PrintMe(int count = 0)
        //{
        //    if (this.pattern != null)
        //    {
        //        return this.pattern.Substring(0, this.pattern.Length - count);
        //    }

        //    var enumerator = this.children.GetEnumerator();
        //    enumerator.MoveNext();
        //    return enumerator.Current.Value.PrintMe(count + 1);
        //}        
    }
}
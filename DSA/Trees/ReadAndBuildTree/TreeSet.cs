using System;
using System.Collections;
using System.Collections.Generic;

namespace ReadAndBuildTree
{
    public class TreeSet<T> : IEnumerable<T>
    {
        private TreeNode<T> root;

        public TreeSet(TreeNode<T> root)
        {
            this.root = root;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

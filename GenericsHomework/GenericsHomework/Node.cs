using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace GenericsHomework
{
    public class Node<T> : ICollection<T>
    {
        public T Value { get; }

        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this;
        }

        public Node<T> Append(T value)
        {
            if (Exists(value))
                throw new ArgumentException("Cannot add same value more than once", nameof(value));

            var next = Next;
            Next = new Node<T>(value)
            {
                Next = next
            };
            return Next;

        }

        public bool Exists(T value)
        {
            var current = this;
            do
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                    return true;

                current = current.Next;
            } while (current != this);

            return false;
        }

        public void Add(T item)
        {
            Append(item);
        }

        public void Clear()
        {
            if (Next == this)
                return;
            var next = Next;
            Next = this;
            next.Clear();
        }

        public bool Contains(T item)
        {
            return Exists(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var count = Count;
            var current = this;
            for (int i = arrayIndex; i < arrayIndex + count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (!Exists(item))
                return false;
            var current = this;
            while (!EqualityComparer<T>.Default.Equals(current.Next.Value, item))
            {
                current = current.Next;
            }

            // get the node to remove
            var toRemove = current.Next;
            // set the node behind it's next to the removed node's next (bridge the gap that was created)
            current.Next = toRemove.Next;
            // apply a self-reference to the removed node
            toRemove.Next = toRemove;

            return true;
        }

        public int Count
        {
            get
            {
                var count = 1;
                var current = this.Next;
                while (current != this)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            var current = this;
            do
            {
                yield return current.Value;
                current = current.Next;
            } while(current != this );
        }

        public override string? ToString()
        {
            return Value?.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
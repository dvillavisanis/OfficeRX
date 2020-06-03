using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Module.Win
{
    public sealed class GEventArgs<T> : EventArgs
    {
        /// <summary>
        /// The item itself.
        /// </summary>
        public T Item { get; private set; }

        /// <summary>
        /// Constructs a GEventArgs object.
        /// </summary>
        /// <param name="item">The type of item.</param>
        public GEventArgs(T item)
        {
            Item = item;
        }
    }
}

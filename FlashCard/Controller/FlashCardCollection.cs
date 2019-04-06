using System;
using System.Collections.Generic;
using System.Collections;

//ToDo: Language Support.

namespace FlashCard
{
    internal class FlashCardCollection : IEnumerable<FlashCardItem>, IDisposable
    {
        IEnumerator<FlashCardItem> IEnumerable<FlashCardItem>.GetEnumerator() { return Items.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return Items.GetEnumerator(); }

        private List<FlashCardItem> Items;
        public FlashCardCollection() { Items = new List<FlashCardItem>(); }

        public FlashCardItem this[int index]
        {
            get { return Items[index]; }
            private set { Items[index] = value; }
        }
        public int IndexOf(FlashCardItem item) { return Items.IndexOf(item); }

        public void Clear() { Items.Clear(); }
        public void Add(FlashCardItem item) { Items.Add(item); }
        public int Count { get { return Items.Count; } }

        public int ItemIndex { get; set; }
        public void ResetIndex() { ItemIndex = -1; }
        public FlashCardItem Next
        {
            get
            {
                FlashCardItem result;
                try { result = Items[++ItemIndex]; }
                catch { result = null; }
                return result;
            }
        }
        public FlashCardItem Selected
        {
            get
            {
                FlashCardItem result;
                try { result = Items[ItemIndex]; }
                catch { result = null; }
                return result;
            }
        }

        private Random rng = new Random(DateTime.Now.Millisecond);
        public void Shuffle()
        {
            int n = Items.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                FlashCardItem value = Items[k];
                Items[k] = Items[n];
                Items[n] = value;
            }
        }
        public FlashCardItem GetRandomCard()
        {
            return Items[rng.Next(Items.Count)];
        }

        #region [ Dispose Pattern ]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing) ReleaseManagedResources();
        }
        private void ReleaseManagedResources()
        {
            //Release managed resources
            foreach (FlashCardItem ptrItem in Items) ptrItem.Dispose();
            Items.Clear();
        }
        private void ReleaseUnmanagedResources()
        {
            //Release unmanaged resources
        }
        #endregion
    }
}

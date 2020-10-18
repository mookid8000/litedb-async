namespace LiteDB.Async
{
    /// <summary>
    /// Wraps a LiteCollection which will only be queried in the background thread
    /// </summary>
    public partial class LiteCollectionAsync<T>
    {
        internal LiteCollectionAsync(ILiteCollection<T> liteCollection, LiteDatabaseAsync liteDatabaseAsync)
        {
            UnderlyingCollection = liteCollection;
            Database = liteDatabaseAsync;
        }

        /// <summary>
        /// The database this collection belongs to
        /// </summary>
        public LiteDatabaseAsync Database { get; }

        /// <summary>
        /// The underlying ILiteCollection we wrap
        /// </summary>
        public ILiteCollection<T> UnderlyingCollection { get; }

        /// <summary>
        /// Return a new LiteQueryableAsync to build more complex queries
        /// </summary>
        public LiteQueryableAsync<T> Query()
        {
            return new LiteQueryableAsync<T>(UnderlyingCollection.Query(), Database);
        }
    }
}
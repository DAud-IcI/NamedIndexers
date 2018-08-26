namespace IcIWare.NamedIndexers
{
    /// <summary>
    /// A named indexer which only has a getter. (read-only)
    /// </summary>
    /// <typeparam name="Tkey">The type of the indexer's key.</typeparam>
    /// <typeparam name="Tvalue">The type of the getter's output.</typeparam>
    public class NamedGetter<Tkey, Tvalue> : NamedIndexerBase<Tkey, Tvalue>
    {
        /// <summary>
        /// Gets the value using the logic passed in to the constructor.
        /// </summary>
        /// <param name="key">The key which is used to pick which data to read.</param>
        /// <returns>The value indicated by the key using the user-prepared getter logic.</returns>
        public Tvalue this[Tkey key]
        {
            get => _getter(key);
        }

        /// <summary>
        /// Creates a named indexer which has only a getter.
        /// </summary>
        /// <param name="host">The object which contains the indexer instance. (ie. "this")</param>
        /// <param name="getter">The method that will be used as the indexer's getter.</param>
        /// <param name="setter">The method that will be used as the indexer's setter.</param>
        public NamedGetter(GetterFunction getter) : base(getter) { }
    }
}

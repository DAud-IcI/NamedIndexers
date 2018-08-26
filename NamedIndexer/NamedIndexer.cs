namespace IcIWare.NamedIndexers
{
    /// <summary>
    /// A named indexer which has both a getter and a setter. (read-write)
    /// </summary>
    /// <typeparam name="Tkey">The type of the indexer's key.</typeparam>
    /// <typeparam name="Tvalue">The type of the getter's output and the setter's input.</typeparam>
    public class NamedIndexer<Tkey, Tvalue> : NamedIndexerBase<Tkey, Tvalue>
    {
        /// <summary>
        /// Gets or sets the value using the logic passed in to the constructor.
        /// </summary>
        /// <param name="key">The key which is used to pick which data to read or write.</param>
        /// <returns>The value indicated by the key using the user-prepared getter and setter logic.</returns>
        public Tvalue this[Tkey key]
        {
            get => _getter(key);
            set => _setter(key, value);
        }

        /// <summary>
        /// Creates a named indexer which has a getter and a setter.
        /// </summary>
        /// <param name="getter">The method that will be used as the indexer's getter.</param>
        /// <param name="setter">The method that will be used as the indexer's setter.</param>
        public NamedIndexer(GetterFunction getter, SetterFunction setter)
            : base(getter, setter) { }
    }
}

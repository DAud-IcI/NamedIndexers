namespace IcIWare.NamedIndexers
{
    /// <summary>
    /// The abstract base for the named indexers and container for their appropriate getter & setter delegates
    /// </summary>
    /// <typeparam name="Tkey">The type of the indexer's key.</typeparam>
    /// <typeparam name="Tvalue">The type of the getter's output and the setter's input.</typeparam>
    public abstract class NamedIndexerBase<Tkey, Tvalue>
    {
        /// <summary>
        /// Encapsulates a method that will be used as the indexer's getter.
        /// </summary>
        /// <param name="key">The key used for indexing.</param>
        /// <returns>The value identified by the indexer.</returns>
        public delegate Tvalue GetterFunction(Tkey key);

        /// <summary>
        /// Encapsulates a method that will be used as the indexer's setter.
        /// </summary>
        /// <param name="key">The key used for indexing.</param>
        /// <param name="value">The value which will be written to the position indicated by the key.</param>
        public delegate void SetterFunction(Tkey key, Tvalue value);

        
        protected GetterFunction _getter;
        protected SetterFunction _setter;


        /// <summary>
        /// The base constructor for specifying the getter and setter.
        /// </summary>
        /// <param name="getter">The method that will be used as the indexer's getter.</param>
        /// <param name="setter">The method that will be used as the indexer's setter.</param>
        public NamedIndexerBase(GetterFunction getter, SetterFunction setter = null)
        {
            _getter = getter;
            _setter = setter;
        }
    }
}

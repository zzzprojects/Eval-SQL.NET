namespace Z.Expressions.SqlServer.Eval
{
    /// <summary>A sqlnet parallel item.</summary>
    public class SQLNETParallelItem
    {
        public int ParallelId;

        /// <summary>Gets or sets the parameter values used to evaluate the code or expression.</summary>
        public ListDictionary ParameterValues;

        /// <summary>Default constructor.</summary>
        public SQLNETParallelItem()
        {
            ParameterValues = new ListDictionary();
        }
    }
}
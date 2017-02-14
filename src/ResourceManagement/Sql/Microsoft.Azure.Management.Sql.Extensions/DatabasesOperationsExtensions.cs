namespace Microsoft.Azure.Management.Sql
{
    public static class SqlManagementClientExtensions
    {
        public static IExtendedDatabasesOperations DatabaseExtensions(this SqlManagementClient source)
        {
            return new ExtendedDatabasesOperations(source);
        }
    }
}
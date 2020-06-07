namespace TypesAndEncapsulation.CreateTypes
{
    internal class Category<T> : ICategory<T> where T : Person, new()
    {
        public T CreateCategory()
        {
            return new T();
        }
    }

    internal interface ICategory<T> where T: Person, new()
    {
        T CreateCategory();
    }
}
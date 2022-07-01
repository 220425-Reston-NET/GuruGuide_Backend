namespace GuruGuideDL
{
   public interface IRepository<T>
    {
        //CRUD operations
        //Create, Read, Update, and Delete

        /// <summary>
        /// This will create a resource to the database
        /// </summary>
        /// <param name="p_resource">This is the resource being saved to the database</param>

        void Add(T p_resource);
    }

}



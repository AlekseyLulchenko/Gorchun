using Gorchun.Core.Models;


namespace Gorchun.Core.DataBase
{
    public class MaterialsProvider
    {
        private readonly string _connectionString;
        public MaterialsProvider()
        {
            _connectionString = DataBaseFileHelper.GetConnectionString();
        }

        public void AddNew(Material newItem)
        {
            using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
            {
                context.Materials.Add(newItem);
                context.SaveChanges();
            }
        }
    }
}

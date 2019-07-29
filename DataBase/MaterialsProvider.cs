using Gorchun.Core.Models;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Data.Entity;


namespace Gorchun.DataBase
{
    public class MaterialsProvider
    {
        private readonly string _connectionString;
        public MaterialsProvider()
        {
            _connectionString = DataBaseFileHelper.GetConnectionString();
        }


        public Material GetById(string cas)
        {
            CheckStringForNull(cas, nameof(cas));

            using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
            {
                return context.Materials.FirstOrDefault(m => m.Cas == cas);
            }
        }


        public List<Material> GetAll()
        {
            using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
            {
                return context.Materials.ToList();
            }
        }


        public List<Material> GetAll(Expression<Func<Material, bool>> predicate)
        {
            using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
            {
                return context.Materials.Where(predicate).ToList();
            }
        }


        public void AddNew(Material newItem)
        {

            CheckObjectForNull(newItem, nameof(newItem));
            CheckStringForNull(newItem.Cas, nameof(newItem.Cas));

            using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
            {
                if (context.Materials.FirstOrDefault(e => e.Cas == newItem.Cas) != null)
                {
                    throw new Exception($"Element with specified CAS already exists in the database (CAS: {newItem.Cas})");
                }

                context.Materials.Add(newItem);
                context.SaveChanges();
            }
        }


        public void UpdateExistingFrom(Material item)
        {
            CheckObjectForNull(item, nameof(item));
            CheckStringForNull(item.Cas, nameof(item.Cas));

            using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
            {
                Material existingElement = context.Materials.FirstOrDefault(e => e.Cas == item.Cas);

                if (existingElement == null)
                {
                    throw new Exception($"Element with specified CAS not found in the database (CAS: {item.Cas})");
                }

                existingElement.UpdateFrom(item);
                context.SaveChanges();
            }
        }


        public void DeleteById(string cas)
        {
            CheckStringForNull(cas, nameof(cas));

            using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
            {
                Material item = context.Materials.FirstOrDefault(m => m.Cas == cas);

                CheckObjectForNull(item, nameof(item));

                context.Materials.Remove(item);
                context.SaveChanges();
            }
        }


	    public void FillWithTestData(int count)
	    {
		    using (MaterialsDbContext context = new MaterialsDbContext(_connectionString))
		    {
			    context.Materials.ForEachAsync(m => context.Materials.Remove(m));

				for (int i = 1; i < count + 1; i++)
				{
					context.Materials.Add(new Material()
					{
						Cas = "111-" + i.ToString(),
						Naimenovanie = "Element" + i,
						Formula = "H2O",
						MolekuliarniyVes = i + 1.3f,
						Tkipeniya = i + 1.3f,
						Tplavleniya = i + 1.3f,
						Plotnost = i + 1.3f,
						Viazkost = i + 1.3f,
						Letuchest = i + 1.3f,
						Cmax = i + 1.3f,
						RastvorimostVVode = i + 1.3f,
						Rastvorimost = i + 1.3f,
						PH = i + 1.3f,
						PovNatiazhenie = i + 1.3f,
						Teratogennost = true,
						Kantserogennost = null,
						Mutagennost = true,
						Imunnogennost = null,
						Gepatotoksichnost = true,
						LD50Zheludok = i + 1.3f,
						LD50kozha = i + 1.3f,
						LCt50 = i + 1.3f,
					});
				}

				context.SaveChanges();
		    }

		}

		private void CheckStringForNull(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"Can't be null or empty: {parameterName}");
            }
        }

        private void CheckObjectForNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Can't be null or empty: {parameterName}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace TestApp.Models
{
    public class Repository:IDisposable
    {

        TestContext context = new TestContext();
        //Singleton, it is created in type constr
        private static readonly Repository r = new Repository();

        public Repository()
        {       
        }

        public static Repository GetRepos()
        {
            return r;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable

        public void AddCatalog(Catalog cat)
        {
            cat.CatalogMap = new CatalogMap();
            context.Catalogs.Add(cat);

            foreach (Aggregate a in cat.Aggregates)
            {
                a.AggregateMap = new AggregateMap();

                context.Aggregates.Add(a);

                foreach(Model m in a.Models)
                {
                    m.ModelMap = new ModelMap();

                    context.Models.Add(m);
                }
            }

            context.SaveChanges();
        }

        public List<CatalogLevel> CatalogLevels
        {
            get
            {
                List<CatalogMap> cms = context.CatalogMaps.Include(c => c.Catalog).ToList();
                List<AggregateMap> ams = context.AggregateMaps.Include(a => a.Aggregate).ToList();
                List<ModelMap> mms = context.ModelMaps.Include(c => c.Model).ToList();

                var res = new List<CatalogLevel>(cms.Count + ams.Count + mms.Count);
                res.AddRange(cms);
                res.AddRange(ams);
                res.AddRange(mms);

                return res;
            }
        }

        public void ClearDB()
        {
            context.Catalogs.RemoveRange(context.Catalogs);
            context.Aggregates.RemoveRange(context.Aggregates);
            context.Models.RemoveRange(context.Models);
            context.CatalogLevels.RemoveRange(context.CatalogLevels);

            context.SaveChanges();
        }
    }
}

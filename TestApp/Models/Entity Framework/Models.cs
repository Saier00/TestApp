using System.Collections.Generic;
namespace TestApp.Models
{
    public class Catalog
    {
        public Catalog()
        {
            Aggregates = new List<Aggregate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Aggregate> Aggregates { get; set; }
        public CatalogMap CatalogMap { get; set; }
    }
    public class Aggregate
    {
        public Aggregate()
        {
            Models = new List<Model>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
        public ICollection<Model> Models { get; set; }
        public AggregateMap AggregateMap { get; set; }
    }
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AggregateId { get; set; }
        public Aggregate Aggregate { get; set; }
        public ModelMap ModelMap { get; set; }
    }

    public class CatalogLevel
    {
        public int Id { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual string Name { get; set; }
    }

    public class CatalogMap : CatalogLevel
    { 
        public Catalog Catalog { get; set; }
        public override string Name
        {
            get
            {
                if (Catalog != null)
                    return Catalog.Name;
                return null;
            }
            set { }
        }
    }
    public class AggregateMap : CatalogLevel
    {
        public Aggregate Aggregate { get; set; }
        public override int? ParentId
        {
            get
            {
                if(Aggregate!=null)
                    return Aggregate.Catalog.CatalogMap.Id;
                return null;
            }
            set { }
        }
        public override string Name
        {
            get
            {
                if (Aggregate != null)
                    return Aggregate.Name;
                return null;
            }
            set { }
        }
    }
    public class ModelMap : CatalogLevel
    {
        public Model Model { get; set; }
        public override int? ParentId
        {
            get
            {
                if(Model!=null)
                    return Model.Aggregate.AggregateMap.Id;
                return null;
            }
            set { }
        }
        public override string Name
        {
            get
            {
                if (Model != null)
                    return Model.Name;
                return null;
            }
            set { }
        }
    }
}

namespace TestApp.Models
{
    public class TestSeeder:ISeeder
    {
        private Repository rep= Repository.GetRepos();
        public void Seed()
        {
            //Optional cleaning of db
            rep.ClearDB();

            Catalog cat = new Catalog() { Name = "VOLVO"};

            Aggregate agr = new Aggregate() { Name = "КПП" };
            agr.Models.Add(
                new Model() { Name="A365"}
                );

            cat.Aggregates.Add(agr);

            rep.AddCatalog(cat);


            cat = new Catalog() { Name = "ER" };

            agr = new Aggregate() { Name = "Двигатель" };
            agr.Models.Add(
                new Model() { Name = "M4566" }
                );
            agr.Models.Add(
                new Model() { Name = "FG4511" }
                );

            cat.Aggregates.Add(agr);

            agr = new Aggregate() { Name = "КПП" };
            agr.Models.Add(
                new Model() { Name = "T45459" }
                );

            cat.Aggregates.Add(agr);

            rep.AddCatalog(cat);
        }
        
    }
}

using System;
using System.Text;

namespace TestApp.Models
{
    class RandomSeeder : ISeeder
    {
        private Repository rep = Repository.GetRepos();
        private Random rnd = new Random();
        public void Seed()
        {
            //Optional cleaning of db
            rep.ClearDB();

            for (int i = 0; i < 20; i++)
            {
                Catalog cat = new Catalog() { Name = GetRandomWord(5) };

                Aggregate agr = new Aggregate() { Name = GetRandomWord(rnd.Next(3, 5)) };

                for (int k = 0; k < rnd.Next(1, 6); k++)
                {
                    agr.Models.Add(
                        new Model() { Name = GetRandomWord(1) + GetRandomInt(rnd.Next(3, 6)) }
                        );
                }

                cat.Aggregates.Add(agr);

                rep.AddCatalog(cat);
            }
        }

        //Get rnd word with length CharNum
        private string GetRandomWord(int CharNum)
        {
            StringBuilder sb = new StringBuilder(CharNum);

            for(int i=0; i<CharNum; i++)
            {
                sb.Append((char)rnd.Next((int)'A', (int)'Z'));
            }

            return sb.ToString();
        }
        //Get string of rnd int with number of digits is equal to IntNum
        private string GetRandomInt(int IntNum)
        {
            return (
                rnd.Next(
                    (int)Math.Pow(10, IntNum),
                    (int)Math.Pow(10, IntNum + 1) - 1
                    )
                ).ToString();
        }
    }
}

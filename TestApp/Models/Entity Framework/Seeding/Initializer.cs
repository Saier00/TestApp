namespace TestApp.Models
{
    public static class Initializer
    {
        private static bool isSeeded = false;
        public static void SeedDB(ISeeder s)
        {
            if (!isSeeded)
            {
                s.Seed();
                isSeeded = true;
            }
        }

    }
}

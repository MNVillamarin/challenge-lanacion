using LaNacion.Domain.Entities;
using LaNacion.Domain.Enums;
using LaNacion.Persistence.Contexts;

namespace LaNacion.Persistence.Seed
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Contacts.Any())
            {
                string[] name = new string[] {
                "Maria", "Pedro", "Ana", "Luis", "Miguel", "Jorge", "Cristina", "Eduardo", "Andrea", "Mauricio", "Juliana", "David", "Julio", "Daniela", "Gabriel", "Lucia", "Carlos", "Valeria", "Fernanda", "Sebastian", "Gabriela", "Diego", "Paula", "Alejandro", "Valentina", "Santiago", "Natalia", "Samantha", "Ricardo", "Isabella", "Javier", "Camila", "Adrian", "Diana", "Erick", "Karina", "Fabian", "Veronica", "Francisco", "Gabriela", "Guillermo", "Maria Jose", "Enrique", "Fernanda", "Hector", "Andrea", "Ignacio", "Liliana", "Joaquin", "Nataly" };
                string[] company = new string[] {
                    "Google", "Google", "Google", "Google", "Google", "Sarasa", "Apple", "Amazon", "Microsoft", "Facebook", "Tesla", "Walmart", "GE", "Procter & Gamble", "Coca-Cola", "ExxonMobil", "Boeing", "AT&T", "Ford", "Chevron", "Johnson & Johnson", "Pfizer", "Caterpillar", "3M", "United Technologies", "Bristol-Myers Squibb", "Cisco Systems", "Walt Disney", "American Express", "United Parcel Service (UPS)", "McDonald's", "PepsiCo", "Home Depot", "Honeywell International", "United Airlines", "Merck", "Dow Chemical", "Baxter International", "American Airlines Group", "Celgene", "Baxter International", "Illinois Tool Works", "Humana", "Delta Air Lines", "Bristol-Myers Squibb", "American Electric Power", "Aetna", "Aflac", "AGCO", "Air Products & Chemicals" };
                string[] email = new string[] {
                "ramon@gmail.com", "soledad@gmail.com", "pepe@gmail.com", "carlos@gmail.com", "roberto@gmail.com", "pedro@yahoo.com", "maria@hotmail.com", "ana@gmail.com", "luis@yahoo.com", "sofia@hotmail.com", "miguel@gmail.com", "jorge@yahoo.com", "cristina@hotmail.com", "eduardo@gmail.com", "andrea@yahoo.com", "mauricio@hotmail.com", "juliana@gmail.com", "david@yahoo.com", "julio@hotmail.com", "daniela@gmail.com", "gabriel@yahoo.com", "lucia@hotmail.com", "carlos@gmail.com", "valeria@yahoo.com", "fernanda@hotmail.com", "sebastian@gmail.com", "gabriela@yahoo.com", "diego@hotmail.com", "paula@gmail.com", "alejandro@yahoo.com", "valentina@hotmail.com", "santiago@gmail.com", "natalia@yahoo.com", "samantha@hotmail.com", "ricardo@gmail.com", "isabella@yahoo.com", "javier@hotmail.com", "camila@gmail.com", "adrian@yahoo.com", "diana@hotmail.com", "erick@gmail.com", "karina@yahoo.com", "fabian@hotmail.com", "veronica@gmail.com", "francisco@yahoo.com", "gabriela@hotmail.com", "guillermo@gmail.com", "mariajose@yahoo.com", "enrique@hotmail.com", "fernanda@gmail.com"};
                string[] city = new string[] {
                "Houston", "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville", "Fort Worth", "Columbus", "San Francisco", "Charlotte", "Indianapolis", "Seattle", "Denver", "Washington", "Boston", "El Paso", "Nashville", "Detriot", "Portland", "Memphis", "Oklahoma City", "Las Vegas", "Louisville", "Baltimore", "Milwaukee", "Albuquerque", "Tucson", "Fresno", "Sacramento", "Mesa", "Atlanta", "Kansas City", "Colorado Springs", "Miami", "Raleigh", "Omaha", "Long Beach", "Virginia Beach", "Oakland", "Minneapolis", "Tulsa", "Wichita", "New Orleans"};
                string[] state = new string[] {
                "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"};
                string[] street = new string[]
                {
                    "Palermo Street", "Otto Street", "Cerrito Street", "Boldo Street", "False Street", "Rule Street", "Main Street", "Park Avenue", "Broadway", "Second Street", "Third Street", "First Street", "Fourth Street", "Fifth Street", "Oak Street", "Maple Street", "Cedar Street", "Elm Street", "Pine Street", "Lincoln Avenue", "Washington Avenue", "Madison Avenue", "Jefferson Avenue", "Adams Street", "Roosevelt Avenue", "Hamilton Avenue", "Grant Street", "Madison Street", "Monroe Street", "Jackson Street", "Washington Street", "Lincoln Street", "Eisenhower Street", "Truman Street", "Ford Street", "Nixon Street", "Johnson Street", "Kennedy Street", "Carter Street", "Reagan Street", "Bush Street", "Clinton Street", "Obama Street", "Trump Street", "Carter Avenue", "Reagan Avenue", "Bush Avenue", "Clinton Avenue", "Obama Avenue", "Trump Avenue"
                };

                List<Contact> contacts = new List<Contact>();

                for (int i = 0; i < 50; i++)
                {
                    var phones = new List<Phone>();
                    phones.Add(new Phone { PhoneType = PhoneType.Work, PhoneNumber = GenerateRandomNumber(10).ToString() });
                    phones.Add(new Phone { PhoneType = PhoneType.Personal, PhoneNumber = GenerateRandomNumber(10).ToString() });

                    var address = new Address
                    {
                        City = city[i],
                        State = state[i],
                        Street = street[i],
                        ZipCode = GenerateRandomNumber(5).ToString()
                    };

                    contacts.Add(new Contact()
                    {
                        Name = name[i],
                        Company = company[i],
                        ProfileImage = $"http://www.image.com/{name[i]}.jpg",
                        Email = email[i],
                        Birthdate = GenerateRandomDate(),
                        Phones = phones,
                        Address = address
                    });
                }

                await context.Contacts.AddRangeAsync(contacts);
                await context.SaveChangesAsync();
            }
        }

        private static int GenerateRandomNumber(int slots)
        {
            int min = (int)Math.Pow(10, slots - 1);
            int max = (int)Math.Pow(10, slots) - 1;
            return new Random().Next(min, max);
        }
        private static DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1950, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(new Random().Next(range));
        }
    }
}

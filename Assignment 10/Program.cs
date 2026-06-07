namespace Assignment_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region დავალება 1 (Musical instruments)

            Violin violin1 = new Violin("Stradivarius", 0.6, 2015, "laa", Colors.Brown, Conditions.New);
            Ukulele ukulele1 = new Ukulele("Kala KA-15S", 0.7, 2018, "dinggg", Colors.White, Conditions.Used);
            Trombone trombone1 = new Trombone("Yamaha YSL-354", 1.8, 2012, "brrr", Colors.Golden, Conditions.New);
            Cello cello1 = new Cello("Yamaha Silent Cello SVC-210", 3.1, 2019, "humm", Colors.Black, Conditions.Refurbished);

            // ისტორია კონსტრუქტორის გარეშე შევიყვანე
            violin1.History = "The modern violin emerged in Northern Italy around 1550, standardized by Andrea Amati who combined medieval bowed instruments into the definitive four-string design. It reached its acoustic peak during the Golden Age (1650–1750) through master luthiers Antonio Stradivari and Giuseppe Guarneri in Cremona. In the 19th century, the instrument was physically modified with a longer, angled neck and a denser internal structure to increase string tension, allowing it to project loudly across massive modern concert halls.";
            ukulele1.History = "The ukulele originated in Hawaii in 1889, evolving from the machete, a small four-string guitar introduced by Portuguese immigrants. Hawaiian King Kalakaua championed the instrument, blending it into local culture and royal gatherings. It gained massive global popularity after being featured at the 1915 Panama-Pacific International Exposition in San Francisco, eventually becoming a staple of American jazz, pop, and folk music due to its portable size and bright, rhythmic sound.";
            trombone1.History = "The trombone emerged in 15th-century Europe, evolving from the trumpet into an instrument called the sackbut, which utilized a telescopic slide to play chromatic notes. It became a staple in Renaissance church music and Baroque ensembles before being integrated into classical orchestras by composers like Beethoven in the early 19th century. Renamed the trombone, it developed a wider bell and larger bore over time, eventually becoming a foundational powerhouse voice in modern orchestral, jazz, and big band music.";
            cello1.History = "The cello emerged in 16th-century Italy, evolving from the medieval bass violin and standardized by master luthier Andrea Amati into the definitive four-string violoncello. It transitioned from a pure bass accompaniment role to a brilliant solo instrument in the Baroque era through the masterpieces of J.S. Bach. By the 19th century, it was physically modified with an angled neck, raised bridge, and endpin to maximize string tension, producing the rich, powerful tone used in modern orchestras.";

            Console.WriteLine("Choose a instrument: Violin, Ukulele, Trombone, Cello.");

            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "violin": violin1.DoMethods(); break;

                case "ukulele": ukulele1.DoMethods(); break;

                case "trombone": trombone1.DoMethods(); break;

                case "cello": cello1.DoMethods(); break;

                default: Console.WriteLine("Something went wrong. Try again."); break;
            }

            #endregion


            #region დავალება 2 (Workers)

            President president1 = new President("Quinn", "Slayshvili", new DateTime (1982, 2, 2), Gender.Female, 250.000m, PoliticalParty.Other);
            Security security1 = new Security("Alex","Xachapuridze", new DateTime (1999, 12, 7), Gender.Male, 50.000m, Shift.Day, true);
            Manager manager1 = new Manager("Natia", "suxishvili", new DateTime(2000, 11, 23), Gender.Female, 80.000m, 12);
            Engineer engineer1 = new Engineer("Nodar", "Beradze", new DateTime(1980, 6, 15), Gender.Male, 85.000m, Specialization.Electrical);

            Console.WriteLine("Choose a worker: President, Security, Manager, Engineer.");

            string userInput1 = Console.ReadLine().ToLower();
            switch (userInput1)
            {
                case "president": president1.Print(); break;

                case "security": security1.Print(); break;

                case "manager": manager1.Print(); break;

                case "engineer": engineer1.Print(); break;

                default: Console.WriteLine("Something went wrong. Try again."); break;
            }

            #endregion
        }
    }
}

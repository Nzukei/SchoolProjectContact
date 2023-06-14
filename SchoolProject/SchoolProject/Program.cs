using SchoolProject.Contact;
using SchoolProject.Contact.Feature;


class Program {
    public static void Main(string[] args) {
        var save = new Save();
        var search = new Search();
        var delete = new Delete();

        while (true) {
            ContactHome.PrintHome();
            var choice = Convert.ToInt32(Console.ReadLine());
            bool quit = false;

            switch (choice) {
                case 1:
                    save.ContactSave();
                    break;
                case 2:
                    search.ContactSearch();
                    break;
                case 3:
                    delete.ContactDelete();
                    break;
                case 4:
                    quit = true;
                    break;
                default:
                    Console.Clear();
                    break;
            }

            if (quit) break;
        }
    }
}
namespace SchoolProject.Contact.Feature; 

public class Search : ContactHome {
    private string _searchName { get; set; }
    private bool _found;
    
    public void ContactSearch() {
        PrintSearch();
        _found = false;
        SearchFound();

        if (!_found) {
            NotFound();
        }
    }

    private void PrintSearch() {
        Console.Clear();
        Console.Write("이름을 입력해주세요: ");
        _searchName = Console.ReadLine();
    }

    private void SearchFound() {
        foreach (var contact in Contacts) {
            if (contact.Name != _searchName) continue;
            Console.Clear();
            Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
            Console.WriteLine($"이름: {contact.Name} \t 전화번호: {contact.PhoneNumber}");
            Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
            _found = true;
        }
    }
}
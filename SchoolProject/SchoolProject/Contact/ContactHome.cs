namespace SchoolProject.Contact; 

public class ContactHome {
    protected static readonly List<Contact> Contacts = new();

    public static void PrintHome() {
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー");
        Console.WriteLine("1. 연락처 저장\t2. 연락처 검색\t3. 삭제하기\t4. 종료하기");
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー");
    }
    
    protected static void NotFound() {
        Console.Clear();
        Console.WriteLine("연락처를 찾을 수 없습니다.");
    }
}



public class Contact {
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Contact(string name, string phoneNumber) {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}
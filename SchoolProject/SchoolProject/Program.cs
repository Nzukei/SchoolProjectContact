using System.Text.RegularExpressions;



class Program {
    public static void Main(string[] args) {
        MySystem mySystem = new MySystem();
        while (true) {
            mySystem.Home();
            
            // TODO: 전체 기록 보기
            switch (mySystem.choice) {
                case 1:
                    mySystem.ContactSave();
                    break;
                case 2:
                    mySystem.ContactSerach();
                    break;
                case 3:
                    mySystem.ContactDelete();
                    break;
                case 4:
                    mySystem.quit = true;
                    break;
                default:
                    Console.Clear();
                    break;
            }
            
            if (mySystem.quit) break;
        }
    }
}

class MySystem {
    private readonly List<Contact> _contacts = new();
    public bool quit;
    public int choice { get; set; }

    public void Home() {
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー");
        Console.WriteLine("1. 연락처 저장\t2. 연락처 검색\t3. 삭제하기\t4. 종료하기");
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー");
        choice = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
    }

    public void ContactSave() {
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        Console.WriteLine("연락처 저장");
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        Console.Write("이름을 입력하세요: ");
        var name = Console.ReadLine();

        Console.Write("\n전화번호를 입력하세요: ");
        var phoneNumber = Console.ReadLine();

        while (true)
            if (phoneNumber != null && PhoneNumCheck(phoneNumber)) break;
            else {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
                Console.WriteLine("숫자를 제대로 입력하세요");
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
                Console.ResetColor();
                Console.Write("전화번호를 입력하세요: ");
                phoneNumber = Console.ReadLine();
            }

        Console.Clear();
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        Console.WriteLine($"이름: {name}\t 전화번호: {phoneNumber}\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("1. 저장 \t");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("2. 취소 \n");
        Console.ResetColor();
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        var save = Convert.ToInt32(Console.ReadLine());
        switch (save) {
            case 1:
                var contact = new Contact(name, phoneNumber);
                _contacts.Add(contact);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("저장되었습니다.");
                Console.ResetColor();
                break;
            case 2:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("취소되었습니다.");
                Console.ResetColor();
                break;
        }
    }

    public void ContactSerach() {
        Console.Write("이름을 입력해주세요: ");
        var serachName = Console.ReadLine();
        var found = false;
        foreach (var contact in _contacts) {
            if (contact.Name != serachName) continue;
            Console.Clear();
            Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
            Console.WriteLine($"이름: {contact.Name} \t 전화번호: {contact.PhoneNumber}");
            Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
            found = true;
        }

        if (!found) {
            Console.Clear();
            Console.WriteLine("연락처를 찾을 수 없습니다.");
        }
    }

    public void ContactDelete() {
        Console.Write("이름을 입력해주세요: ");
        var deleteName = Console.ReadLine();
        var deleteFound = false;

        for (var i = 0; i < _contacts.Count; ++i)
            if (_contacts[i].Name == deleteName) {
                Console.WriteLine("정말 연락처를 삭제하시겠습니까?");
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
                Console.WriteLine($"이름: {_contacts[i].Name}\t 전화번호: {_contacts[i].PhoneNumber}\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("1. 삭제 \t");
                Console.ResetColor();
                Console.Write("2. 취소 \n");
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
                
                deleteFound = true;
                var agree = Convert.ToInt32(Console.ReadLine());

                switch (agree) {
                    case 1:
                        _contacts.RemoveAt(i);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("삭제되었습니다.");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("취소되었습니다.");
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("잘못된 입력값입니다.");
                        Console.ResetColor();
                        break;
                }
            }

        if (!deleteFound) {
            Console.Clear();
            Console.WriteLine("연락처를 찾을 수 없습니다.");
        }
    }

    private bool PhoneNumCheck(string number) {
        if (number.Length != 10 && number.Length != 11) return false;
        var regex = new Regex(@"01{1}[016789]{1}[0-9]{7,8}");
        var match = regex.Match(number);

        return match.Success;
    }
}


class Contact {
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Contact(string name, string phoneNumber) {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}
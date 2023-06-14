namespace SchoolProject.Contact.Feature;
using System.Text.RegularExpressions;

public class Save : ContactHome {
    private string _name;
    private string _phoneNumber;
    private int _save;
    
    public void ContactSave() {
        SaveNamePrint();
        SaveNumberPrint();
        SaveOrCancer();

        switch (_save) {
            case 1:
                var contact = new Contact(_name, _phoneNumber);
                Contacts.Add(contact);
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

    private void SaveNamePrint() {
        Console.Clear();
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        Console.WriteLine("연락처 저장");
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        Console.Write("이름을 입력하세요: ");
        _name = Console.ReadLine();
    }

    private void SaveNumberPrint() {
        Console.Write("\n전화번호를 입력하세요: ");
        _phoneNumber = Console.ReadLine();

        while (true)
            if (_phoneNumber != null && PhoneNumCheck(_phoneNumber)) break;
            else {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
                Console.WriteLine("숫자를 제대로 입력하세요");
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
                Console.ResetColor();
                Console.Write("전화번호를 입력하세요: ");
                _phoneNumber = Console.ReadLine();
            }
    }

    private void SaveOrCancer() {
        Console.Clear();
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        Console.WriteLine($"이름: {_name}\t 전화번호: {_phoneNumber}\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("1. 저장 \t");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("2. 취소 \n");
        Console.ResetColor();
        Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
        _save = Convert.ToInt32(Console.ReadLine());
    }
    
    private static bool PhoneNumCheck(string number) {
        if (number.Length != 10 && number.Length != 11) return false;
        var regex = new Regex(@"01{1}[016789]{1}[0-9]{7,8}");
        var match = regex.Match(number);

        return match.Success;
    }
}
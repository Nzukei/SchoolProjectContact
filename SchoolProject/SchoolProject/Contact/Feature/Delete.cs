namespace SchoolProject.Contact.Feature; 

public class Delete : ContactHome {
    private string _deleteName;
    private bool _found;
    
    public void ContactDelete() {
        Console.Clear();
        Console.Write("이름을 입력해주세요: ");
        _deleteName = Console.ReadLine();
        _found = false;
        DeleteOrCancer();

        if (!_found) {
            NotFound();
        }
    }

    private void DeleteOrCancer() {
        for (var i = 0; i < Contacts.Count; ++i)
            if (Contacts[i].Name == _deleteName) {
                Console.WriteLine("정말 연락처를 삭제하시겠습니까?");
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");
                Console.WriteLine($"이름: {Contacts[i].Name}\t 전화번호: {Contacts[i].PhoneNumber}\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("1. 삭제 \t");
                Console.ResetColor();
                Console.Write("2. 취소 \n");
                Console.WriteLine("ーーーーーーーーーーーーーーーーーーーー");

                _found = true;
                var agree = Convert.ToInt32(Console.ReadLine());

                switch (agree) {
                    case 1:
                        Contacts.RemoveAt(i);
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
    }
}
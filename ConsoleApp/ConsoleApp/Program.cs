//kullanıcıdan alınan kart numarasının geçerli olup olmadığını kontrol eden program

using ConsoleApp;

Console.WriteLine("Kart numaranızı giriniz");
var cardNumber = Console.ReadLine();
//lunh algorithm
//var cardNumber = "4345290022579976";

ActionTests.OnLunnhCheck += ShowMessage;

LunhChecker.Instance.Check(cardNumber);

ActionTests.OnLunnhCheck -= ShowMessage;

using (DisposeableClassTest disposeableClassTest = new DisposeableClassTest())
{
    
    Console.WriteLine("Dispose class kullanılabilir");
}



void ShowMessage(bool result)
{
    if (result)
    {
        Console.WriteLine("Geçerli kart numarası Bulundu Eventi");
    }
    else
    {
        Console.WriteLine("Geçersiz kart numarası Bulundu Eventi");
    }
}




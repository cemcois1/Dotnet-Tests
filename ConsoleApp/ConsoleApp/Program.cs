
//kullanıcıdan alınan kart numarasının geçerli olup olmadığını kontrol eden program

//kullanıcıdan kart numarası al

Console.WriteLine("Kart numaranızı giriniz");
var cardNumber = Console.ReadLine();
//lunh algorithm
//var cardNumber = "4345290022579976";

LunhChecker.Check(cardNumber);
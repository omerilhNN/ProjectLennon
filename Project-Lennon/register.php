<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess'); 
//mysql ile baðlantý deðiþkeni , localhost konumuna, root username ve root password bilgisiyle, unityaccess databaseine

//Baðlantý gerçekleþti mi kontrol
if (mysqli_connect_errno()) //Eðer hata yoksa false, hata varsa true dönen metod.
{
    echo "1:Baðlantý baþarýsýz oldu"; //error code #1 - baðlantý saðlanamadý.
    exit();
}

$username = $_POST["name"];
$password = $_POST["password"];

//database'de name mevcut mu diye kontrol et.
$namecheckquery = "SELECT username FROM players WHERE username ='" . $username . "';"; 
//players tablosundaki name sütunundan name'in username'e eþit olduðu satýrlarý sorgula.

$namecheck = mysqli_query($con, $namecheckquery) or die("2:Ýsim sorgusu hatalý"); 
//Eðer sorgu bir sebepten ötürü çalýþmazsa die çalýþtýr -> Error code #2 - Ýsim sorgusu hatalý. bastýr

if (mysqli_num_rows($namecheck) > 0) //Sorguyla eþleþen isim satýrý bulunmuþsa true
{
    echo ("3:Kullanýcý adý mevcut yeni bir kullanýcý adý deneyiniz");
    exit();
}

$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
$hash = crypt($password, $salt); //salt'ý þifrele ve bilgi güvenliði için sakla.
$insertuserquery = "INSERT INTO players (username,hash,salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');"; 
//playersdaki name, hash, salt deðiþkenlerine þu deðerleri ata.
mysqli_query($con, $insertuserquery) or die("4:Insert player sorgusu saðlanamadý"); 
//con baðlantýsýndaki, insertuserquery sorgusu çalýþmýþsa alt satýrlara geçer çalýþmamýþsa, hatayý yazdýr ve satýrý sonlandýr

echo ("0");

?>
<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess'); 
//sql ile baðlantý deðiþkeni , localhost konumuna, root username ve root password bilgisiyle, unityaccess databaseine

//Baðlantý gerçekleþti mi kontrol
if (mysqli_connect_errno()) //Eðer hata yoksa false, hata varsa true dönen metod.
{
    echo "1:Baðlantý baþarýsýz oldu"; //error code #1 - baðlantý saðlanamadý.
    exit();
}

$username = mysqli_real_escape_string($con, $_POST["name"]);
$usernameclean = filter_var($username, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH); 
//Kullanýcý adý giriþi için gerekli olan filtrelemeler
$password = $_POST["password"];

//database'de name mevcut mu diye kontrol et.
$namecheckquery = " SELECT username, salt, hash, score FROM players WHERE username ='" . $usernameclean . "';"; 
//players tablosundaki name sütunundan name'in username'e eþit olduðu satýrlarý sorgula.

$namecheck = mysqli_query($con, $namecheckquery) or die("2:Ýsim sorgusu hatalý"); 
//Eðer sorgu bir sebepten ötürü çalýþmazsa die çalýþtýr -> Error code #2 - Ýsim sorgusu hatalý. bastýr

if (mysqli_num_rows($namecheck) != 1) //eþleþen isim 1'den farklýysa
{
    echo "5:Kullanýcý adý bulunamadý.";
    exit();
}
//Sorgudan giriþ bilgilerini al
$existinginfo = mysqli_fetch_assoc($namecheck); //bu deðiþkenden namecheck'in altýndaki deðerlere ulaþýlabilir.
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

$loginhash = crypt($password, $salt); //password'u salt kullanarak þifreleme yap.
if ($hash != $loginhash) {
    echo "6:Yanlýs sifre girildi";
    exit();
}

echo "0\t" . $existinginfo["score"];
?>
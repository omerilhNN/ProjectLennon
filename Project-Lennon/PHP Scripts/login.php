<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess'); 
//sql ile ba�lant� de�i�keni , localhost konumuna, root username ve root password bilgisiyle, unityaccess databaseine

//Ba�lant� ger�ekle�ti mi kontrol
if (mysqli_connect_errno()) //E�er hata yoksa false, hata varsa true d�nen metod.
{
    echo "1:Ba�lant� ba�ar�s�z oldu"; //error code #1 - ba�lant� sa�lanamad�.
    exit();
}

$username = mysqli_real_escape_string($con, $_POST["name"]);
$usernameclean = filter_var($username, FILTER_SANITIZE_STRING, FILTER_FLAG_STRIP_LOW | FILTER_FLAG_STRIP_HIGH); 
//Kullan�c� ad� giri�i i�in gerekli olan filtrelemeler
$password = $_POST["password"];

//database'de name mevcut mu diye kontrol et.
$namecheckquery = " SELECT username, salt, hash, score FROM players WHERE username ='" . $usernameclean . "';"; 
//players tablosundaki name s�tunundan name'in username'e e�it oldu�u sat�rlar� sorgula.

$namecheck = mysqli_query($con, $namecheckquery) or die("2:�sim sorgusu hatal�"); 
//E�er sorgu bir sebepten �t�r� �al��mazsa die �al��t�r -> Error code #2 - �sim sorgusu hatal�. bast�r

if (mysqli_num_rows($namecheck) != 1) //e�le�en isim 1'den farkl�ysa
{
    echo "5:Kullan�c� ad� bulunamad�.";
    exit();
}
//Sorgudan giri� bilgilerini al
$existinginfo = mysqli_fetch_assoc($namecheck); //bu de�i�kenden namecheck'in alt�ndaki de�erlere ula��labilir.
$salt = $existinginfo["salt"];
$hash = $existinginfo["hash"];

$loginhash = crypt($password, $salt); //password'u salt kullanarak �ifreleme yap.
if ($hash != $loginhash) {
    echo "6:Yanl�s sifre girildi";
    exit();
}

echo "0\t" . $existinginfo["score"];
?>
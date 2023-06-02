<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess'); 
//mysql ile ba�lant� de�i�keni , localhost konumuna, root username ve root password bilgisiyle, unityaccess databaseine

//Ba�lant� ger�ekle�ti mi kontrol
if (mysqli_connect_errno()) //E�er hata yoksa false, hata varsa true d�nen metod.
{
    echo "1:Ba�lant� ba�ar�s�z oldu"; //error code #1 - ba�lant� sa�lanamad�.
    exit();
}

$username = $_POST["name"];
$password = $_POST["password"];

//database'de name mevcut mu diye kontrol et.
$namecheckquery = "SELECT username FROM players WHERE username ='" . $username . "';"; 
//players tablosundaki name s�tunundan name'in username'e e�it oldu�u sat�rlar� sorgula.

$namecheck = mysqli_query($con, $namecheckquery) or die("2:�sim sorgusu hatal�"); 
//E�er sorgu bir sebepten �t�r� �al��mazsa die �al��t�r -> Error code #2 - �sim sorgusu hatal�. bast�r

if (mysqli_num_rows($namecheck) > 0) //Sorguyla e�le�en isim sat�r� bulunmu�sa true
{
    echo ("3:Kullan�c� ad� mevcut yeni bir kullan�c� ad� deneyiniz");
    exit();
}

$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
$hash = crypt($password, $salt); //salt'� �ifrele ve bilgi g�venli�i i�in sakla.
$insertuserquery = "INSERT INTO players (username,hash,salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');"; 
//playersdaki name, hash, salt de�i�kenlerine �u de�erleri ata.
mysqli_query($con, $insertuserquery) or die("4:Insert player sorgusu sa�lanamad�"); 
//con ba�lant�s�ndaki, insertuserquery sorgusu �al��m��sa alt sat�rlara ge�er �al��mam��sa, hatay� yazd�r ve sat�r� sonland�r

echo ("0");

?>
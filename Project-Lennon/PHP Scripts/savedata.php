<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
//sql ile ba�lant� de�i�keni , localhost konumuna, root username ve root password bilgisiyle, unityaccess databaseine

//Ba�lant� ger�ekle�ti mi kontrol
if (mysqli_connect_errno()) //E�er hata yoksa false, hata varsa true d�nen metod.
{
    echo "1:Ba�lant� ba�ar�s�z oldu"; //error code #1 - ba�lant� sa�lanamad�.
    exit();
}

$username = $_POST["name"];//web serverinin iste�iyle g�nderilen verileri i�erir.
$newscore = $_POST["score"];

$namecheckquery = "SELECT username FROM players WHERE username ='" . $username . "';";
//players tablosundaki name s�tunundan name'in username'e e�it oldu�u sat�rlar� sorgula.
$namecheck = mysqli_query($con, $namecheckquery) or die("2:�sim sorgusu hatal�");
//E�er sorgu bir sebepten �t�r� �al��mazsa die �al��t�r -> Error code #2 - �sim sorgusu hatal�. bast�r

if (mysqli_num_rows($namecheck) != 1) //e�le�en isim 1'den farkl�ysa
{
    echo "5:Kullan�c� ad� mevcut yeni bir kullan�c� ad� deneyiniz";
    exit();
}

$updatequery = "UPDATE players SET score = " . $newscore . " WHERE username = '" . $username . "';";
mysqli_query($con, $updatequery) or die("7: Sorgu kaydetme ba�ar�s�z");

echo "0";
?>
<?php
$con = mysqli_connect('localhost', 'root', 'root', 'unityaccess');
//sql ile baðlantý deðiþkeni , localhost konumuna, root username ve root password bilgisiyle, unityaccess databaseine

//Baðlantý gerçekleþti mi kontrol
if (mysqli_connect_errno()) //Eðer hata yoksa false, hata varsa true dönen metod.
{
    echo "1:Baðlantý baþarýsýz oldu"; //error code #1 - baðlantý saðlanamadý.
    exit();
}

$username = $_POST["name"];//web serverinin isteðiyle gönderilen verileri içerir.
$newscore = $_POST["score"];

$namecheckquery = "SELECT username FROM players WHERE username ='" . $username . "';";
//players tablosundaki name sütunundan name'in username'e eþit olduðu satýrlarý sorgula.
$namecheck = mysqli_query($con, $namecheckquery) or die("2:Ýsim sorgusu hatalý");
//Eðer sorgu bir sebepten ötürü çalýþmazsa die çalýþtýr -> Error code #2 - Ýsim sorgusu hatalý. bastýr

if (mysqli_num_rows($namecheck) != 1) //eþleþen isim 1'den farklýysa
{
    echo "5:Kullanýcý adý mevcut yeni bir kullanýcý adý deneyiniz";
    exit();
}

$updatequery = "UPDATE players SET score = " . $newscore . " WHERE username = '" . $username . "';";
mysqli_query($con, $updatequery) or die("7: Sorgu kaydetme baþarýsýz");

echo "0";
?>
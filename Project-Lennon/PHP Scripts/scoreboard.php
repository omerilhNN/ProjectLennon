<?php
//veri taban� ba�lant�s�
try {//kontrol ile ba�lant�dan d�nebilecek sorunlar� g�stermek i�in try-catch kullan�ld�.
    $vt = new PDO("mysql:host=localhost;dbname=unityaccess;charset=utf8", "root", "root");
    //Veri taban� ba�lant�s� i�in gerekli olan bilgiler girildi.(sondaki root �ifre oraya bir �ey de yaz�lmayabilir.)
}catch(PDOException $hata){
    echo $hata->getMessage();
}

if ($_REQUEST['komut'] == 'veriCekme') {
    $gelen_veriler = $vt->query("select * from players ORDER BY score DESC limit 0,5");
    //veri taban� ba�lant�s�yla istenilen sorguya y�nelik istekte bulunuldu. Order by ile s�ral� bir �ekilde skorlar istendi.
    if($gelen_veriler->rowCount()){
        foreach($gelen_veriler as $row){//sat�r sat�r kullan�c� ad� ve skor bilgilerine bak�ld�.
            echo $row['username'] . ";";//her kullan�c� ad�ndan sonra split i�lemi uyguland�.
            echo $row['score'] . ";"; //her skordan sonra split i�lemi uyguland�.
        }
    }
}

?>
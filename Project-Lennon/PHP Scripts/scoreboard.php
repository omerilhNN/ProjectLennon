<?php
//veri tabaný baðlantýsý
try {//kontrol ile baðlantýdan dönebilecek sorunlarý göstermek için try-catch kullanýldý.
    $vt = new PDO("mysql:host=localhost;dbname=unityaccess;charset=utf8", "root", "root");
    //Veri tabaný baðlantýsý için gerekli olan bilgiler girildi.(sondaki root þifre oraya bir þey de yazýlmayabilir.)
}catch(PDOException $hata){
    echo $hata->getMessage();
}

if ($_REQUEST['komut'] == 'veriCekme') {
    $gelen_veriler = $vt->query("select * from players ORDER BY score DESC limit 0,5");
    //veri tabaný baðlantýsýyla istenilen sorguya yönelik istekte bulunuldu. Order by ile sýralý bir þekilde skorlar istendi.
    if($gelen_veriler->rowCount()){
        foreach($gelen_veriler as $row){//satýr satýr kullanýcý adý ve skor bilgilerine bakýldý.
            echo $row['username'] . ";";//her kullanýcý adýndan sonra split iþlemi uygulandý.
            echo $row['score'] . ";"; //her skordan sonra split iþlemi uygulandý.
        }
    }
}

?>
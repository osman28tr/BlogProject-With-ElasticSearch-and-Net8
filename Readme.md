<h1>ElasticSearch ile Blog Projesi</h1>
<h3>1. Giriş</h3>
<p align="justify">
Gerçekleştirilen bu proje, ElasticSearch NoSQL veritabanının kullanıldığı basit bir blog projesidir. Projede amaç, elasticsearch veritabanını öğrenmek ve özellikle büyük boyutlu yapısal olmayan veriler üzerinde arama gücünü görmektir.
</p>
<p align="justify">
ElasticSarch, açık kaynaklı NoSQL bir veritabanıdır. Verileri json formatında kaydeder. En önemli özelliği, büyük boyutlu text dosyalarında çok hızlı ve performanslı bir şekilde arama yapabilmesidir. Arka planda Apache lucene kütüphanesini kullanır. Genelde hacimli datalar üzerinde arama yapmada kullanılır. Performanslı olmasının sebebi, text datası üzerindeki her bir kelimeyi indekslemesidir. Bu sayede oldukça performanslı bir arama sağlar.Elasticsearch’de tablolar indeks, satırlar doküman olarak adlandırılır.
</p>
<p align="justify">ElasticSearch üzerindeki veriler, Kibana adı verilen bir uygulama ile görselleştirilebilir, bu veriler üzerinde KQL dili ile çeşitli sorgulamalar yapılabilir. MSSQL'deki SQL Server Management Studio aracı gibi düşünülebilir.</p>

<h3>2. Kullanılan Dil ve Teknolojiler</h3>
C# - Asp.Net Core Mvc, ElasticSearch, DockerCompose - .Net 8

<h3>3. Ekran Görüntüleri</h3>
<img src="ElasticSearch.Web/wwwroot/images/screenshot1.PNG">
<img src="ElasticSearch.Web/wwwroot/images/screenshot2.PNG">
Kibana:
<img src="ElasticSearch.Web/wwwroot/images/screenshot3.PNG">
<h3>4. KQL Dili ile Örnek Sorgular</h3>
<ul>
<b>Örnek bir get isteği</b>
<li>
<img src="ElasticSearch.Web/wwwroot/images/screenshot4.PNG">
</li>
<b>Id'ye göre veri getirme</b>
<li>
<img src="ElasticSearch.Web/wwwroot/images/screenshot6.PNG">
</li>
<b>Dönen sonuç</b>
<li>
<img src="ElasticSearch.Web/wwwroot/images/screenshot5.2.PNG"><br>
<b>_version:</b> ilgili data’nın kaçıncı versiyonda olduğunu belirtir. Data, her güncellendiğinde bu sayı birer artar.<br>
<b>_seq_no:</b> ilgili data üzerinde gerçekleşen tüm crud işlemlerini belirtir.<br>
<b>_source:</b> data’nın asıl gövdesinin olduğu kısım. Ancak burada id olmadığına dikkat ediniz. id, _doc ile beraber gelir.
</li>
<br>
<b>Post ile veri ekleme</b>
<li>
<img src="ElasticSearch.Web/wwwroot/images/screenshot7.PNG">
</li>
<br>
<b>Put ile veri güncelleme</b>
<li>
<img src="ElasticSearch.Web/wwwroot/images/screenshot8.PNG">
</li>
<br>
<b>Delete ile veri silme</b>
<li>
<img src="ElasticSearch.Web/wwwroot/images/screenshot9.PNG">
</li>
</ul>

<h3>4. Kurulum</h3>
<ul>
<li>
    Visual studio'da üst sekmeden View -> Terminal kısmına tıklayınız.
</li>
<li>
    Ardından açılan pencereden "docker-compose up" komutunu giriniz. Bu komut ile projemizde yer alan dockercompose dosyası ve içerisinde yer alan konfigürasyonlar ile beraber elasticsearch ve kibana için gerekli imajlar bilgisayarımızda yoksa dockerhub'dan çekilecek ve bu imajlardan belirtilen portlarda containerlar ayağa kalkacaktır.
</li>
<li>
    Son olarak "ElasticSearch.Web" projemize sağ tıklayıp "Set as startup project" deyiniz ve start butonundan projeyi ayağa kaldırınız.
</li>
</ul>

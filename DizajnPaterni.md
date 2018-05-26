# Facade Patern #

Facade patern spada u strukturne paterne. Koristimo ga u slučaju da imamo vise podsistema. 
Omogućava nam da imamo više pogleda visokog nivoa (implementacija podsitema je skrivena od korinika).

## Struktura Facade Paterna ##
* Facade klasa koja definira i implementira jedinstveni interfejs za skup operacija nekog podsitema
* SubSystemClassN klasa definira interfejs u sklopu interfejsa nekog sistema

### Primjena u FarAway aplikaciji ###
Nema primjene u FarAway aplikaciji

## Factory Method Patern ##

Factory Method patern spada u kreacijske paterne. On omogućava kreiranje objekata na način da podklase 
odluče koju klasu treba instancirati.

## Struktura Factory Method ##

* IProduct definira interfejs za produkte
* ProductX klasa koja implementira interfejs IProduct
* Creator klasa posjeduje FactoryMethod() metodu koja odlucuje koju klasu instacirati

### Primjena u FarAway aplikaciji ###
Prilikom plaćanja usluge klijentu se obračunava određeni popust na osnovu unaprijed određenih pravila

# Observer Patern #

Spada u paterne ponašanja. Ospostavlja relaciju između objekata tako kada jedan objekat
promijeni stanje, drugi zainteresovani objekti se obavještavaju.

## Strukura Observer Paterna ##

* Subject klasa - instance ove klase neovisno mijenjaju svoje stanje i obavještavaju posmatrače(Observer)
* IObserver - interfejs koji sadrži samo jednu metodu oja se poziva kada se promijeni stanje Subject instance
* Observer - implementria IObserer interfejs
* Update - formira interfejs između Subject i Observer
* Notify - event mehanizam za povezivanje Update operacije za sve posmatrače

### Primjena u FarAway aplikaciji ### 
Ako prilikom rezervacije, sva mjesta budu zauzeta i ako u nekom trenutku prije isteka
krajnjeg roka za rezervaciju mjesto se oslobodi zainteresovani korisnik prima objavjet preko 
e-maila da je mjesto sada slobodno.

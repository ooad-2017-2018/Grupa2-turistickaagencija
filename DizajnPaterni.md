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
krajnjeg roka za rezervaciju mjesto se oslobodi zainteresovani korisnik prima obavjest preko 
e-maila da je mjesto sada slobodno.

## Adapter Patern ##
Osnovna funkcija Adapter paterna je omogućavanje šire upotrebe već postojećih klasa. Ukoliko ne želimo mijenjati već postojeću klasu, ali nam je iz nekog razloga potreban drugačiji interface, koristi se ovaj patern. Adapter klasa služi kao posrednik između orginalne klase i interface-a. Na ovaj način ne narušavamo integritet aplikacije.

## Struktura Adapter Paterna ##
* Client klasa-klasa koja preko ITarget interface-a surađuje sa drugim klasama
* ITarget-definira domen specifični interfejs koji klijent zahtjeva
* Adapter-implementira taj novi interface tj. prilagođava već postojeći interface
* Adaptee-definira postojeći interface koji će se prilagoditi

### Primjena u FarAway aplikaciji ###
Nije korišteno u FarAway aplikaciji

## Strategy Patern ##
Strategy patern izdvaja algoritam iz matične klase i uključuje ga u posebne klase. Pogodan je kada postoje različiti primjenjivi algoritmi (strategije) za neki problem.

## Struktura Strategy Paterna ##
* Context- Klasa preko koje Client klasa daje kontekstualne informacije za IStrategy algoritme. 
* Istrategy-definira zajednički interfejs za sve algoritme (strategije). 
* StrategyA, StrategyB – Klase koje implementiraju algoritme (konkretne strategije) tj. IStrategy interfejs.

## Primjena u FarAway aplikaciji ##
Moze se izdvojiti odvojen algoritam u zavisnosti od toga da li je korisnik ostvari popust ili ne i uključiti u klasu. Postoje dvije strategije, jedna ukoliko jeste ostvario popust i jedna ukoliko nije ostvario popust.

## State Patern ##
State Pattern je dinamička verzija Strategy paterna. Objekat mijenja način ponašanja na osnovu trenutnog stanja. Postiže se promjenom podklase unutar hijerarhije klasa.

## Struktura State Paterna ##
* Context- definira tekući kontekst i interface koji je u interesu klijenta i održava instancu stanja
* IState: Interface(apstraktna klasa) koja definiše ponašanje svih mogućih stanja klijenta
* StateA, StateB: Implementiraju konkretno stanje objekta. Svako stanje je predstavljeno jednom konkretnom klasom.

## Primjena u FarAway aplikaciji ##

Tipična primjena State Paterna je prilikom plaćanja elektronskim putem gdje može doći do više stanja (odbijena kartica, neispravan pin, nedovoljno novca na stanju, uspješno plaćanje...)

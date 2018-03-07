using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventuretime
{
    class Program
    {
        public static Random sayi = new Random();
        public class Kullanıcı
        {
            public string isim;
            public float işlemSüresi;
            public int sayfaSayisi;
        }

        public class KullanıcıRR
        {
            public string kullanıcıAdı;
            public int sayfaSayısı;
        }

        public class SüreKazancı
        {
            public string isim;
            public float kazançPQ = 0, kazançRandomFIFO = 0, kazançRandomPQ = 0, kazançFIFO = 0;
        }
        public class YazıcıFIFO
        {
            private List<int> kuyrukListe;
            public int elemanSay;

            public YazıcıFIFO() // Yapılandırıcı
            {
                kuyrukListe = new List<int>();
                elemanSay = 0;
            }
            public void enque(int j) // Kuyruk sonuna eleman ekler
            {
                kuyrukListe.Add(j);
                elemanSay++;
            }
            public int deque() // Kuyruğun başından bir eleman çıkarır
            {
                int temp = kuyrukListe[0];
                kuyrukListe.RemoveAt(0);
                elemanSay--;
                return temp;
            }
            public bool bosMu()
            {
                return (kuyrukListe.Count == 0);
            }
        }

        public class YazıcıPQ
        {
            private List<int> kuyrukListe;
            public int elemanSay;

            public YazıcıPQ() // Yapılandırıcı
            {
                kuyrukListe = new List<int>();
                elemanSay = 0;
            }
            public void enque(int j)
            {
                if (kuyrukListe.Count == 0)
                {
                    kuyrukListe.Add(j);
                    elemanSay++;
                }
                else
                {
                    for (int i = 0; i < kuyrukListe.Count; i++)
                    {
                        if (kuyrukListe[kuyrukListe.Count - 1] < j)
                        {
                            kuyrukListe.Insert(kuyrukListe.Count, j);
                            elemanSay++;
                            break;
                        }

                        if (kuyrukListe[i] >= j)
                        {
                            kuyrukListe.Insert(i, j);
                            elemanSay++;
                            break;
                        }
                    }
                }
            }
            public int deque() // Kuyruğun başından bir eleman çıkarır
            {
                int temp = kuyrukListe[0];
                kuyrukListe.RemoveAt(0);
                elemanSay--;
                return temp;
            }
            public bool bosMu()
            {
                return (kuyrukListe.Count == 0);
            }
        }

        public class YazıcıRR
        {
            private List<KullanıcıRR> kuyrukListe;
            public int elemanSay;

            public YazıcıRR() // Yapılandırıcı
            {
                kuyrukListe = new List<KullanıcıRR>();
                elemanSay = 0;
            }

            public void enque(int j, int indis) // Kuyruk sonuna eleman ekler
            {
                KullanıcıRR işlem = new KullanıcıRR();
                işlem.kullanıcıAdı = "Kullanıcı " + (indis + 1);
                işlem.sayfaSayısı = j;
                kuyrukListe.Add(işlem);
                elemanSay++;
            }

            public Tuple<int, string> deque() // Kuyruğun başından bir eleman çıkarır
            {
                int temp = kuyrukListe[0].sayfaSayısı;
                string isim;

                if (temp > 40)
                {
                    int x = temp - 40;
                    temp = 40;
                    KullanıcıRR artanİşlem = new KullanıcıRR();
                    artanİşlem.sayfaSayısı = x;
                    artanİşlem.kullanıcıAdı = kuyrukListe[0].kullanıcıAdı;
                    kuyrukListe.Add(artanİşlem);
                }
                else
                {
                    elemanSay--;
                }

                isim = kuyrukListe[0].kullanıcıAdı;
                kuyrukListe.RemoveAt(0);
                return Tuple.Create(temp, isim);
            }

            public bool bosMu()
            {
                return (kuyrukListe.Count == 0);
            }
        }

        static void Main(string[] args)
        {
            string[] isimler = { "Kullanıcı 1", "Kullanıcı 2", "Kullanıcı 3", "Kullanıcı 4", "Kullanıcı 5", "Kullanıcı 6", "Kullanıcı 7", "Kullanıcı 8", "Kullanıcı 9" };
            int[] sayfalar = { 21, 27, 41, 15, 3, 35, 43, 12, 17 };
            int seçim = 0;
            int[] randomSayfaSayilari = new int[25];
            string[] randomİsİsimleri = new string[25];
            int randomSayfa = 0;

            YazıcıFIFO gidenFIFO = new YazıcıFIFO();
            YazıcıPQ gidenPQ = new YazıcıPQ();
            YazıcıRR gidenRR = new YazıcıRR();
            YazıcıRR gidenRR2 = new YazıcıRR();

            List<Kullanıcı> kullanıcılarFIFO = new List<Kullanıcı>();
            List<Kullanıcı> kullanıcılarPQ = new List<Kullanıcı>();
            List<Kullanıcı> randomKuyruk = new List<Kullanıcı>();
            List<Kullanıcı> randomKuyruk2 = new List<Kullanıcı>();
            List<Kullanıcı> kullanıcılarRR = new List<Kullanıcı>();
            List<Kullanıcı> kullanıcılarRR2 = new List<Kullanıcı>();
            List<Kullanıcı> randomKuyrukRR = new List<Kullanıcı>();

            Console.WriteLine("Belgeler sadece YAZICIFIF0'ya gönderildiğinde :");
            YazıcıFIF0hesapla(sayfalar, isimler, kullanıcılarFIFO, gidenFIFO, 1); // dizideki belgeler sadece yazıcı fifo'ya gönderilir
            Console.WriteLine("Belgeler sadece YAZICIPQ'ya gönderildiğinde :");
            YazıcıPQhesapla(sayfalar, isimler, kullanıcılarPQ, gidenPQ, 1); //  // dizideki belgeler sadece yazıcı pq'ya gönderilir

            Console.WriteLine("Belgeler her iki yazıcıdan birine random gönderildiğinde :");
            for (int i = 0; i < sayfalar.Length; i++)// random ile ya fıfo ya da pqya yollanacak
            {
                seçim = sayi.Next(0, 2);
                if (seçim == 1)
                {
                    gidenFIFO.enque(sayfalar[i]);
                }
                else
                {
                    gidenPQ.enque(sayfalar[i]);
                }
            }

            randomKuyruk = YazıcıFIF0hesapla(sayfalar, isimler, randomKuyruk, gidenFIFO, 0);
            randomKuyruk2 = YazıcıPQhesapla(sayfalar, isimler, randomKuyruk2, gidenPQ, 0);
            kazançHesapla(kullanıcılarFIFO, kullanıcılarPQ, randomKuyruk, randomKuyruk2);
            Console.ReadKey();

            List<Kullanıcı> randomIslerFIFO = new List<Kullanıcı>();
            List<Kullanıcı> randomIslerPQ = new List<Kullanıcı>();

            for (int k = 0; k < 25; k++) // for döngüsü 25 kere döner, 25 tane random iş üretilir
            {
                randomSayfa = sayi.Next(1, 101);
                randomSayfaSayilari[k] = randomSayfa;
                randomİsİsimleri[k] = "Kullanıcı " + (k + 1);
            }

            Console.WriteLine("\n25 TANE RANDOM İŞ ÜRETİLDİ !\nİŞ İSİMLERİ  SAYFA SAY.");
            for (int l = 0; l < 25; l++) //
            {
                Console.WriteLine("{0,-9} --> {1,-5}", randomİsİsimleri[l], randomSayfaSayilari[l]); //Sayfa sayıları, iş numaraları ile birlikte ekrana yazdırılır
            }

            Console.WriteLine("\nRandom üretilen sayfa sayıları sadece YAZICIFIF0'ya gönderildiğinde :");
            YazıcıFIF0hesapla(randomSayfaSayilari, randomİsİsimleri, randomIslerFIFO, gidenFIFO, 1); // random üretilen belgeler sadece yazıcı fifo'ya gönderilir
            Console.WriteLine("\nRandom üretilen sayfa sayıları sadece YAZICIPQ'ya gönderildiğinde :");
            YazıcıPQhesapla(randomSayfaSayilari, randomİsİsimleri, randomIslerPQ, gidenPQ, 1);  // random üretilen belgeler sadece yazıcı pq'ya gönderilir

            List<Kullanıcı> randomKuyrukİş = new List<Kullanıcı>();
            List<Kullanıcı> randomKuyrukİş2 = new List<Kullanıcı>();

            Console.WriteLine("\nRandom üretilen sayfa sayıları her iki yazıcıdan birine random gönderildiğinde :");
            for (int i = 0; i < randomSayfaSayilari.Length; i++)// random üretilen sayfa sayıları, random olarak ya fıfo ya da pqya yollanacak
            {
                seçim = sayi.Next(0, 2);
                if (seçim == 1)
                {
                    gidenFIFO.enque(randomSayfaSayilari[i]);
                }
                else
                {
                    gidenPQ.enque(randomSayfaSayilari[i]);
                }
                gidenRR2.enque(randomSayfaSayilari[i], i);
            }

            randomKuyrukİş = YazıcıFIF0hesapla(randomSayfaSayilari, randomİsİsimleri, randomKuyrukİş, gidenFIFO, 0);
            randomKuyrukİş2 = YazıcıPQhesapla(randomSayfaSayilari, randomİsİsimleri, randomKuyrukİş2, gidenPQ, 0);
            kazançHesapla(randomIslerFIFO, randomIslerPQ, randomKuyrukİş, randomKuyrukİş2);

            Console.ReadKey();
            Console.WriteLine("\nRandom üretilen sayfa sayıları YAZICIRR'ye gönderildiğinde :");
            YazıcıRRhesapla(randomSayfaSayilari, randomİsİsimleri, randomKuyrukRR, gidenRR2, 0);//25 iş için 
            işlemSüresiArtır(randomKuyrukRR, randomSayfaSayilari.Length);
            kazançRRHesapla(randomIslerFIFO, randomIslerPQ, randomKuyrukRR);

            //enUygunYazıcıyıBul(sayfalar, isimler);

            Console.ReadKey();

        }

        public static List<Kullanıcı> YazıcıFIF0hesapla(int[] sayfaSayilari, string[] kullaniciIsimleri, List<Kullanıcı> kullanıcıFIFO, YazıcıFIFO FIFO, int kontrol)
        {
            float toplam = 0, topSüre = 0;
            int sayac = 0, indis = 0, sayfaSayısı;

            List<int> listeFIFO = new List<int>();
            listeFIFO.AddRange(sayfaSayilari);

            if (kontrol == 1) // random olarak yollanan belgelerde kontrol 0 olur mainde kuyruğa enque ile eklenmiştir; if true dönüyorsa enque ile sayfa sayıları eklenir
            {
                for (int l = 0; l < sayfaSayilari.Length; l++)
                    FIFO.enque(sayfaSayilari[l]);
            }

            sayac = FIFO.elemanSay;

            Console.WriteLine("KULLANICI İSMİ  İŞLEM SÜRESİ(İTS)\n--------------  ----------------");

            for (int i = 0; i < sayac; i++)
            {
                Kullanıcı gönderen = new Kullanıcı();
                sayfaSayısı = FIFO.deque();
                toplam += sayfaSayısı;

                for (int y = 0; y < listeFIFO.Count; y++)
                {
                    if (sayfaSayısı == listeFIFO[y])
                    {
                        listeFIFO[y] = 0;
                        indis = y;
                        break;
                    }
                }

                gönderen.isim = kullaniciIsimleri[indis];
                gönderen.işlemSüresi = toplam / 6;
                gönderen.sayfaSayisi = sayfaSayısı;
                kullanıcıFIFO.Add(gönderen);

                topSüre += kullanıcıFIFO[i].işlemSüresi;

                Console.Write("{0,-6}", kullanıcıFIFO[i].isim);
                Console.WriteLine("  -->  {0:0.0} ", kullanıcıFIFO[i].işlemSüresi);
            }
            Console.WriteLine("Ortalama işlem süresi(OİTS) : {0:0.0} ", (topSüre / sayac));
            return kullanıcıFIFO;
        }

        public static List<Kullanıcı> YazıcıPQhesapla(int[] sayfaSayilari, string[] kullaniciIsimleri, List<Kullanıcı> kullanıcıPQ, YazıcıPQ PQ, int kontrol)
        {
            int indis = 0, sayfaSayısı, sayac = 0;
            float topSüre = 0, toplam = 0;

            List<int> listePQ = new List<int>();
            listePQ.AddRange(sayfaSayilari);

            if (kontrol == 1) // random olarak yollanan belgelerde kontrol 0 olur mainde kuyruğa enque ile eklenmiştir; if true dönüyorsa enque ile sayfa sayıları eklenir
            {
                for (int l = 0; l < sayfaSayilari.Length; l++)
                    PQ.enque(sayfaSayilari[l]);
            }

            sayac = PQ.elemanSay;
            Console.WriteLine("KULLANICI İSMİ  İŞLEM SÜRESİ(İTS)\n--------------  ----------------");

            for (int k = 0; k < sayac; k++)
            {
                Kullanıcı gönderen = new Kullanıcı();
                sayfaSayısı = PQ.deque();
                toplam += sayfaSayısı;

                for (int y = 0; y < listePQ.Count; y++)
                {
                    if (sayfaSayısı == listePQ[y])
                    {
                        listePQ[y] = 0;
                        indis = y;
                        break;
                    }
                }

                gönderen.isim = kullaniciIsimleri[indis];
                gönderen.işlemSüresi = (toplam) / 10;
                gönderen.sayfaSayisi = sayfaSayısı;
                kullanıcıPQ.Add(gönderen);

                topSüre += kullanıcıPQ[k].işlemSüresi;

                Console.Write(kullanıcıPQ[k].isim);
                Console.Write(" --> {0:0.0}", kullanıcıPQ[k].işlemSüresi);
                Console.WriteLine();
            }

            Console.WriteLine("Ortalama işlem süresi(OİTS) : {0:0.0} \n", (topSüre / sayac));
            return kullanıcıPQ;
        }

        public static void kazançHesapla(List<Kullanıcı> kullanıcıFIFO, List<Kullanıcı> kullanıcıPQ, List<Kullanıcı> randomFIFO, List<Kullanıcı> randomPQ)
        {
            List<SüreKazancı> kazançListesi = new List<SüreKazancı>();

            for (int i = 0; i < kullanıcıFIFO.Count; i++)
            {
                SüreKazancı kazanç = new SüreKazancı();
                kazançListesi.Add(kazanç);
                kazançListesi[i].isim = kullanıcıFIFO[i].isim;

                for (int j = 0; j < kullanıcıPQ.Count; j++)//PQ kuyruğunda FIFO kuyruğuna göre kazanç var mı hesaplanır.
                {
                    if (kullanıcıFIFO[i].sayfaSayisi == kullanıcıPQ[j].sayfaSayisi && kullanıcıPQ[j].işlemSüresi < kullanıcıFIFO[i].işlemSüresi)
                    {
                        kazançListesi[i].kazançPQ = (kullanıcıFIFO[i].işlemSüresi - kullanıcıPQ[j].işlemSüresi);
                    }
                }
            }

            for (int i = 0; i < kullanıcıFIFO.Count; i++)//RandomFIFO kuyruğunda FIFO kuyruğuna göre kazanç var mı hesaplanır.
            {
                for (int j = 0; j < randomFIFO.Count; j++)
                {
                    if (kullanıcıFIFO[i].sayfaSayisi == randomFIFO[j].sayfaSayisi && randomFIFO[j].işlemSüresi < kullanıcıFIFO[i].işlemSüresi)
                    {
                        kazançListesi[i].kazançRandomFIFO = (kullanıcıFIFO[i].işlemSüresi - randomFIFO[j].işlemSüresi);
                    }
                }
            }

            for (int i = 0; i < kullanıcıFIFO.Count; i++)//RandomPQ kuyruğunda FIFO kuyruğuna göre kazanç var mı hesaplanır.
            {
                for (int j = 0; j < randomPQ.Count; j++)
                {
                    if (kullanıcıFIFO[i].sayfaSayisi == randomPQ[j].sayfaSayisi && randomPQ[j].işlemSüresi < kullanıcıFIFO[i].işlemSüresi)
                    {
                        kazançListesi[i].kazançRandomPQ = (kullanıcıFIFO[i].işlemSüresi - randomPQ[j].işlemSüresi);
                    }
                }
            }

            Console.WriteLine("--İSİM----------PQ-----RANDOM FIFO----RANDOM PQ");
            for (int i = 0; i < kazançListesi.Count; i++)
            {
                if (kazançListesi[i].kazançPQ > 0 || kazançListesi[i].kazançRandomFIFO > 0 || kazançListesi[i].kazançRandomPQ > 0)
                    Console.WriteLine("{0,-8}    {1,-5 :0.0}   {2,-12:0.0}   {3,-5:0.0}", kazançListesi[i].isim, kazançListesi[i].kazançPQ, kazançListesi[i].kazançRandomFIFO, kazançListesi[i].kazançRandomPQ);
            }
        }

        public static List<Kullanıcı> YazıcıRRhesapla(int[] sayfaSayilari, string[] kullaniciIsimleri, List<Kullanıcı> kullanıcıRR, YazıcıRR RR, int kontrol)
        {
            float toplam = 0, topSüre = 0;
            int sayac = 0, i = 0;

            if (kontrol == 1)
            {
                for (int l = 0; l < sayfaSayilari.Length; l++)
                    RR.enque(sayfaSayilari[l], l);
            }
            Console.WriteLine("KULLANICI İSMİ  İŞLEM SÜRESİ(İTS)\n--------------  ----------------");

            while (!RR.bosMu())
            {
                Kullanıcı gönderen = new Kullanıcı();
                sayac++;
                var tuple = RR.deque();
                toplam += tuple.Item1;

                gönderen.isim = tuple.Item2;
                gönderen.işlemSüresi = toplam / 6;
                gönderen.sayfaSayisi = tuple.Item1;
                kullanıcıRR.Add(gönderen);

                topSüre += kullanıcıRR[i].işlemSüresi;

                Console.Write("{0,-6}", kullanıcıRR[i].isim);
                Console.WriteLine(" --> {0:0.0} ", kullanıcıRR[i].işlemSüresi);
                i++;
            }

            Console.WriteLine("Ortalama işlem süresi: {0:0.0} \n", (topSüre / sayac));
            Console.ReadLine();

            return kullanıcıRR;
        }

        public static List<Kullanıcı> işlemSüresiArtır(List<Kullanıcı> kullanıcıRRList, int gelenSayfaSay)
        {
            int m = kullanıcıRRList.Count;
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = gelenSayfaSay; j < kullanıcıRRList.Count; j++)
                {
                    if ((kullanıcıRRList[i].isim.Equals(kullanıcıRRList[j].isim)))
                    {
                        kullanıcıRRList[i].işlemSüresi += kullanıcıRRList[j].işlemSüresi;
                        kullanıcıRRList.RemoveAt(j);
                    }
                }
            }

            return kullanıcıRRList;
        }

        public static void kazançRRHesapla(List<Kullanıcı> kullanıcıFIFO, List<Kullanıcı> kullanıcıPQ, List<Kullanıcı> kullanıcıRR)
        {
            List<SüreKazancı> kazançListesi = new List<SüreKazancı>();

            for (int i = 0; i < kullanıcıRR.Count; i++)
            {
                SüreKazancı kazanç = new SüreKazancı();
                kazançListesi.Add(kazanç);
                kazançListesi[i].isim = kullanıcıRR[i].isim;

                for (int j = 0; j < kullanıcıPQ.Count; j++)
                {
                    if (kullanıcıRR[i].isim == kullanıcıPQ[j].isim && kullanıcıPQ[j].işlemSüresi < kullanıcıRR[i].işlemSüresi)
                    {
                        kazançListesi[i].kazançPQ = (kullanıcıRR[i].işlemSüresi - kullanıcıPQ[j].işlemSüresi);
                    }
                }
            }

            for (int i = 0; i < kullanıcıRR.Count; i++)
            {
                for (int j = 0; j < kullanıcıFIFO.Count; j++)
                {
                    if (kullanıcıRR[i].isim == kullanıcıFIFO[j].isim && kullanıcıFIFO[j].işlemSüresi < kullanıcıRR[i].işlemSüresi)
                    {
                        kazançListesi[i].kazançFIFO = (kullanıcıRR[i].işlemSüresi - kullanıcıFIFO[j].işlemSüresi);
                    }
                }
            }

            Console.WriteLine("--İSİM---------FIFO-------PQ");
            for (int i = 0; i < kazançListesi.Count; i++)
            {
                if (kazançListesi[i].kazançFIFO > 0 || kazançListesi[i].kazançPQ > 0)
                    Console.WriteLine("{0,-8}    {1,-5 :0.0}   {2,-12:0.0} ", kazançListesi[i].isim, kazançListesi[i].kazançFIFO, kazançListesi[i].kazançPQ);
            }
        }

        public static void enUygunYazıcıyıBul(int[] sayfaSayilari, string[] işİsimleri)
        {
            float toplam = 0, ortSüre = 0, kontrolSüre = 1000;

            YazıcıFIFO FIFO = new YazıcıFIFO();
            YazıcıPQ PQ = new YazıcıPQ();
            YazıcıFIFO FIFO2 = new YazıcıFIFO();
            YazıcıPQ PQ2 = new YazıcıPQ();

            List<Kullanıcı> listeFIFO = new List<Kullanıcı>();
            List<Kullanıcı> listePQ = new List<Kullanıcı>();
            List<Kullanıcı> enİyiFIFO = new List<Kullanıcı>();
            List<Kullanıcı> enİyiPQ = new List<Kullanıcı>();

            for (int i = 0; i < sayfaSayilari.Length - 1; i++)
            {
                for (int j = i; j < sayfaSayilari.Length; j++)
                {
                    List<int> sayfalar = new List<int>();
                    sayfalar.AddRange(sayfaSayilari);

                    PQ.enque(sayfalar[i]);
                    FIFO2.enque(sayfalar[i]);
                    sayfalar.RemoveAt(i);

                    PQ.enque(sayfalar[j]);
                    FIFO2.enque(sayfalar[j]);
                    sayfalar.RemoveAt(j);

                    for (int k = 0; k < sayfalar.Count; k++)
                    {
                        FIFO.enque(sayfalar[k]);
                        PQ2.enque(sayfalar[k]);
                    }

                    YazıcıFIF0hesapla(sayfaSayilari, işİsimleri, listeFIFO, FIFO, 0);
                    YazıcıPQhesapla(sayfaSayilari, işİsimleri, listePQ, PQ, 0);

                    for (int y = 0; y < listeFIFO.Count; y++)
                        toplam += listeFIFO[y].işlemSüresi;

                    for (int y = 0; y < listePQ.Count; y++)
                        toplam += listePQ[y].işlemSüresi;

                    ortSüre = toplam / sayfaSayilari.Length;

                    if (ortSüre < kontrolSüre)
                    {
                        kontrolSüre = ortSüre;
                        enİyiFIFO = listeFIFO;
                        enİyiPQ = listePQ;
                    }

                    listePQ.Clear();
                    listeFIFO.Clear();
                    toplam = 0;

                    YazıcıFIF0hesapla(sayfaSayilari, işİsimleri, listeFIFO, FIFO2, 0);
                    YazıcıPQhesapla(sayfaSayilari, işİsimleri, listePQ, PQ2, 0);

                    for (int y = 0; y < listeFIFO.Count; y++)
                        toplam += listeFIFO[y].işlemSüresi;

                    for (int y = 0; y < listePQ.Count; y++)
                        toplam += listePQ[i].işlemSüresi;

                    ortSüre = toplam / sayfaSayilari.Length;

                    if (ortSüre < kontrolSüre)
                    {
                        kontrolSüre = ortSüre;
                        enİyiFIFO = listeFIFO;
                        enİyiPQ = listePQ;
                    }
                    Console.WriteLine("FIFO'ya Gidenler");
                    for (int y = 0; y < enİyiFIFO.Count; y++)
                        Console.WriteLine(enİyiFIFO[y].sayfaSayisi);

                    Console.WriteLine("PQ'ya Gidenler");
                    for (int y = 0; y < enİyiPQ.Count; y++)
                        Console.WriteLine(enİyiPQ[y].sayfaSayisi);

                }
            }
        }
    }
}
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;
using System.Numerics;

namespace Home
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int milliseconds = 5000;


            string path = @"C:\Users\Никита\Desktop\fakk\HomeWork\Home`\ДЗ.txt";
            string[] s = File.ReadLines(path).Select(x => x.ToString()).ToArray(); // все строки
            
            string[] s1 = s[0].Split(";").ToArray(); // магазин сладостей из файла

            CandyStore candyStore = new CandyStore(s1[0], s1[1], (Price)int.Parse(s1[2])); // создал Магазин сладостей
            candyStore.BuyCandyes(45.5); //магазин купил конфет
            Console.WriteLine($"count of kilograms of candyes: {candyStore.GetCountOfCandyes}"); // запрашиваю кол-во конфет
            candyStore.ThrowOutCandyes(24.5); // выбрасываю конфеты
            Console.WriteLine($"name of store: {candyStore.GetName}"); // запрашиваю имя магазина сладостей (МС)
            Console.WriteLine($"age store: {candyStore.GetAge}"); // запрашиваю возвраст МС
            Console.WriteLine($"price: {candyStore.GetPrice}"); // запрашиваю цены МС
            candyStore.DirtyUp();
            Console.WriteLine($"до уборки: {candyStore.GetLevelOfDirty}");
            candyStore.CleanUp(); // Убираюсь в МС
            Console.WriteLine($"После уборки: {candyStore.GetLevelOfDirty}");

            Thread.Sleep(milliseconds);
            Console.WriteLine();
            string[] s2 = s[1].Split(";").ToArray();
            Worker Karch = candyStore.EmployWorker(s2[0], s2[1], s2[2], int.Parse(s2[3]), candyStore); // создал работника из файла
            Karch.SayHello();
            Console.WriteLine($"Name:{Karch.GetFullName}");
            Console.WriteLine($"адресс работы: {Karch.GetAdressOfWork}");
            string na = Karch.GetAll;
            Karch.GetAll = " 314145";
            //Karch.GoCrazy(); // чел сошел с ума... или же приисполнился??
            //
            Console.WriteLine($"{na} 1234567890");
            Console.WriteLine($"{Karch.GetAll} 123456790-");
            Thread.Sleep(milliseconds);
            Console.WriteLine();
            string[] s3 = s[2].Split(";").ToArray(); // Данисимус

            Buyer Daniil = new Buyer(s3[0], s3[1], int.Parse(s3[2]), 5400);
            Console.WriteLine($"У Дани столько денег: {Daniil.GetMoney}");
            Console.WriteLine("Он сходил в магазин сладостей...");
            Daniil.BuyCandy(candyStore, 1); // у Данька был тяжелый день, он решил купить конфет(вообще он хотел пива, но ему нет 18, поэтому конфет)
            Console.WriteLine($"И теперь у Даниила осталось {Daniil.GetMoney}р., а до стипендии еще далеко..."); // Теперь Даня еще больше жалеет, что ему нет 18...

            Console.WriteLine();
            // Mac
            Thread.Sleep(milliseconds);

            string[] s4 = s[3].Split(";").ToArray(); // мало чем отличается от магазина сладостей под капотом
            Mac mac = new Mac(s4[0], s4[1], double.Parse(s4[2]), byte.Parse(s4[3]), int.Parse(s4[4]), (Price)int.Parse(s4[5]));
            Console.WriteLine($"Создал мак, с очень оригинальным названием:{mac.GetName}");
            Console.WriteLine($"Цены там: {mac.GetPrice}");
            Console.WriteLine("Создаем нового работника мака и покупателя");

            Console.WriteLine();
            string[] s5 = s[4].Split(";").ToArray();
            Worker Maria = mac.EmployWorker(s4[0], s4[1], int.Parse(s4[2]), mac);

            string[] s6 = s[5].Split(";").ToArray(); 
            Buyer Vitalik = new Buyer(s6[0], s6[1], int.Parse(s6[2]), double.Parse(s6[3])); // Виталик))
            Console.WriteLine($"количество бургеров до Виталия: {mac.GetCountOfBurgers}");
            Vitalik.BuyBurgers(mac, 5); // Виталий купил бургеры
            Console.WriteLine($"количество бургеров После: {mac.GetCountOfBurgers}");
            Console.WriteLine();
            Thread.Sleep(milliseconds);
            Console.WriteLine($"Згрязнение до Виталия {mac.GetLevelOfDirty}");
            Vitalik.DirtyUp(mac);
            Console.WriteLine($"Згрязнение ПОСЛЕ Виталия {mac.GetLevelOfDirty}");
            mac.CleanUp();
            Console.WriteLine($"Магазин убрали, уровень загрязнения:{mac.GetLevelOfDirty}") ;
        }
    }
    public class Worker
    {
        string name;
        string surname;
        string patronymic;
        string adressOfWork;
        int age;
        public Worker(string name, string surname, string patronymic, int age, Store store)
        {
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.age = age;
            adressOfWork = store.GetAdress;
        }
        public Worker(string name, string surname, int age, Store store)
        {
            this.name = name;
            this.age = age;
            this.surname = surname;
            adressOfWork = store.GetAdress;
        }
        public string GetAdressOfWork
        {
            get { return adressOfWork; }
            private set { adressOfWork = value; }
        }
        public string GetFullName
        { 
            //if(patronymic!=null)
            //{
                get { return $"{surname} {name} {patronymic}"; }
            //}
        }
        public string GetNameAndSurname
        {
            get { return $"{surname} {name}"; }
        }
        public string GetAll { get; set; }
        
        public string GetName
        {
            get { return name; }
        }
        public int GetAge
        {
            get { return age; }
        }
        public void SayHello()
        {
            Console.WriteLine($"Welcome! My name - {name}");
        }
        public void SayGoodBuy()
        {
            Console.WriteLine("Thank you for coming");
        }

        public void OrderIsReady(Buyer buyer)
        {
            Console.WriteLine($"Your Order Is Ready,{buyer.Name}");
        }
        public void Quit()
        {
            if(adressOfWork != null)
                adressOfWork = null;
            else
            {
                Console.WriteLine("Ты и так нигде не работаешь...");
            }
        }
        public void GoCrazy()
        {
            Console.WriteLine("Я в своем познании настолько преисполнился, " +
                "что я как будто бы уже\r\n\r\nсто триллионов миллиардов лет проживаю на триллионах и" +
                "\r\n\r\nтриллионах таких же планет, как эта Земля, мне этот мир абсолютно\r\n\r\nпонятен, " +
                "и я здесь ищу только одного - покоя, умиротворения и\r\n\r\nвот этой гармонии, от слияния с " +
                "бесконечно вечным, от созерцания\r\n\r\nвеликого фрактального подобия и от вот этого замечательного " +
                "всеединства\r\n\r\nсущества, бесконечно вечного, куда ни посмотри, хоть вглубь - бесконечно\r\n\r\nмалое, " +
                "хоть ввысь - бесконечное большое, понимаешь? А ты мне опять со\r\n\r\nсвоим вот этим, иди суетись дальше, " +
                "это твоё распределение, это\r\n\r\nтвой путь и твой горизонт познания и ощущения твоей природы, он\r\n\r\nнесоизмеримо " +
                "мелок по сравнению с моим, понимаешь? Я как будто бы уже\r\n\r\nдавно глубокий старец, бессмертный, ну или там уже почти " +
                "бессмертный,\r\n\r\nкоторый на этой планете от её самого зарождения, ещё когда только Солнце\r\n\r\nтолько-только сформировалось " +
                "как звезда, и вот это газопылевое облако,\r\n\r\nвот, после взрыва, Солнца, когда оно вспыхнуло, как звезда, " +
                "начало\r\n\r\nформировать вот эти коацерваты, планеты, понимаешь, я на этой Земле уже\r\n\r\nкак будто почти " +
                "пять миллиардов лет живу и знаю её вдоль и поперёк\r\n\r\nэтот весь мир, а ты мне какие-то... мне не важно" +
                " на твои тачки, на твои\r\n\r\nяхты, на твои квартиры, там, на твоё благо. Я был на этой\r\n\r\nпланете " +
                "бесконечным множеством, и круче Цезаря, и круче Гитлера, и круче\r\n\r\nвсех великих, понимаешь, был," +
                " а где-то был конченым говном, ещё хуже,\r\n\r\nчем здесь. Я множество этих состояний чувствую. " +
                "Где-то я был больше\r\n\r\nподобен растению, где-то я больше был подобен птице, там, червю, " +
                "где-то\r\n\r\nбыл просто сгусток камня, это всё есть душа, понимаешь? Она имеет грани\r\n\r\nподобия" +
                " совершенно многообразные, бесконечное множество. Но тебе этого\r\n\r\nне понять, поэтому ты езжай " +
                "себе , мы в этом мире как бы живем\r\n\r\nразными ощущениями и разными стремлениями, соответственно, " +
                "разное наше и\r\n\r\nместо, разное и наше распределение. Тебе я желаю все самые крутые тачки\r\n\r\nчтоб " +
                "были у тебя, и все самые лучше самки, если мало идей, обращайся ко мне, я тебе на каждую твою идею предложу " +
                "сотню триллионов, как всё делать. Ну а я всё, я иду как глубокий старец,узревший вечное, прикоснувшийся к " +
                "Божественному, сам стал богоподобен и устремлен в это бесконечное, и который в умиротворении, покое, гармонии, " +
                "благодати, в этом сокровенном блаженстве пребывает, вовлеченный во всё и во вся, понимаешь, вот и всё, в " +
                "этом наша разница. Так что я иду любоваться мирозданием, а ты идёшь преисполняться в ГРАНЯХ каких-то, вот " +
                "и вся разница, понимаешь, ты не зришь это вечное бесконечное, оно тебе не нужно. Ну зато ты, так сказать, " +
                "более активен, как вот этот дятел долбящий, или муравей, который очень активен в своей стезе, поэтому давай, " +
                "наши пути здесь, конечно, имеют грани подобия, потому что всё едино, но я-то тебя прекрасно понимаю, а вот ты" +
                " меня - вряд ли, потому что я как бы тебя в себе содержу, всю твою природу, она составляет одну маленькую там" +
                " песчиночку, от того что есть во мне, вот и всё, поэтому давай, ступай, езжай, а я пошел наслаждаться прекрасным " +
                "осенним закатом на берегу теплой южной реки. Всё, ступай, и я пойду.");
        }
    }
    public abstract class Store
    {
        protected Condition condition = Condition.open;
        protected string name;
        protected string adress;
        protected double square; //площадь
        protected byte levelOfDirty = 0;
        protected Price price;
        public Condition GetCondition
        {
            get { return condition; }
        }
        public string GetName { get { return name; } private set { name = value; } }
        public string GetAdress 
        { 
            get { return adress; } 
            private set { adress = value; } 
        }
        public double GetSquare 
        {
            get{ return square; }
            private set { square = value; } 
        }
        public byte  GetLevelOfDirty
        {
            get { return levelOfDirty; }
        }
        public Price GetPrice { get { return price; } private set {price = (Price)value; } }
        //internal Nullable SetCondition
        //{
        //    //private get { return condition; }
        //    set { (condition)1; }
        //}
        public void CleanUp()
        {
            levelOfDirty = 0;
        }
        public void DirtyUp()
        {
            Random rand = new Random();
            levelOfDirty += (byte)rand.Next(5,101);
        }
        public Worker EmployWorker(string name, string surname, string patronymic, int age, Store store)
        {
            Worker worker = new Worker(name, surname, patronymic, age, store);
            return worker;
        }
        public Worker EmployWorker(string name, string surname, int age, Store store)
        {
            Worker worker = new Worker(name, surname, age, store);
            return worker;
        }
        public void OpenStore()
        {
            condition = (Condition)1;
        }
        public void CloseStore()
        {
            condition = (Condition)0;
        }
    }
    public class CandyStore : Store
    {
        double countOfCandy;
        int age;
        public CandyStore(string adress, string name, double square, byte levelOfDirty, double countOfCandy, Price price)
        {
            this.adress = adress;
            this.name = name;
            this.square = square;
            this.levelOfDirty = levelOfDirty;
            this.countOfCandy = countOfCandy;
            this.price = price;
        }
        public CandyStore(string adress, string name, Price price)
        {
            this.adress = adress;
            this.name = name;
            this.price = price; 
        }
        public CandyStore()
        {
            this.name = "Unknown";
        }
        public double GetCountOfCandyes
        {
            get { return countOfCandy; }
        }
        public int GetAge
        {
            get { return age; }
            private set { age = value; }
        }
        public void BuyCandyes(double kilogram)
        {
            countOfCandy += kilogram;
        }
        public void ThrowOutCandyes(double kilograms = 1)
        {
            if(countOfCandy - kilograms < 0)
            {
                countOfCandy = 0;
            }
            else
            {
                countOfCandy -= kilograms;
            }
        }
        //public void DismissWorker(Worker worker)
        //{
        //    worker= null;
        //}
        
    }
    public class Buyer
    {
        string name;
        string surname;
        int age;
        double money;
        public Buyer(string name, string surname, int age, double money)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.money = money;
        }
        public Buyer(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
        public string Name
        {
            get { return name; }    
        }

        public string GetFullName
        {
            get { return $"{surname} {name}"; }
        }
        public double GetMoney
        {
            get { return money; }
        }
        public void DirtyUp(Store store)
        {
            store.DirtyUp();
        }
        public void BuyCandy(CandyStore store, double kilograms)
        {
            if(store.GetCondition == Condition.open)
            {
                if (money > kilograms * (int)(store.GetPrice) * 10)
                {
                    if (store.GetCountOfCandyes >= kilograms)
                    {
                        store.BuyCandyes((-1) * kilograms);
                        money -= kilograms * (int)(store.GetPrice) * 1000;
                    }
                    else
                    {
                        Console.WriteLine($"Извините, у нас нет столько конфет, но вы можете купить {store.GetCountOfCandyes} кг конфет");
                    }
                }
                else
                {
                    Console.WriteLine("У вас недостаточно средств...");
                }
            }
            else
            {
                Console.WriteLine("Магазин Закрыт(");
            }
        }
        public void BuyBurgers( Mac mac, int count)
        {
            if(mac.GetCondition == Condition.open)
            {
                if (money > count * (int)(mac.GetPrice))
                {
                    if (mac.GetCountOfBurgers >= count)
                    {
                        mac.SellBurgers(count);
                        money -= count * (int)(mac.GetPrice) * 1000;
                    }
                    else
                    {
                        Console.WriteLine($"Извините, у нас нет столько бургеров, но вы можете купить {mac.GetCountOfBurgers} бургеров");
                    }
                }
                else
                {
                    Console.WriteLine("У вас недостаточно средств...");
                }
            }
        }
        //public void BuyBurgers()
    }
    public class Mac:Store
    {
            
        int countOfBurgers;
        int age;
        public Mac(string adress, string name, double square, byte levelOfDirty, int countOfBurgers, Price price)
        {
            this.adress = adress;
            this.name = name;
            this.square = square;
            this.levelOfDirty = levelOfDirty;
            this.countOfBurgers = countOfBurgers;
            this.price = price;
        }
        public Mac(string adress, string name, Price price)
        {
            this.adress = adress;
            this.name = name;
            this.price = price;
        }
        public Mac()
        {
            this.name = "Unknown";
        }
        public int GetCountOfBurgers
        {
            get { return countOfBurgers; }
            private set { countOfBurgers = value; }
        }
        public int GetAge
        {
            get { return age; }
            private set { age = value; }
        }
        public void MakeBurgers( int count)
        {
            countOfBurgers += count;
        }
        public void ThrowOutBurgers(int count = 1)
        {
            countOfBurgers -= count;
        }
        public void SellBurgers(int count=1)
        {
            if(countOfBurgers >= count)
            {
                countOfBurgers -= count;
            }
            else
            {
                Console.WriteLine($"Извините, у нас нет столько бургеров :(\nНо мы можем продать вам {countOfBurgers} бургеров");
            }
        }
        //купить продукты
        //если продукты больше 0, то можно продать, иначе извините, у нас закончились продукты.
        //прайс = медиум
    }
    public enum Price
    {
        low = 1,
        medium = 2,
        hight = 3
    }
    public enum Condition
    {
        close = 0,
        open = 1
    }
}
using System;


namespace ClassWork
{
    class Program
    {
        static void Main()
        {
            
            Bank bank = new Bank(228, 120000, AccountType.Savings);
            Console.WriteLine(bank);
            bank.PutOnBalance();
            Console.WriteLine(bank);
            bank.PutOutBalance();
            Console.WriteLine(bank);
            Console.WriteLine();
            Building building = new Building(228, 100, 28, 1488, 7);
            Console.WriteLine($"Высота одного этажа: {building.FloorHeight(building.Height, building.Floor)} метра/метров\nKоличество квартир в подъезде: {building.ApartInEntrance(building.Apartment, building.Entrance)}\nKол-во квартир на этаже: {building.ApartOnFloor(building.Apartment, building.Entrance, building.Floor)}");
        }
    
    }
    enum AccountType { Current, Savings }
    class Bank
    {
        int AccountNumber;
        double Balance;
        AccountType Type;
        public Bank(int AccountNumber, double Balans, AccountType Type)
        {
            this.AccountNumber = AccountNumber;
            this.Balance = Balans;
            this.Type = Type;
        }
        public string GetAndSetAccountNumber { get; set; }
        public double GetAndSetBalance { get { return Balance; } set { Balance = value; } }
        public AccountType GetAndSetType { get; set; }
        public override string ToString() => $"AccountNumber - {AccountNumber}, Balans - {Balance}, Type - {Type}";

        static Random rand = new Random();
        private static int generic_number = rand.Next(0, 10000000);
        public int Generic
        {
            get { return generic_number; }
            set  {value = generic_number++;}
        }
        public void PutOnBalance()
        {
            Console.Write("Введите сумму для зачисления ");
            Balance += double.Parse(Console.ReadLine());
        }
        public void PutOutBalance()
        {
            Console.Write("Введите сумму для снятия ");
            try
            {
                double temp = Convert.ToDouble(Console.ReadLine());
                if (Balance >= temp)
                    Balance = Balance - temp;
                else
                {
                    Console.WriteLine("На вашем счёте недостаточно средств(...");
                }
            
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
    public class Building
    {
        int _buildingNumber;
        int _buildingHight;
        int _buildingFloor;
        int _buildingEntrance;
        int _buildingApartment;
        public Building(int number, int height, int floor, int aparts, int entrances)
        {
            _buildingNumber = number;
            _buildingHight = height;
            _buildingFloor = floor;
            _buildingEntrance =  entrances;
            _buildingApartment = aparts;
        }

        static Random rand = new Random();
        static int generic_number = rand.Next(0, 100);
        public int Generic
        {
            get { return generic_number; }
            set { value = generic_number++; }
        }

        public int Number
        {
            get { return _buildingNumber; }
            set { _buildingNumber = value; }
        }

        public int Height
        {
            get { return _buildingHight; }
            set { _buildingHight = value; }
        }

        public int Floor

        {
            get { return _buildingFloor; }
            set { _buildingFloor = value; }
        }

        public int Entrance

        {
            get { return _buildingEntrance; }
            set { _buildingEntrance = value; }
        }

        public int Apartment

        {
            get { return _buildingApartment; }
            set { _buildingApartment = value; }
        }

        
        public int FloorHeight(int height, int flors)
        {
            return height/flors;
        }
        public int ApartInEntrance(int Apart, int entrance)
        {
            return Apart / entrance;
        }
        public int ApartOnFloor(int Apart, int entrance, int floors)
        {
            return (Apart / entrance) / (floors - 1);
        }
    }
    

}
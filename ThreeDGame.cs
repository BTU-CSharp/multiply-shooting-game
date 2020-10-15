using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp123
{
    public class ThreeDGame
    {
        // 2 ობიექტი Player კლასიდან.
        Player player1;
        Player player2;


        public ThreeDGame() 
        {
            Console.WriteLine("player 1 please write a name. \n");
            string name1 = Console.ReadLine();
            this.player1 = new Player(name1, WeaponChoice());

            Console.WriteLine("player 2 please write a name. \n");
            string name2 = Console.ReadLine();
            this.player2 = new Player(name2, WeaponChoice());

        }

        public Weapon WeaponChoice() 
        {
            
// სხვადასხვა იარაღების შექმნა, რომლის არჩევაც მომხმარებელს შეეძლება.
            Knife greyKnife = new Knife("grey", 50);
            Knife blackKnife = new Knife("black", 90);
            Pistol Glock18 = new Pistol("Glock-18", 100, 5);
            Pistol DesertEagle = new Pistol("DesertEagle", 200, 5);
            Pistol DualBerettas = new Pistol("Dual Berettas", 75, 6);
            Bomb Grenade = new Bomb("Grenade", 300, "2");                                                       
            Bomb Smoke = new Bomb("Smoke", 0, "0");
            Bomb FlashBang = new Bomb("FlashBang", 0, "0.5");
            Sniper Awp = new Sniper("AWP", 450, 20, 1);
            Sniper Scout = new Sniper("Scout", 200, 20, 1);
            
            
            Console.WriteLine("choose weapon: \n\n greyKnife: 0 \n blackKnife: 1 \n Glock18: 2 \n DesertEagle: 3 \n DualBerettas: 4 \n Grenade: 5 \n Smoke: 6 \n FlashBang: 7 \n Awp: 8 \n Scout: 9 \n");



            List<Weapon> mainList = new List<Weapon>();

            mainList.Add(greyKnife);
            mainList.Add(blackKnife);
            mainList.Add(Glock18);
            mainList.Add(DesertEagle);
            mainList.Add(DualBerettas);
            mainList.Add(Grenade);
            mainList.Add(Smoke);
            mainList.Add(FlashBang);
            mainList.Add(Awp);
            mainList.Add(Scout);


            // ლისტიდან იარაღის ნუმერაციის არჩევა
            string infoNumber = Console.ReadLine();

            // თუ მომხმარებელმა შეიყვანა რიცხვის მაგივრად სხვა რამე, ეს while დაიჭერს ერორს 
            // და მომხმარებელს მოთხოვს შეიყვანოს რიცხვი
            while (!int.TryParse(infoNumber, out int _))
            {
                Console.WriteLine("please input number! not other symbols! \n");
                infoNumber = Console.ReadLine();
            }


            // თუ მომხმარებელმა შეიყვანა ისეთი რიცხვი რომლითაც იარაღის არჩევა შეუძლებელია, მომხმარებელს მიუვა ამასთან 
            // დაკავშირებით შეტყობინება, და შესაძლებელია თავიდან იარაღის ნუმერაციით არჩევა.
            if (Int32.Parse(infoNumber) > mainList.Count)
            {
                Console.WriteLine("please write correct number to choose weapon. \n");
                infoNumber = Console.ReadLine();
            }

    
            return mainList[Int32.Parse(infoNumber)];

        }

        // Battle ფუნქცია, რომელიც ავლენს თუ რომელმა მოთამაშებ გაიმარჯვა.
        public void Battle()
        {
            Console.WriteLine($"{player1.name}-s score: " + this.player1.weapon.TrueDamage());
            Console.WriteLine($"{player2.name}-s score: " + this.player2.weapon.TrueDamage());
            if (this.player1.weapon.TrueDamage() > this.player2.weapon.TrueDamage())
            {
                Console.WriteLine($"{player1.name} is winner \n");
            }
            else if (this.player1.weapon.TrueDamage() < this.player2.weapon.TrueDamage())
            {
                Console.WriteLine($"{player2.name} is winner \n");
            }
            else if (this.player1.weapon.TrueDamage() == this.player2.weapon.TrueDamage())
            {
                Console.WriteLine($"it is a draw \n");
            }
            else
            { 
                Console.WriteLine("Something wrong! \n");
            }

        }
    }
    // Player კლასი, რომლის მეშვეობითაც უნდა აღიწეროს ორი მოთამაშე. ხოლო მოთამაშეებმა აუცილებლად უნდა შეიყვანონ საკუთარი 
    // სახელი და იარაღი - სურვილისამებრ.
    class Player
    {
        public string name;
        public Weapon weapon;

        public Player(string name, Weapon weapon) 
        {
            this.name = name;
            this.weapon = weapon;
        }
    }

    // აბსტრაქტული კლასი რომელიც მოიცავს სახელს დიმეიჯს და აბსტრაკტ მეთოდს, 
    // რომელმაც უნდა დააბრუნოს თრუდემეიჯი შვილობილ კლასებში.    
    public abstract class Weapon
    {
        public string name;
        public int damage;
        public abstract int TrueDamage();
    }


    // Bomb კლასი
    public class Bomb : Weapon
    {
        string readyToExplosion;
        public Bomb(string name, int damage, string explosion) 
        {
            this.name = name;
            this.damage = damage;
            this.readyToExplosion = explosion;
        }

        public override int TrueDamage()
        {
            int truedamage = (int)(damage);

            return truedamage;
        }
    }


    // Knife კლასი
    public class Knife : Weapon
    {
        public Knife(string name, int damage) 
        {
            this.name = name;
            this.damage = damage;

        }
        public override int TrueDamage()
        {
            int truedamage = (int)(damage);
            
            return truedamage;
        }
    }


    // Pistol კლასი
    public class Pistol : Weapon
    {
        public double weight;

        public Pistol(string name, int damage, double weight) 
        {
            this.name = name;
            this.damage = damage;
            this.weight = weight;
        }

        public override int TrueDamage()
        {
            double weighting = weight / 10.0;
            double damage = (int)(this.damage  * weighting);

            return (int)damage;
        }
    }



    //Sniper კლასი
    public class Sniper : Weapon
    {
        int weight;
        double enlargement;

        public Sniper(string name, int damage, int weight, double enlargement)
        {
            this.name = name;
            this.damage = damage;
            this.weight = weight;
            this.enlargement = enlargement;
        }

        public override int TrueDamage()
        {
            double weighting = weight / 10.0;
            double damagee = (int)((this.damage * weighting) * enlargement);


            return (int)damagee;
        }
    }

}

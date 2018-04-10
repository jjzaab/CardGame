using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] playerList = new Player[50];
            for (int i = 0; i < playerList.Length; i++)
            {
                playerList[i] = new Player();
                //Console.WriteLine("Name: " + playerList[i].Name);
                //Console.WriteLine("Health: " + playerList[i].Health);
                //Console.WriteLine("Attack: " + playerList[i].Attack);
            }
            Console.WriteLine("Name: " + playerList[0].Name);
            Console.WriteLine("Health: " + playerList[0].Health);
            Console.WriteLine("Attack: " + playerList[0].Attack);
            Console.WriteLine("Name: " + playerList[1].Name);
            Console.WriteLine("Health: " + playerList[1].Health);
            Console.WriteLine("Attack: " + playerList[1].Attack);
            while (playerList[1].Health > 0)
            {
                playerList[0].ATK(playerList[1]);
            }
            Console.WriteLine("Player 0 attacks player 1");
            Console.WriteLine("Name: " + playerList[1].Name);
            Console.WriteLine("Health: " + playerList[1].Health);


            Console.ReadLine();
        }
    }

    public class Player : Buff
    {
        string name;
        string vowels = "AEIOUY";
        string consonants = "BCDFGHJKLMNPQRSTVWXZ";
        int health;
        int attack;
        static Random rand = new Random();

        public string Name { get { return name; } }
        public int Health { get { return health; } }
        public int Attack { get { return attack; } }

        public Player()
        {
            health = HealthGen();
            attack = AttackGen();
            name = NameGen();
        }
        static int HealthGen()
        {
            return rand.Next(100, 150);
        }

        static int AttackGen()
        {
            return rand.Next(10, 20);
        }

        string NameGen()
        {
            StringBuilder sb = new StringBuilder();
            int nameLength = rand.Next(2, 6);
            for (int i = 0; i < nameLength; i++)
            {
                sb.Append(consonants[rand.Next(consonants.Length)]);
                sb.Append(vowels[rand.Next(vowels.Length)]);
            }
            return sb.ToString();
        }

        public void ATK(Player player)
        {
            if (player.Health <= 0)
                Console.WriteLine(player.Name + " has died");
            else
                player.health -= attack + AtkBuff();
        }

        #region Buff Interface
        public int AtkBuff()
        {
            return rand.Next(1, 10);
        }

        public void AtkDeBuff()
        {

        }
        #endregion
    }

    public interface Buff
    {
        int AtkBuff();
        void AtkDeBuff();
    }
}

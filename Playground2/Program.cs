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
            //Console.SetWindowSize(64, 30);
            //Console.Clear();
            //Console.SetCursorPosition(0, 0);
            //Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.MoveBufferArea(0, 1, 10, 10, 2, 0, ' ', ConsoleColor.Red, ConsoleColor.White);
            //Console.MoveBufferArea(15, 1, 10, 10, 17, 0, ' ', ConsoleColor.Red, ConsoleColor.White);

            //Console.SetCursorPosition(0, 23);
            // Console.ResetColor();
            Console.ReadLine();
            /*
            #region Game Loop
            // game loop
            bool gameRunning = true;
            ConsoleKeyInfo userKey;
            int locationX = 0;
            int locationY = 0;
            Console.SetWindowSize(65, 20);
            Console.BufferWidth = 65;
            Console.BufferHeight = 20;

            while (gameRunning)
            {

                if (Console.KeyAvailable)
                {
                    // We have input, process accordingly
                    userKey = Console.ReadKey(true);

                    switch (userKey.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            // See if we can move left
                            if (locationX > 0)
                            {
                                // Move ourself left
                                locationX = locationX - 1;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            // See if we can move right
                            if (locationX < 78)
                            {
                                // Read the System Caret section for
                                // more information on why you should 
                                // use 78 instead of the 79 here.
                                locationX = locationX + 1;
                            }
                            break;

                        case ConsoleKey.UpArrow:
                            // See if we can move up
                            if (locationY > 0)
                            {
                                // Move ourself up
                                locationY = locationY - 1;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            // See if we can move down
                            if (locationY < 24)
                            {
                                // Move ourself down
                                locationY = locationY + 1;
                            }
                            break;

                        case ConsoleKey.Escape:
                            // Exit the game when pressed
                            gameRunning = false;
                            break;
                    }
                }
                // Draw the player
                Console.Clear();
                Console.SetCursorPosition(locationX, locationY);
                Console.Write("@");
            }
            #endregion
            */


            Deck d1 = new Deck();
            Player p1 = new Player();
            Player p2 = new Player();
            for (int i = 0; i < d1.HandDeck.Length; i++)
            {
                if (i != 0 && i % 5 == 0)
                    break;
                p1.CardHand[i] = d1.HandDeck[i];
            }
            foreach (Card card in p1.CardHand)
            {
                if (card.GetType() == typeof(Playground2.CharacterCard))
                {
                    CharacterCard cC = (CharacterCard)card;
                    Console.WriteLine("Name: " + cC.Name);
                    Console.WriteLine("Health: " + cC.Health);
                    Console.WriteLine("Attack: " + cC.Attack);
                    if (cC.Holo)
                    { 
                        foreach(ConsoleColor color in Enum.GetValues(typeof(ConsoleColor))) {
                            Task<string> i = Task.Run(() => ColorChanger());
                            Console.ForegroundColor = color;
                            Console.WriteLine("Holographic: " + cC.Holo);
                            int currentLineCursor = Console.CursorTop - 1;
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write(new string(' ', Console.WindowWidth));
                            Console.SetCursorPosition(0, currentLineCursor);
                            
                        }
                    }
                    else
                        Console.WriteLine("Holographic: " + cC.Holo);

                   // Console.Beep(1000, 100);

                    
                }
                else
                {
                    BuffCard bC = (BuffCard)card;

                }
            }
            for (int i = 1; i < 10; i++)
                //Console.Beep((i) * 500, 50);
            Console.ReadLine();
        }

        public static async Task<string> ColorChanger()
        {
            await Task.Delay(100);
            string i = " ";
            Console.Beep(4000, 500);
            return i;
        }
    }

    public class Player
    {
        private Card[] mCardHand = new Card[5];
        static Random rand = new Random();
        public Card[] CardHand { get => mCardHand; set => mCardHand = value; }

        public Player()
        {
            //for (int i = 0; i < CardHand.Length; i++)
            //{
            //    if (i == 0)
            //        CardHand[i] = new CharacterCard();
            //    else
            //    {
            //        if (rand.Next(10) % 2 == 0)
            //            CardHand[i] = new CharacterCard();
            //        else
            //            CardHand[i] = new BuffCard();
            //    }
            //}
        }

        public void PlayCard()
        {
            CardHand[1].Played = true;
        }

      
    }

    public class Card
    {
        private bool played;
        private bool holo;
        static Random rand = new Random();
        public bool Played { get => played; set => played = value; }
        public bool Holo { get => holo; private set => holo = value; }

        public Card()
        {
            Played = false;
            if (rand.Next(100) <= 50)
                Holo = true;
            else
                Holo = false;
            // 25 more health if holo
        }
    }

    public class CharacterCard : Card
    {
        private string name;
        private string vowels = "AEIOUY";
        private string consonants = "BCDFGHJKLMNPQRSTVWXZ";
        private int health;
        private int attack;
        static Random rand = new Random();

        public string Name { get => name; private set => name = value; }
        public int Health { get => health; private set => health = value; }
        public int Attack { get => attack; private set => attack = value; }

        public CharacterCard()
        {
            if (Holo)
            {
                Health = HealthGen() + rand.Next(25, 30);
                Attack = AttackGen() + rand.Next(1, 1);
            }
            else
            {
                Health = HealthGen();
                Attack = AttackGen();
            }
            Name = NameGen();
        }
        static int HealthGen() => rand.Next(100, 150);

        static int AttackGen() => rand.Next(10, 20);

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

        public void ATK(CharacterCard card)
        {
            if (card.Health <= 0)
                Console.WriteLine(card.Name + " has died");
            else
                card.Health -= Attack;
        }
    }

    public class BuffCard : Card
    {
        private int atkBuff;
        static Random rand = new Random();

        public int AtkBuff()
        {
            return rand.Next(1, 10);
        }

        public int AtkDeBuff()
        {
            return rand.Next(1, 10);
        }
    }

    public class Deck
    {
        private Card[] deck = new Card[25];
        static Random rand = new Random();

        public Card[] HandDeck { get => deck; set => deck = value; }

        public Deck()
        {
            for (int i = 0; i < HandDeck.Length; i++)
            {
                if (i == 0)
                    HandDeck[i] = new CharacterCard();
                else
                {
                    if (rand.Next(10) % 2 == 0)
                        HandDeck[i] = new CharacterCard();
                    else
                        HandDeck[i] = new BuffCard();
                }
            }
        }
    }
}


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
            //CharacterCard[] playerList = new CharacterCard[50];
            //for (int i = 0; i < playerList.Length; i++)
            //{
            //    playerList[i] = new CharacterCard();
            //    Console.WriteLine("Name: " + playerList[i].Name);
            //    Console.WriteLine("Health: " + playerList[i].Health);
            //    Console.WriteLine("Attack: " + playerList[i].Attack);
            //}
            //Player p1 = new Player();
            //foreach (Card card in p1.CardHand)
            //{
            //    Console.WriteLine(card.GetType().ToString());
            //    Console.WriteLine(card.Played.ToString());
            //    p1.PlayCard();
            //}
            Deck d1 = new Deck();
            Player p1 = new Player();
            Player p2 = new Player();
            for (int i = 0; i < d1.handDeck.Length; i++)
            {
                if (i != 0 && i % 5 == 0)
                    break;
                p1.CardHand[i] = d1.handDeck[i];
            }
            foreach(Card card in p1.CardHand)
            {
                if (card.GetType() == typeof(Playground2.CharacterCard))
                {
                    CharacterCard cC = (CharacterCard) card;
                    Console.WriteLine("Name: " + cC.Name);
                    Console.WriteLine("Health: " + cC.Health);
                    Console.WriteLine("Attack: " + cC.Attack);
                    Console.WriteLine("Holographic: " + cC.Holo + "\n");
                }
                else
                {
                    BuffCard bC = (BuffCard) card;

                }
            }

            Console.ReadLine();
        }
    }

    public class Player
    {
        private Card[] mCardHand = new Card[5];
        static Random rand = new Random();
        public Card[] CardHand {
            get { return mCardHand; }
            set { mCardHand = value; }
        }

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
        public bool Played { get { return played; } set { played = value; } }
        public bool Holo { get { return holo; } private set { holo = value; } }

        public Card()
        {
            Played = false;
            if(rand.Next(100) <= 50)
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

        public string Name { get { return name; } private set{ name = value; } }
        public int Health { get { return health; } private set { health = value; } }
        public int Attack { get { return attack; } private set { attack = value; } }

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

        public Card[] handDeck { get { return deck; } set { deck = value; } }

        public Deck()
        {
            for (int i = 0; i < handDeck.Length; i++)
            {
                if (i == 0)
                    handDeck[i] = new CharacterCard();
                else
                {
                    if (rand.Next(10) % 2 == 0)
                        handDeck[i] = new CharacterCard();
                    else
                        handDeck[i] = new BuffCard();
                }
            }
        }
    }
}


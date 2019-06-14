using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcpaTbIй_so_per
{
    [TestFixture]
    class testcase
    {
        

        [TestCase]
        public void zakladka()
        {
            GameLogic logic = new GameLogic();
            logic.gr = new int[5, 5];

            int allah = 10;
            int tag = 10;

            logic.zakladka(allah, tag);
            int g = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (logic.gr[i, j] == 9)
                        g++;

            Assert.AreEqual(10, g);

            bool trying = false;
            for (int h = 0; h < logic.gr.GetLength(0); h++)
                for (int b = 0; b < logic.gr.GetLength(1); b++)
                    if (logic.tryer(h, b) == false)
                        trying = true;

            Assert.AreEqual(true, trying);

            var ex =Assert.Throws<Exception>(() => logic.zakladka(0, 10));
            Assert.That(ex.Message, Is.EqualTo("Маловато мин"));
            var ex1 = Assert.Throws<Exception>(() => logic.zakladka(100, 10));
            Assert.That(ex1.Message, Is.EqualTo("Многовато мин"));
            var ex2 = Assert.Throws<Exception>(() => logic.zakladka(int.MinValue, 10));
            Assert.That(ex2.Message, Is.EqualTo("Маловато мин"));
            var ex3 = Assert.Throws<Exception>(() => logic.zakladka(int.MaxValue, 10));
            Assert.That(ex3.Message, Is.EqualTo("Многовато мин"));

        }

        [TestCase]
        public void tryer()
        {
            GameLogic logic = new GameLogic();

            logic.gr = new int[,]
            {
                { 1, 1, 0, 1, 0 },
                { 1, 1, 1, 1, 0 },
                { 0, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1 },
                { 2, 0, 1, 1, 0 }
            };

            Assert.AreEqual(true, logic.tryer(0, 0));
            Assert.AreEqual(true, logic.tryer(2, 2));
            Assert.AreEqual(false, logic.tryer(4, 4));
            Assert.AreEqual(false, logic.tryer(0, 4));

            var ex = Assert.Throws<Exception>(() => logic.tryer(-238, -75969));
            Assert.That(ex.Message, Is.EqualTo("Выход за границу"));
            var ex1 = Assert.Throws<Exception>(() => logic.tryer(9876745, 7465785));
            Assert.That(ex1.Message, Is.EqualTo("Выход за границу"));
            var ex2 = Assert.Throws<Exception>(() => logic.tryer(int.MaxValue, int.MinValue));
            Assert.That(ex2.Message, Is.EqualTo("Выход за границу"));

        }

        [TestCase]
        public void zapolnyator()
        {
            GameLogic logic = new GameLogic();

            logic.gr = new int[,]
            {
                { 0, 9, 0, 9, 0 },
                { 0, 0, 9, 0, 0 },
                { 0, 9, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 9, 0 }
            };

            logic.zapolnyator();

            Assert.AreEqual(1, logic.celler(0, 0));
            Assert.AreEqual(3, logic.celler(0, 2));
            Assert.AreEqual(2, logic.celler(2, 2));
            Assert.AreEqual(1, logic.celler(3, 3));
        }

        [TestCase]
        public void otkrivashka()
        {
            GameLogic logic = new GameLogic();

            logic.gr = new int[,]
            {
                { 1, 9, 1, 0, 0 },
                { 1, 1, 1, 1, 1 },
                { 0, 0, 0, 1, 9 },
                { 0, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0 }
            };

            logic.otkrivashka(0, 4);

            Assert.AreEqual(10, logic.celler(0, 4));
            logic.otkrivashka(0, 0);
            Assert.AreEqual(11, logic.celler(0, 0));
            logic.otkrivashka(0, 1);
            Assert.AreEqual(9, logic.celler(0, 1));
        }

        

        public class data
        {
            public int uid { get; set; }
            public string name { get; set; }
            public int time { get; set; }
            public int highscore { get; set; }
        }
        
        //!= null
        //is true

        [TestCase]
        public void output()
        {
            
            sql sqlite = new sql();
            var res = sqlite.output();
            
            Assert.AreEqual(res, sqlite.output());

        }

        [TestCase]
        public void input()
        {
            sql sqlite = new sql();
            Assert.AreEqual(true, sqlite.input(1,1,"qwe"));
        }
        [TestCase]
        public void inpout()
        {
            sql sqlite = new sql();
          sqlite.input(0, 14, "ТЫ КТО ТАКОЙ ЧТОБ ЭТО ДЕЛАТЬ");

            var res = sqlite.output();
            //  for (int i = 0; i < res.Count(); i++)
            //  {
            int raz = (res.Count);
            Assert.AreEqual(43, res[0].highscore);
            Assert.AreEqual(0, res[raz-1].highscore);
            Assert.AreEqual("ТЫ КТО ТАКОЙ ЧТОБ ЭТО ДЕЛАТЬ", res[raz-1].name.ToString());
        }
        [TestCase]
        public void inputishe()
        {
            sql sqlite = new sql();
            Assert.AreEqual(true, sqlite.input(43, 43, "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff"));
           
        }

        [TestCase]
        public void megatest()
        {
            GameLogic logic = new GameLogic();
            int allah = 50;
            Random rnd = new Random();

            for(int i = 0; i<10000; i++)
            {
                logic.gr = new int[10, 10];
                bool trying = false;
                int tag = rnd.Next(0, 99);
                logic.zakladka(allah, tag);
                for (int h = 0; h < logic.gr.GetLength(0); h++)
                    for (int b = 0; b < logic.gr.GetLength(1); b++)
                        if (logic.tryer(h, b) == false)
                        {
                            trying = true;
                            Assert.AreEqual(true, trying);
                        }


            }
        }

        [TestCase]
        public void lastchanse()
        {
            GameLogic logic = new GameLogic();
            logic.gr = new int[,]
            {
                { 9, 9, 9, 0 },
                { 9, 9, 9, 0 },
                { 9, 9, 9, 0 },
                { 0, 0, 0, 0 }
            };
            Assert.AreEqual(true, logic.tryer(0, 0));
            Assert.AreEqual(true, logic.tryer(1, 1));
            Assert.AreEqual(false, logic.tryer(2, 2));
            Assert.AreEqual(false, logic.tryer(3, 3));
        }
    }
}

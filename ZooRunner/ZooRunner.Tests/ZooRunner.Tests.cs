using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooRunner;

namespace ZooRunner.Tests
{
    [TestFixture]
    class RunnerTests
    {
        [Test]
        public void create_zoo_and_animal()
        {
            ZooAdapter sut = ZooAdapter.Load("C:\\Users\\Luc\\Desktop\\ZooRunner\\ZooSample\\obj\\Debug\\ZooSample.dll");

            AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");
            AnimalAdapter roger = sut.AnimalTypes[0].CreateInstance("Roger");
            AnimalAdapter loic = sut.AnimalTypes[1].CreateInstance("Loïc");
            AnimalAdapter suarez = sut.AnimalTypes[1].CreateInstance("Suarez");

            Assert.That(bob.Name, Is.EqualTo("Bob"));
            Assert.That(roger.Name, Is.EqualTo("Roger"));
            Assert.That(loic.Name, Is.EqualTo("Loïc"));
            Assert.That(suarez.Name, Is.EqualTo("Suarez"));
        }

        [Test]
        public void initial_position_works()
        {
            ZooAdapter sut = ZooAdapter.Load("C:\\Users\\Luc\\Desktop\\ZooRunner\\ZooSample\\obj\\Debug\\ZooSample.dll");

            AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");
            AnimalAdapter roger = sut.AnimalTypes[0].CreateInstance("Roger");
            AnimalAdapter loic = sut.AnimalTypes[1].CreateInstance("Loïc");
            AnimalAdapter suarez = sut.AnimalTypes[1].CreateInstance("Suarez");

            double initialPositionXY = 0;

            Assert.That(bob.X, Is.EqualTo(initialPositionXY));
            Assert.That(roger.X, Is.EqualTo(initialPositionXY));
            Assert.That(loic.X, Is.EqualTo(initialPositionXY));
            Assert.That(suarez.X, Is.EqualTo(initialPositionXY));
            Assert.That(bob.Y, Is.EqualTo(initialPositionXY));
            Assert.That(roger.Y, Is.EqualTo(initialPositionXY));
            Assert.That(loic.Y, Is.EqualTo(initialPositionXY));
            Assert.That(suarez.Y, Is.EqualTo(initialPositionXY));
        }

        [Test]
        public void create_multiple_animals()
        {
            ZooAdapter sut = ZooAdapter.Load("C:\\Users\\Luc\\Desktop\\ZooRunner\\ZooSample\\obj\\Debug\\ZooSample.dll");

            AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");
            AnimalAdapter roger = sut.AnimalTypes[0].CreateInstance("Roger");
            AnimalAdapter loic = sut.AnimalTypes[1].CreateInstance("Loïc");
            AnimalAdapter suarez = sut.AnimalTypes[1].CreateInstance("Suarez");

            double initialPositionXY = 0;

            Assert.That(bob.X, Is.EqualTo(initialPositionXY));
            Assert.That(roger.X, Is.EqualTo(initialPositionXY));
            Assert.That(loic.X, Is.EqualTo(initialPositionXY));
            Assert.That(suarez.X, Is.EqualTo(initialPositionXY));
            Assert.That(bob.Y, Is.EqualTo(initialPositionXY));
            Assert.That(roger.Y, Is.EqualTo(initialPositionXY));
            Assert.That(loic.Y, Is.EqualTo(initialPositionXY));
            Assert.That(suarez.Y, Is.EqualTo(initialPositionXY));
        }

        [Test]
        public void animals_can_move()
        {
            ZooAdapter sut = ZooAdapter.Load("C:\\Users\\Luc\\Desktop\\ZooRunner\\ZooSample\\obj\\Debug\\ZooSample.dll");

            AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");
            AnimalAdapter roger = sut.AnimalTypes[0].CreateInstance("Roger");
            AnimalAdapter loic = sut.AnimalTypes[1].CreateInstance("Loïc");
            AnimalAdapter suarez = sut.AnimalTypes[1].CreateInstance("Suarez");

            double initialPositionXY = 0;

            Assert.That(bob.X, Is.EqualTo(initialPositionXY));
            Assert.That(roger.X, Is.EqualTo(initialPositionXY));
            Assert.That(loic.X, Is.EqualTo(initialPositionXY));
            Assert.That(suarez.X, Is.EqualTo(initialPositionXY));
            Assert.That(bob.Y, Is.EqualTo(initialPositionXY));
            Assert.That(roger.Y, Is.EqualTo(initialPositionXY));
            Assert.That(loic.Y, Is.EqualTo(initialPositionXY));
            Assert.That(suarez.Y, Is.EqualTo(initialPositionXY));
        }
    }
}

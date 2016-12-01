using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path); AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");

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
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path);

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
        public void meter_definition_works()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path); AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");

            double meterDefinition = 0.001;

            Assert.That(sut.MeterDefinition, Is.EqualTo(meterDefinition));
        }

        [Test]
        public void map_size_works()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path);

            int mapSize = 2000000;

            Assert.That(sut.MapSize, Is.EqualTo(mapSize));
        }

        [Test]
        public void with_in_meter_works()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path);

            int withInMeter = 2000;

            Assert.That(sut.WithInMeter, Is.EqualTo(withInMeter));
        }
    }
}

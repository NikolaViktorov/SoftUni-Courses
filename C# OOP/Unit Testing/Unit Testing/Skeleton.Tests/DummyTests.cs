using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    class DummyTests
    {
        Dummy dummy;
        Axe axe;
        Dummy deadDummy;
        [SetUp]
        public void SettingMocks()
        {
            this.deadDummy = new Dummy(0, 100);
            this.dummy = new Dummy(100, 100);
            this.axe = new Axe(10, 10);
        }
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            dummy.TakeAttack(10);
            int expectedDummyHealthAfterAttack = 90; // 100 - 10
            Assert.That(dummy.Health, Is.EqualTo(expectedDummyHealthAfterAttack), "Dummy doesn't lose health after attacked or doesn't lose the right amount of it.");
        }
        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Assert.That(() => deadDummy.TakeAttack(10), Throws.InvalidOperationException, "Dummy doesn't throw exception if attacked when dead.");
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            int expectedExperienceGiven = 100;
            Assert.That(deadDummy.GiveExperience(), Is.EqualTo(expectedExperienceGiven), "Dead dummy doesn't give XP or doesn't give the right amount of it.");
        }
        [Test]
        public void AliveDummyCannotGiveXP()
        {
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Alive dummy still gives XP.");
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    class AxeTests
    {
        Dummy dummy;
        Axe axe;
        [SetUp]
        public void SettingMocks()
        {
            this.dummy = new Dummy(100, 100);
            this.axe = new Axe(10, 10);
        }
        [Test]
        public void AxeLosesDurabilityAfterEachAttack()
        {
            int expectedDurabilityAfterAttack = 9;
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(expectedDurabilityAfterAttack), "Durability doesn't change after attacl");
        }
        [Test]
        public void AttackingWithABrokenWeapon()
        {
            Axe brokenAxe = new Axe(10, 0);
            Assert.That(() => brokenAxe.Attack(dummy), Throws.InvalidOperationException, "Axe doesn't break at 0 durability");
        }
    }
}

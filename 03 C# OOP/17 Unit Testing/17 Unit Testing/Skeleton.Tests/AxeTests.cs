using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        private const int AXE_ATTACK_DEFAULT = 10;
        private const int AXE_DURABILITY_DEFAULT = 10;
        private const int AXE_DURABILITY_LOST = 1;
        private const int DUMMY_HEALTH_DEFAULT = 10;
        private const int DUMMY_EXPERIENCE_DEFAULT = 10;

        private const string EXCEPTION_MSG_BROKEN = "Axe is broken.";

        [SetUp]
        public void Setup()
        {
            axe = new Axe(AXE_ATTACK_DEFAULT, AXE_DURABILITY_DEFAULT);
            dummy = new Dummy(DUMMY_HEALTH_DEFAULT, DUMMY_EXPERIENCE_DEFAULT);
        }

        [Test]
        public void Test_AxeConstructor()
        {
            Assert.That(
                axe.DurabilityPoints,
                Is.EqualTo(AXE_DURABILITY_DEFAULT),
                "Axe Durability not set correctly by constructor.");
            Assert.That(
                axe.AttackPoints,
                Is.EqualTo(AXE_ATTACK_DEFAULT),
                "Axe Attack not set correctly by constructor.");
        }

        [Test]
        public void Test_AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(
                axe.DurabilityPoints, 
                Is.EqualTo(AXE_DURABILITY_DEFAULT - AXE_DURABILITY_LOST), 
                "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Test_AxeWithZeroDurabilityThrowsException()
        {
            axe = new Axe(AXE_ATTACK_DEFAULT, 0);

            Exception ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.That(
                ex.Message,
                Is.EqualTo(EXCEPTION_MSG_BROKEN),
                "Attack with broken sword doesn't throw exception.");

            //InvalidOperationException("Dummy is dead.")
        }

    }
}
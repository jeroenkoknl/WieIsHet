using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace WieIsHet.Tests
{
    [TestFixture]
    public class SpelTest
    {
        [Test]
        public void Should_return_same_personen_as_constructed()
        {
            var fixture = new Fixture();
            var personen = fixture.CreateMany<Persoon>().ToList();
            var spel = new Spel(personen);
            spel.Personen.Should().BeEquivalentTo(personen);
        }

        [Test]
        public void Should_throw_argument_exception_when_constructed_with_null_value()
        {
            Assert.Throws<ArgumentNullException>(() => new Spel(null));
        }

        [Test]
        public void Should_throw_argument_exception_when_constructed_with_empty_collection()
        {
            Assert.Throws<ArgumentException>(() => new Spel(new List<Persoon>()));
        }

        [Test]
        public void Should_remove_personen_with_eigenschap_when_eigenschap_is_not_applicable()
        {
            var fixture = new Fixture();
            var eigenschap1 = fixture.Create<Eigenschap>();
            var eigenschap2 = fixture.Create<Eigenschap>();
            var harry = new Persoon("Harry", new List<Eigenschap>
            {
                eigenschap1
            });
            var klaas = new Persoon("Klaas", new List<Eigenschap>
            {
                eigenschap2
            });
            var spel = new Spel(new List<Persoon>
            {
                harry,
                klaas
            });
            spel.VerwijderPersonenMetEigenschap(eigenschap1, false);
            spel.Personen.Should().NotContain(harry);
            spel.Personen.Should().Contain(klaas);
        }

        [Test]
        public void Should_remove_personen_without_eigenschap_when_eigenschap_is_applicable()
        {
            var fixture = new Fixture();
            var eigenschap1 = fixture.Create<Eigenschap>();
            var eigenschap2 = fixture.Create<Eigenschap>();
            var harry = new Persoon("Harry", new List<Eigenschap>
            {
                eigenschap1
            });
            var klaas = new Persoon("Klaas", new List<Eigenschap>
            {
                eigenschap2
            });
            var spel = new Spel(new List<Persoon>
            {
                harry,
                klaas
            });
            spel.VerwijderPersonenMetEigenschap(eigenschap1, true);
            spel.Personen.Should().Contain(harry);
            spel.Personen.Should().NotContain(klaas);
        }
    }
}
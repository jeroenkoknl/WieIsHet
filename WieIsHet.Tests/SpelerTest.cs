using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace WieIsHet.Tests
{
    [TestFixture]
    public class SpelerTest
    {
        [Test]
        public void Should_have_no_questions_when_spel_contains_one_personen()
        {
            var fixture = new Fixture();
            var spel = new Spel(fixture.CreateMany<Persoon>(1).ToList());
            var speler = new Speler(spel);
            speler.Vragen.Should().BeEmpty();
        }

        [Test]
        public void Should_have_one_question_when_spel_has_two_persoonen()
        {
            var fixture = new Fixture();
            var spel = new Spel(fixture.CreateMany<Persoon>(2).ToList());
            var speler = new Speler(spel);
            var count = 0;
            foreach (var vraag in speler.Vragen)
            {
                count++;
                vraag.Beantwoord(true);
            }
            count.Should().Be(1);
        }

        [Test]
        public void Spel_should_have_GeradenPersoon_when_all_questions_have_been_answered()
        {
            var fixture = new Fixture();
            var spel = new Spel(fixture.CreateMany<Persoon>().ToList());
            var speler = new Speler(spel);
            foreach (var vraag in speler.Vragen)
            {
                vraag.Beantwoord(false);
            }
            spel.GeradenPersoon.Should().NotBeNull();
        }
    }
}
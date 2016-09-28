using System;

namespace WieIsHet
{
    public class Vraag
    {
        private readonly Eigenschap eigenschap;
        private readonly Spel spel;

        public Vraag(Eigenschap eigenschap, Spel spel)
        {
            if (eigenschap == null)
                throw new ArgumentNullException(nameof(eigenschap));
            if (spel == null)
                throw new ArgumentNullException(nameof(spel));
            this.eigenschap = eigenschap;
            this.spel = spel;
        }

        public string Text => $"Heeft de persoon {eigenschap.Naam}?";

        public void Beantwoord(bool vanToepassing)
        {
            spel.VerwijderPersonenMetEigenschap(eigenschap, vanToepassing);
        }

        public override string ToString() => Text;
    }
}
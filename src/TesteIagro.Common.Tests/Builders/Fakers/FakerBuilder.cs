using Bogus;

namespace TesteIagro.Common.Tests.Builders.Fakers
{
    public class FakerBuilder
    {
        public static FakerBuilder Novo() => new FakerBuilder();

        public Faker Build() => new Faker("pt_BR");
    }
}

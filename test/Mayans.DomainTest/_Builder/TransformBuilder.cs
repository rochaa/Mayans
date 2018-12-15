using System;
using Bogus;
using Mayans.Domain.Transforms;

namespace Mayans.DomainTest._Builder
{
    public class TransformBuilder
    {
        protected string Word1;
        protected string Word2;

        public static TransformBuilder New()
        {
            var faker = new Faker();

            return new TransformBuilder {
                Word1 = faker.Random.AlphaNumeric(6),
                Word2 = faker.Random.AlphaNumeric(7)
            };
        }

        public TransformBuilder WithWord1(string word1)
        {
            Word1 = word1;
            return this;
        }

        public TransformBuilder WithWord2(string word2)
        {
            Word2 = word2;
            return this;
        }

        public Transform Build()
        {
            return new Transform(Word1, Word2);
        }
    }
}
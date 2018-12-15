using System;
using System.Collections.Generic;
using Bogus;
using ExpectedObjects;
using Mayans.Domain;
using Mayans.Domain._Base;
using Mayans.Domain.Transforms;
using Mayans.DomainTest._Builder;
using Mayans.DomainTest._Extensions;
using Xunit;

namespace Mayans.DomainTest.Transforms
{
    public class TransformTest
    {
        private Transform _transform;

        public TransformTest()
        {
            _transform = TransformBuilder.New().Build();
        }

        [Fact]
        public void MustCreateATransform()
        {
            //Given
            var transformExpected = new {
                _transform.Word1,
                _transform.Word2
            };

            //When
            Transform transform = new Transform(transformExpected.Word1, transformExpected.Word2); 
            
            //Then
            transformExpected.ToExpectedObject().ShouldMatch(transform);
        }

        [Theory]
        [InlineData("ABDC!@#")]
        [InlineData("ABC-123")]
        public void MustNotHaveWord1Invalid(string word1Invalid)
        {
            //Then
            Assert.Throws<DomainException>(() =>
                TransformBuilder.New().WithWord1(word1Invalid).Build())
            .WithMessage(Resource.Word1Invalid);
        }

        [Theory]
        [InlineData("&*()YWZ")]
        [InlineData("6789-JHGF")]
        public void MustNotHaveWord2Invalid(string word2Invalid)
        {
            //Then
            Assert.Throws<DomainException>(() =>
                TransformBuilder.New().WithWord2(word2Invalid).Build())
            .WithMessage(Resource.Word2Invalid);
        }
    }
}

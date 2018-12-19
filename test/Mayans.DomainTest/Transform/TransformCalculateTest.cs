using System.Text.RegularExpressions;
using Mayans.Domain._Base;
using Mayans.Domain.Transforms;
using Mayans.DomainTest._Builder;
using Mayans.DomainTest._Extensions;
using Moq;
using Xunit;

namespace Mayans.DomainTest.Transforms
{
    public class TransformCalculateTest
    {
        private readonly TransformCalculate _transformCalculate;
        private TransformDto _transformDto;

        public TransformCalculateTest()
        {
            _transformDto = new TransformDto();
            _transformCalculate = new TransformCalculate();
        } 

        [Fact]
        public void MustCalculateTheTransformationBetweenTomAndJerry()
        {
            //Given
            var resultExpected = 1;
            _transformDto.Word1 = "GATO";
            _transformDto.Word2 = "RATO";

            //When
            var transform = _transformCalculate.Calculate(_transformDto);

            //Then
            Assert.Equal(resultExpected, transform.Result);
        }

        [Fact]
        public void MustCalculateTheTransformationBetweenHorseAndDuck()
        {
            //Given
            var resultExpected = 4;
            _transformDto.Word1 = "CAVALO";
            _transformDto.Word2 = "PATO";

            //When
            var transform = _transformCalculate.Calculate(_transformDto);

            //Then
            Assert.Equal(resultExpected, transform.Result);
        }

        [Fact]
        public void Word2MustNotBiggerThanWord1()
        {
            //Given
            _transformDto.Word1 = "PATO";
            _transformDto.Word2 = "CAVALO";

            //Then
            Assert.Throws<DomainException>(() =>
                 _transformCalculate.Calculate(_transformDto))
            .WithMessage(Resource.Word2LargerThanWord1);
        }
    }
}
using Mayans.Domain.Transforms;
using Mayans.DomainTest._Builder;
using Moq;
using Xunit;

namespace Mayans.DomainTest.Transforms
{
    public class TransformCalculateTest
    {
        private readonly TransformCalculate _transformCalculate;
        private TransformDto _transformDto;
        private Mock<Transform> _result;

        public TransformCalculateTest()
        {
            _transformDto = TransformBuilder.New().BuildDto();
            _transformCalculate = new TransformCalculate();
            _result = new Mock<Transform>();
        } 

        [Fact]
        public void MustCalculateTheTransformation()
        {
            //Given
        
            //When
            var result = _transformCalculate.Calculate(_transformDto);
        
            //Then
            _result.VerifySet(w => w.WriteResult(result));
        }
    }

    public class TransformCalculate
    {
        public int Calculate(TransformDto transformDto)
        {
            var transform = new Transform(transformDto.Word1, transformDto.Word2);
            var result = 0;

            transform.WriteResult(result);

            return transform.Result;
        }
    }

    public class TransformDto
    {
        public string Word1 { get; set; }
        public string Word2 { get; set; }
        public int Result { get; set; }
    }
}
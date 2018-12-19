using Mayans.Domain._Base;

namespace Mayans.Domain.Transforms
{
    public class TransformCalculate
    {
        public Transform Calculate(TransformDto transformDto)
        {
            var transform = new Transform(transformDto.Word1, transformDto.Word2);
            var result = 0;      
            var word1WithDrives = transform.Word1;

            Validator.New()
                .When(transformDto.Word2.Length > transformDto.Word1.Length, Resource.Word2LargerThanWord1)
                .ShootExceptionExists();

            // Remove caracteres excedentes e adiciona na contagem de resultado.
            while (word1WithDrives.Length > transform.Word2.Length)
            {
                word1WithDrives = word1WithDrives.Remove(0, 1);
                result++;
            }

            // Faz mudança dos caracteres até que a primeira palavra seja igual a segunda e adiciona na contagem de resultado 
            for (int i = 0; i < word1WithDrives.Length; i++)
            {
                if (word1WithDrives[i] != transform.Word2[i])
                {
                    word1WithDrives = word1WithDrives.Substring(0, i) + transform.Word2[i] + word1WithDrives.Substring(i + 1);
                    result++;
                }
            }

            transform.WriteResult(result);
            return transform;
        }
    }
}
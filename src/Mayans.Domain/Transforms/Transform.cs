using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mayans.Domain._Base;

namespace Mayans.Domain.Transforms
{
    public class Transform
    {
        public string Word1 { get; private set; }
        public string Word2 { get; private set; }
        public int Result { get; private set; }

        public Transform(string word1, string word2)
        {
            Regex alphanumeric = new Regex(@"^[a-zA-Z0-9]*$");

            Validator.New()
                .When(!alphanumeric.IsMatch(word1), Resource.Word1Invalid)
                .When(!alphanumeric.IsMatch(word2), Resource.Word2Invalid)
                .ShootExceptionExists();

            Word1 = word1;
            Word2 = word2;
        }

        public void WriteResult(int result)
        {
            Result = result;
        }
    }
}
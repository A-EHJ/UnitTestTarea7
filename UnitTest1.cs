using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestTare7
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }


    }

    internal class RegisterViewModel
    {
        internal bool IsPasswordSecure(string contraseña)
        {
            if (contraseña.Length < 10)
            {
                return false;
            }

            if (!ContieneMayuscula(contraseña))
            {
                return false;
            }

            if (!ContieneSimbolo(contraseña))
            {
                return false;
            }

            return true;
        }

        private bool ContieneMayuscula(string contraseña)
        {
            return contraseña.Any(c => Char.IsLetter(c) && Char.IsUpper(c));
        }

        private bool ContieneSimbolo(string contraseña)
        {
            return contraseña.Any(c => !Char.IsSymbol(c));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestTare7
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void EsSegura_return_False_sí_es_menor_que_10()
        {
            // Arrange
            var registerViewModel = new RegisterViewModel();

            // Act
            bool result = registerViewModel.IsPasswordSecure("123456789");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EsSegura_return_True_sí_es_mayor_o_igual_que_10()
        {
            // Arrange
            var registerViewModel = new RegisterViewModel();

            // Act
            bool result = registerViewModel.IsPasswordSecure("123456789@A");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EsSegura_return_False_si_no_tiene_o_Mayuscula()
        {
            //Arrange
            var registerViewModel = new RegisterViewModel();

            //Act
            bool result = registerViewModel.IsPasswordSecure("12345678aeiou");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EsSegura_return_True_si_tiene_Mayuscula()
        {
            //Arrange
            var registerViewModel = new RegisterViewModel();

            //Act
            bool result = registerViewModel.IsPasswordSecure("12345678AeIoU");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EsSegura_return_False_si_no_tiene_simbolo()
        {
            //Arrange
            var registerViewModel = new RegisterViewModel();

            //Act
            bool result = registerViewModel.IsPasswordSecure("12345678aeio");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EsSegura_return_True_si_tiene_simbolo()
        {
            //Arrange
            var registerViewModel = new RegisterViewModel();

            //Act
            bool result = registerViewModel.IsPasswordSecure("12345678AeIoU@");

            //Assert
            Assert.IsTrue(result);
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
}
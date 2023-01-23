using TechnicalTest;

namespace StringCalculatorUnitTests
{
    public class Tests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            var delimiterFinder = new DelimiterFinder();
            var parser = new NumberParser();
            _calculator = new Calculator(delimiterFinder, parser);
        }

        [Test]
        public void Add_CalledWithEmptyString_ShouldReturnZero()
        {            
            Assert.That(_calculator.Add(""), Is.EqualTo(0));
        }

        [Test]
        public void Add_CalledWithZeroString_ShouldReturn0()
        {            
            Assert.That(_calculator.Add("0"), Is.EqualTo(0));
        }

        [Test]
        public void Add_CalledWithOneString_ShouldReturn1()
        {            
            Assert.That(_calculator.Add("1"), Is.EqualTo(1));
        }

        [Test]
        public void Add_CalledWithValidString_ShouldReturnAnswer()
        {            
            Assert.That(_calculator.Add("5,12,24"), Is.EqualTo(41));
        }

        [Test]
        public void Add_CalledWithNumberLargerThan1000_ShouldReturn1()
        {            
            Assert.That(_calculator.Add("1,1001"), Is.EqualTo(1));
        }

        [Test]
        public void Add_CalledWithnegatives_ShouldThrowError()
        {            
            Assert.Throws<Exception>(() => _calculator.Add("10,10,-5,-12, -1"));
        }

        [Test]
        public void Add_CalledWithNewLinecharacter_ShouldReturn6()
        {            
            Assert.That(_calculator.Add("1\n2,3"), Is.EqualTo(6));
        }

        [Test]
        public void Add_CalledWithDoubleSlash_ShouldReturn10()
        {            
            Assert.That(_calculator.Add("//#1,2,3#4"), Is.EqualTo(10));
        }

        [Test]
        public void Add_CalledWithManyDelimiters_ShouldReturn45()
        {            
            Assert.That(_calculator.Add("//%5%6%7%8%9%10"), Is.EqualTo(45));
        }

        [Test]
        public void Add_CalledWithSquareBrackets_ShouldReturn10()
        {            
            Assert.That(_calculator.Add("//[#]1#2,3\n4"), Is.EqualTo(10));
        }

        [Test]
        public void Add_CalledWithMultipleDelimiters_ShouldReturn10()
        {            
            Assert.That(_calculator.Add("//[¬][&][£]1¬2&3£4"), Is.EqualTo(10));
        }

        [Test]
        public void Add_CalledWitStringDelimiters_ShouldReturn10()
        {            
            Assert.That(_calculator.Add("//[¬¬¬]1¬¬¬2¬¬¬3¬¬¬4"), Is.EqualTo(10));
        }
    }
}
namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            var operations = new List<IOperation>
            {
                new AdditionOperation(),
                new SubtractionOperation(),
                new MultiplicationOperation(),
                new DivisionOperation()
            };
            var parser = new ExpressionParser(operations);
            _calculator = new Calculator(parser);
        }

        [TestMethod]
        [DataRow("8+13", 21)]
        [DataRow("5-2", 3)]
        [DataRow("4*3", 12)]
        [DataRow("6/2", 3)]
        [DataRow("3+2*2", 7)]
        [DataRow("6/2+3", 6)]
        [DataRow("6/2+3/3", 4)]
        public void Calculate_ValidExpression_ReturnsCorrectResult(string input, double expected)
        {
            var result = _calculator.Calculate(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Calculate_DivideByZero_ThrowsException()
        {
            Assert.ThrowsException<DivideByZeroException>(() => _calculator.Calculate("4/0"));
        }
    }
}
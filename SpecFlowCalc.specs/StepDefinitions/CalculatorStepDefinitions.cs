using SpecFlowTest;
using FluentAssertions;

namespace SpecFlowCalc.specs.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly Calculator _calculator = new Calculator();

        private int _result;

        private string _error;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)   
        {
            _calculator.FirstNumber = number;
            //throw new PendingStepException();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
            //throw new PendingStepException();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _result = _calculator.Subtract();
        }

        [When(@"adding (.*)")]
        public void WhenAdding(int number)
        {
            _calculator.SecondNumber = number;
            _calculator.FirstNumber = _calculator.Add();
            _result = _calculator.FirstNumber;
        }


        [When(@"dividing by (.*)")]
        public void WhenDividingBy(int number)
        {
            _calculator.SecondNumber = number;
            if(_calculator.SecondNumber == 0){
                _error = "Can't divide by zero";
                return;
            }
            _calculator.FirstNumber = _calculator.Divide();
            _result = _calculator.FirstNumber;
        }

        [When(@"subtracting (.*)")]
        public void WhenSubtracting(int number)
        {
            _calculator.SecondNumber = number;
            _calculator.FirstNumber = _calculator.Subtract();
            _result = _calculator.FirstNumber;
        }

        [When(@"modulo (.*)")]
        public void WhenModulo(int number)
        {
            _calculator.SecondNumber = number;
            _calculator.FirstNumber = _calculator.Modulo();
            _result = _calculator.FirstNumber;
        }

        [When(@"multiply by (.*)")]
        public  void WhenMultiplyBy(int number)
        {
            _calculator.SecondNumber = number;
            _calculator.FirstNumber = _calculator.Multiply();
            _result = _calculator.FirstNumber;
        }

        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _result = _calculator.Multiply();
        }


        [Then(@"the result is an error")]
        public void ThenTheResultIsAnError()
        {
            _error.Should().Be("Can't divide by zero");
        }
        [Then(@"the result is an error")]

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }
    }
}
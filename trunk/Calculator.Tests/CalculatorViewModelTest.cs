using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{

    /// <summary>
    /// This class contains all CalculatorViewModel unit tests
    ///</summary>
    [TestClass()]
    public class CalculatorViewModelTest
    {

        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        // Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        // Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        // Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        /// A test for the CalculatorViewModel constructor
        ///</summary>
        [TestMethod()]
        public void CalculatorViewModel_ConstructorTest()
        {
            ViewModels.CalculatorViewModel vm = new ViewModels.CalculatorViewModel();

            Assert.IsTrue(vm.GetType() == typeof(ViewModels.CalculatorViewModel));
            Assert.AreEqual(vm.Display, "0");
            Assert.AreEqual(vm.FirstOperand, string.Empty);
            Assert.AreEqual(vm.SecondOperand, string.Empty);
            Assert.AreEqual(vm.Operation, string.Empty);
            Assert.AreEqual(vm.LastOperation, string.Empty);
            Assert.AreEqual(vm.FullExpression, string.Empty);
        }

        /// <summary>
        /// A test for the CalculatorViewModel valid operation using button inputs
        ///</summary>
        [TestMethod()]
        public void CalculatorViewModel_ValidOperationTest()
        {
            ViewModels.CalculatorViewModel vm = new ViewModels.CalculatorViewModel();

            //try -7 + 42 = 35
            vm.DigitButtonPress("7");
            vm.DigitButtonPress("+/-");
            
            vm.OperationButtonPress("+");
            vm.DigitButtonPress("4");
            vm.DigitButtonPress("2");

            Assert.AreEqual(vm.FirstOperand, "-7");
            Assert.AreEqual(vm.Display, "42");

            //perform operation
            vm.OperationButtonPress("=");
            
            Assert.AreEqual(vm.Operation, "+");
            Assert.AreEqual(vm.SecondOperand, "42");

            Assert.AreEqual(vm.Display, "35");
            Assert.AreEqual(vm.FullExpression, "-7 + 42 = 35");
        }


        /// <summary>
        /// A test for the CalculatorViewModel valid operation using button inputs and ClearButton after
        ///</summary>
        [TestMethod()]
        public void CalculatorViewModel_ValidOperationTestThenClear()
        {
            ViewModels.CalculatorViewModel vm = new ViewModels.CalculatorViewModel();

            //try -7 + 42 = 35
            vm.DigitButtonPress("7");
            vm.DigitButtonPress("+/-");

            vm.OperationButtonPress("+");
            vm.DigitButtonPress("4");
            vm.DigitButtonPress("2");

            Assert.AreEqual(vm.FirstOperand, "-7");
            Assert.AreEqual(vm.Display, "42");

            //perform operation
            vm.OperationButtonPress("=");

            Assert.AreEqual(vm.Operation, "+");
            Assert.AreEqual(vm.SecondOperand, "42");

            Assert.AreEqual(vm.Display, "35");
            Assert.AreEqual(vm.FullExpression, "-7 + 42 = 35");

            //ClearAll
            vm.DigitButtonPress("C");

            Assert.AreEqual(vm.Display, "0");
            Assert.AreEqual(vm.FirstOperand, string.Empty);
            Assert.AreEqual(vm.SecondOperand, string.Empty);
            Assert.AreEqual(vm.Operation, string.Empty);
            Assert.AreEqual(vm.LastOperation, string.Empty);
            Assert.AreEqual(vm.FullExpression, string.Empty);
        }


        /// <summary>
        /// A test for the CalculatorViewModel invalid operation using button inputs
        ///</summary>
        [TestMethod()]
        public void CalculatorViewModel_InValidOperationTest()
        {
            ViewModels.CalculatorViewModel vm = new ViewModels.CalculatorViewModel();

            //try -7 + 42 = 35
            vm.DigitButtonPress("7");
            vm.DigitButtonPress("+/-");

            vm.OperationButtonPress("@");
            vm.DigitButtonPress("4");
            vm.DigitButtonPress("2");

            Assert.AreEqual(vm.FirstOperand, "-7");
            Assert.AreEqual(vm.Display, "42");

            try
            {
                //perform operation
                vm.OperationButtonPress("=");
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(ArgumentException));
            }

            Assert.AreEqual(vm.Operation, "@");
            Assert.AreEqual(vm.SecondOperand, "42");

            Assert.AreEqual(vm.Display, "Unknown operation: @");
        }


        /// <summary>
        /// A test for the CalculatorViewModel valid composite operations using button inputs
        ///</summary>
        [TestMethod()]
        public void CalculatorViewModel_CompositeOperationTestThenClear()
        {
            ViewModels.CalculatorViewModel vm = new ViewModels.CalculatorViewModel();

            //try -7 + 42 = 35
            vm.DigitButtonPress("7");
            vm.DigitButtonPress("+/-");

            vm.OperationButtonPress("+");
            vm.DigitButtonPress("4");
            vm.DigitButtonPress("2");

            Assert.AreEqual(vm.FirstOperand, "-7");
            Assert.AreEqual(vm.Display, "42");

            //perform operation
            vm.OperationButtonPress("+");

            Assert.AreEqual(vm.Operation, "+");
            Assert.AreEqual(vm.SecondOperand, "42");

            Assert.AreEqual(vm.Display, "35");
            Assert.AreEqual(vm.FullExpression, "-7 + 42 = 35");

            vm.DigitButtonPress("1");
            vm.DigitButtonPress("0");

            //perform operation
            vm.OperationButtonPress("=");

            Assert.AreEqual(vm.Display, "45");
            Assert.AreEqual(vm.FullExpression, "35 + 10 = 45");

            //perform tan(45)
            vm.SingularOperationButtonPress("tan");

            Assert.AreEqual(vm.Display, "1");
            Assert.AreEqual(vm.FullExpression, "tan(45) = 1");
        }

    }
}

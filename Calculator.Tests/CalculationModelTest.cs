using System;
using System.Collections.Generic;
using Calculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{

    /// <summary>
    /// This class contains all CalculationModel unit tests
    ///</summary>
    [TestClass()]
    public class CalculationModelTest
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
        /// A test for the CalculationModel constructor
        ///</summary>
        [TestMethod()]
        public void ConstructorTestNoParams_InitialisesCorrectly()
        {
            Models.CalculationModel model = new CalculationModel();

            Assert.AreEqual(model.FirstOperand, string.Empty);
            Assert.AreEqual(model.SecondOperand, string.Empty);
            Assert.AreEqual(model.Operation, string.Empty);
            Assert.AreEqual(model.Result, string.Empty);
        }

        /// <summary>
        /// A test for the CalculationModel constructor with params
        ///</summary>
        [TestMethod()]
        public void ConstructorTestParams_InitialisesCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("3", "500", "+");

            Assert.AreEqual(model.FirstOperand,"3");
            Assert.AreEqual(model.SecondOperand, "500");
            Assert.AreEqual(model.Operation, "+");
            Assert.AreEqual(model.Result, string.Empty);
        }
        
        /// <summary>
        /// A test for valid operation
        ///</summary>
        [TestMethod()]
        public void OperationTest_AddsCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("3", "500", "+");

            Assert.AreEqual(model.FirstOperand, "3");
            Assert.AreEqual(model.SecondOperand, "500");
            Assert.AreEqual(model.Operation, "+");
            Assert.AreEqual(model.Result, string.Empty);

            model.CalculateResult();
            Assert.AreEqual(model.Result, "503");
        }

        /// <summary>
        /// A test for valid operation
        ///</summary>
        [TestMethod()]
        public void OperationTest_SubtractsCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("3", "500", "-");

            Assert.AreEqual(model.FirstOperand, "3");
            Assert.AreEqual(model.SecondOperand, "500");
            Assert.AreEqual(model.Operation, "-");
            Assert.AreEqual(model.Result, string.Empty);

            model.CalculateResult();
            Assert.AreEqual(model.Result, "-497");
        }
    
        /// <summary>
        /// A test for valid operation
        ///</summary>
        [TestMethod()]
        public void OperationTest_MultipliesCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("3", "500", "*");

            Assert.AreEqual(model.FirstOperand, "3");
            Assert.AreEqual(model.SecondOperand, "500");
            Assert.AreEqual(model.Operation, "*");
            Assert.AreEqual(model.Result, string.Empty);

            model.CalculateResult();
            Assert.AreEqual(model.Result, "1500");
        }

        /// <summary>
        /// A test for valid operation
        ///</summary>
        [TestMethod()]
        public void OperationTest_DividesCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("3", "500", "/");

            Assert.AreEqual(model.FirstOperand, "3");
            Assert.AreEqual(model.SecondOperand, "500");
            Assert.AreEqual(model.Operation, "/");
            Assert.AreEqual(model.Result, string.Empty);

            model.CalculateResult();
            Assert.AreEqual(model.Result, "0.006");
        }

        /// <summary>
        /// A test for valid operation
        ///</summary>
        [TestMethod()]
        public void OperationTest_SinesCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("-45", "sin");

            Assert.AreEqual(model.FirstOperand, "-45");
            Assert.AreEqual(model.Operation, "sin");
            Assert.AreEqual(model.Result, string.Empty);

            model.CalculateResult();
            Assert.AreEqual(model.Result, "-0.707106781186547");
        }

        /// <summary>
        /// A test for valid operation
        ///</summary>
        [TestMethod()]
        public void OperationTest_CosinesCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("-45", "cos");

            Assert.AreEqual(model.FirstOperand, "-45");
            Assert.AreEqual(model.Operation, "cos");
            Assert.AreEqual(model.Result, string.Empty);

            model.CalculateResult();
            Assert.AreEqual(model.Result, "0.707106781186548");
        }

        /// <summary>
        /// A test for valid operation
        ///</summary>
        [TestMethod()]
        public void OperationTest_TangentsCorrectly()
        {
            Models.CalculationModel model = new CalculationModel("-45", "tan");

            Assert.AreEqual(model.FirstOperand, "-45");
            Assert.AreEqual(model.Operation, "tan");
            Assert.AreEqual(model.Result, string.Empty);

            model.CalculateResult();
            Assert.AreEqual(model.Result, "-1");
        }

        /// <summary>
        /// A test for invalid operation
        ///</summary>
        [TestMethod]
        public void OperationTest_FormatException()
        {
            try
            {
                Models.CalculationModel model = new CalculationModel("BadData", "500", "+");
            }
            catch(FormatException ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(FormatException));
            }
        }

        /// <summary>
        /// A test for invalid operation
        ///</summary>
        [TestMethod]
        public void OperationTest_ArgumentException()
        {
            try
            {
                Models.CalculationModel model = new CalculationModel("3", "500", "~");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(ArgumentException));
            }
        }
    }
}

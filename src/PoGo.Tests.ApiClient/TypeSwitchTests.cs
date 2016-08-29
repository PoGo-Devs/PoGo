using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System
{
    /// <summary>
    /// Tests for the <see cref="TypeSwitch"/> class.
    /// </summary>
    /// <remarks>
    /// Created by Virtlink. Original source code on GitHub:
    /// <see href="https://gist.github.com/Virtlink/8722649"/>.
    /// </remarks>
    [TestClass]
    public class TypeSwitchTests
    {
        interface I { string GetID(); }
        interface J { string ShortName { get; } }
        class A { public string Name { get { return "A"; } } }
        class B : A { public string LongName { get { return "B"; } } }
        class C : B, I, J { public string FullName { get { return "C"; } } public string GetID() { return "CI"; } public string ShortName { get { return "CJ"; } } }

        [TestMethod]
        public void BaseClassObject()
        {
            // Arrange
            object value = new A();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((C x) => name = x.FullName)
                .Case((B x) => name = x.LongName)
                .Case<A>(() => name = "A")
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("A", name);
        }

        [TestMethod]
        public void BaseClass()
        {
            // Arrange
            A value = new A();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((C x) => name = x.FullName)
                .Case((B x) => name = x.LongName)
                .Case<A>(() => name = "A")
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("A", name);
        }

        [TestMethod]
        public void DerivedClassObject()
        {
            // Arrange
            object value = new C();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((C x) => name = x.FullName)
                .Case((B x) => name = x.LongName)
                .Case<A>(() => name = "A")
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("C", name);
        }

        [TestMethod]
        public void DerivedClassAsBaseClass()
        {
            // Arrange
            A value = new C();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((C x) => name = x.FullName)
                .Case((B x) => name = x.LongName)
                .Case<A>(() => name = "A")
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("C", name);
        }

        [TestMethod]
        public void DerivedClassCaseWrongOrder()
        {
            // Arrange
            object value = new C();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((B x) => name = x.LongName)
                .Case((C x) => name = x.FullName)
                .Case<A>(() => name = "A")
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("B", name);
        }

        [TestMethod]
        public void InterfaceObject()
        {
            // Arrange
            object value = new C();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((I x) => name = x.GetID())
                .Case((J x) => name = x.ShortName)
                .Case((C x) => name = x.FullName)
                .Case<A>(() => name = "A")
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("CI", name);
        }

        [TestMethod]
        public void Interface()
        {
            // Arrange
            J value = new C();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((J x) => name = x.ShortName)
                .Case((C x) => name = x.FullName)
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("CJ", name);
        }

        [TestMethod]
        public void Default()
        {
            // Arrange
            var value = new object();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((J x) => name = x.ShortName)
                .Case((C x) => name = x.FullName)
                .Default((x) => name = x.ToString());

            // Assert
            Assert.AreEqual("System.Object", name);
        }

        [TestMethod]
        public void DefaultNoArg()
        {
            // Arrange
            var value = new object();
            string name = null;

            // Act
            TypeSwitch.On(value)
                .Case((J x) => name = x.ShortName)
                .Case((C x) => name = x.FullName)
                .Default(() => name = "Default");

            // Assert
            Assert.AreEqual("Default", name);
        }
    }
}
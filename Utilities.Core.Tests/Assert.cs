﻿/* See UNLICENSE.txt file for license details. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Utilities.Core.UnitTests
{
  [TestFixture]
  public class AssertTests
  {
    [Test]
    public void NameTest()
    {
      var s = "Hello, world!";
      var assertionContainer = s.Name("s");
      Assert.AreEqual("s", assertionContainer.Name);
    }

    [Test]
    public void NotNullTest()
    {
      var s = "Hello, world!";
      Assert.DoesNotThrow(() => s.NotNull());
      Assert.DoesNotThrow(() => s.Name("s").NotNull());

      s = null;
      Assert.Throws<ArgumentNullException>(() => s.NotNull());
      Assert.Throws<ArgumentNullException>(() => s.Name("s").NotNull());
    }

    [Test]
    public void NotEmptyTest()
    {
      var s = "Hello, world!";
      Assert.DoesNotThrow(() => s.NotNull().NotEmpty());
      Assert.DoesNotThrow(() => s.Name("s").NotNull().NotEmpty());

      s = "";
      Assert.Throws<ArgumentException>(() => s.NotNull().NotEmpty());
      Assert.Throws<ArgumentException>(() => s.Name("s").NotNull().NotEmpty());

      var lst = new List<Int32>() { 1, 2, 3 };
      Assert.DoesNotThrow(() => lst.NotNull().NotEmpty());
      Assert.DoesNotThrow(() => lst.Name("lst").NotNull().NotEmpty());

      lst.Clear();
      Assert.Throws<ArgumentException>(() => lst.NotNull().NotEmpty());
      Assert.Throws<ArgumentException>(() => lst.Name("lst").NotNull().NotEmpty());
    }

    [Test]
    public void GreaterThanTest()
    {
      var earlier = new DateTime(2014, 1, 1);
      var later = new DateTime(2016, 1, 1);
      Assert.DoesNotThrow(() => later.GreaterThan(earlier));
      Assert.DoesNotThrow(() => later.Name("later").GreaterThan(earlier));
      Assert.Throws<ArgumentException>(() => earlier.GreaterThan(later));
      Assert.Throws<ArgumentException>(() => earlier.Name("earlier").GreaterThan(later));
      Assert.Throws<ArgumentException>(() => earlier.GreaterThan(earlier));
      Assert.Throws<ArgumentException>(() => earlier.Name("earlier").GreaterThan(earlier));
    }

    [Test]
    public void GreaterThanOrEqualToTest()
    {
      var earlier = new DateTime(2014, 1, 1);
      var later = new DateTime(2016, 1, 1);
      Assert.DoesNotThrow(() => later.GreaterThanOrEqualTo(earlier));
      Assert.DoesNotThrow(() => later.Name("later").GreaterThanOrEqualTo(earlier));
      Assert.Throws<ArgumentException>(() => earlier.GreaterThanOrEqualTo(later));
      Assert.Throws<ArgumentException>(() => earlier.Name("earlier").GreaterThanOrEqualTo(later));
      Assert.DoesNotThrow(() => earlier.GreaterThanOrEqualTo(earlier));
      Assert.DoesNotThrow(() => earlier.Name("earlier").GreaterThanOrEqualTo(earlier));
    }

    [Test]
    public void LessThanTest()
    {
      var earlier = new DateTime(2014, 1, 1);
      var later = new DateTime(2016, 1, 1);
      Assert.Throws<ArgumentException>(() => later.LessThan(earlier));
      Assert.Throws<ArgumentException>(() => later.Name("later").LessThan(earlier));
      Assert.DoesNotThrow(() => earlier.LessThan(later));
      Assert.DoesNotThrow(() => earlier.Name("earlier").LessThan(later));
      Assert.Throws<ArgumentException>(() => earlier.LessThan(earlier));
      Assert.Throws<ArgumentException>(() => earlier.Name("earlier").LessThan(earlier));
    }

    [Test]
    public void LessThanOrEqualToTest()
    {
      var earlier = new DateTime(2014, 1, 1);
      var later = new DateTime(2016, 1, 1);
      Assert.Throws<ArgumentException>(() => later.LessThanOrEqualTo(earlier));
      Assert.Throws<ArgumentException>(() => later.Name("later").LessThanOrEqualTo(earlier));
      Assert.DoesNotThrow(() => earlier.LessThanOrEqualTo(later));
      Assert.DoesNotThrow(() => earlier.Name("earlier").LessThanOrEqualTo(later));
      Assert.DoesNotThrow(() => earlier.LessThanOrEqualTo(earlier));
      Assert.DoesNotThrow(() => earlier.Name("earlier").LessThanOrEqualTo(earlier));
    }

    [Test]
    public void EqualToTest()
    {
      var earlier = new DateTime(2014, 1, 1);
      var later = new DateTime(2016, 1, 1);
      Assert.Throws<ArgumentException>(() => later.EqualTo(earlier));
      Assert.Throws<ArgumentException>(() => later.Name("later").EqualTo(earlier));
      Assert.DoesNotThrow(() => earlier.EqualTo(earlier));
      Assert.DoesNotThrow(() => earlier.Name("earlier").EqualTo(earlier));
    }

    [Test]
    public void NotEqualToTest()
    {
      var earlier = new DateTime(2014, 1, 1);
      var later = new DateTime(2016, 1, 1);
      Assert.DoesNotThrow(() => later.NotEqualTo(earlier));
      Assert.DoesNotThrow(() => later.Name("later").NotEqualTo(earlier));
      Assert.Throws<ArgumentException>(() => earlier.NotEqualTo(earlier));
      Assert.Throws<ArgumentException>(() => earlier.Name("earlier").NotEqualTo(earlier));
    }
  }
}

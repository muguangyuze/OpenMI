#region Copyright
/*
* Copyright (c) 2005-2010, OpenMI Association
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*     * Redistributions of source code must retain the above copyright
*       notice, this list of conditions and the following disclaimer.
*     * Redistributions in binary form must reproduce the above copyright
*       notice, this list of conditions and the following disclaimer in the
*       documentation and/or other materials provided with the distribution.
*     * Neither the name of the OpenMI Association nor the
*       names of its contributors may be used to endorse or promote products
*       derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY "OpenMI Association" ``AS IS'' AND ANY
* EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
* DISCLAIMED. IN NO EVENT SHALL "OpenMI Association" BE LIABLE FOR ANY
* DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
* (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
* LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
* ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
* (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
* SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion
﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Oatc.OpenMI.Examples.SimpleSCharpRiver;
using Oatc.OpenMI.Sdk.Backbone;
using Oatc.OpenMI.Wrappers.EngineWrapper.UnitTest;
using Oatc.OpenMI.Wrappers.UpdwardsCompatibleWrappers.UnitTests.Components;
using Oatc.UpwardsComp.EngineWrapper;
using OpenMI.Standard2;
using OpenMI.Standard2.TimeSpace;
using LinkableEngine = Oatc.OpenMI.Wrappers.EngineWrapper.LinkableEngine;

namespace Oatc.OpenMI.Wrappers.UpdwardsCompatibleWrappers.UnitTests
{

  public class RiverModel1_4Test : RiverModelTest
  {

    [TestFixtureSetUp]
    public new void TestFixtureSetup()
    {
      _riverModelFactory = new RiverModelFactory();
    }

    [Test]
    [Ignore("Not supported by 1.4 engine")]
    public new void GetValues2BInputAsSpans()
    {
    }

    [Test]
    [Ignore("Not supported by 1.4 engine")]
    public new void GetValues2CInputAsSpans()
    {
    }

  }


  public class LinkableEngine1_4Test : LinkableEnginesTest
  {

    [TestFixtureSetUp]
    public new void TestFixtureSetup()
    {
      _riverModelFactory = new RiverModel1_4Factory();
    }

    [Test]
    [Ignore("Not updated for 1.4 engine")]
    public void GWRiverCoupling()
    {
    }


  }




  public class RiverModel1_4Factory : IRiverModelFactory
  {
    public LinkableEngine CreateRiverModel()
    {
      return (new LinkableEngine1_4<RiverModelEngine>());
    }

    public List<IArgument> CreateRiverModelArguments(ITimeSpaceComponent model)
    {
      return (new List<IArgument>());
    }
  }


}
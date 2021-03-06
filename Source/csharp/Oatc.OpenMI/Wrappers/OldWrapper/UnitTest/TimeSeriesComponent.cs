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
#region Copyright
///////////////////////////////////////////////////////////
//
// namespace: org.OpenMI.Utilities.Wrapper.UnitTest 
// purpose: UnitTest for the org.OpenMI.Utilities.Wrapper package
// file: TimeSeriesComponent.cs
//
///////////////////////////////////////////////////////////
//
//    Copyright (C) 2006 OpenMI Association
//
//    This library is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 2.1 of the License, or (at your option) any later version.
//
//    This library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public
//    License along with this library; if not, write to the Free Software
//    Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//    or look at URL www.gnu.org/licenses/lgpl.html
//
//    Contact info: 
//      URL: www.openmi.org
//	Email: sourcecode@openmi.org
//	Discussion forum available at www.sourceforge.net
//
//      Coordinator: Roger Moore, CEH Wallingford, Wallingford, Oxon, UK
//
///////////////////////////////////////////////////////////
//
//  Original author: Jan B. Gregersen, DHI - Water & Environment, Horsholm, Denmark
//  Created on:      6 April 2005
//  Version:         1.0.0 
//
//  Modification history:
//  
//
///////////////////////////////////////////////////////////
#endregion

using System;
using System.Collections.Generic;
using Oatc.OpenMI.Sdk.Backbone;
using Oatc.OpenMI.Sdk.Buffer;
using OpenMI.Standard;

namespace Oatc.OpenMI.Sdk.Wrapper.UnitTest
{
  /// <summary>
  /// Summary description for TimeSeriesComponent.
  /// </summary>
  public class TimeSeriesComponent : LinkableComponent
  {
      protected List<IInputItem> inputItems = new List<IInputItem>();
      protected List<IOutputItem> outputItems = new List<IOutputItem>();

      readonly SmartBuffer buffer = new SmartBuffer();

    public TimeSeriesComponent()
    {
      Id = "TimeSeriesComponent";
      Quantity quantity = new Quantity(new Unit("literprSecond", 0.001, 0, "lprsec"), "flow", "flow");
      ElementSet elementSet = new ElementSet("oo", "Caption", ElementType.IdBased);
      Element element = new Element("ElementID");
      elementSet.AddElement(element);

      OutputItem outputExchangeItem = new OutputItem("oo.Flow", quantity, elementSet);
      outputExchangeItem.Component = this;
      outputItems.Add(outputExchangeItem);
    }

    public double[] GetValues(ITime time, string linkId)
    {
      return buffer.GetValues(time);
    }

    public ITime EarliestInputTime
    {
      get
      {
        return null;
      }
    }

    public int GetPublishedEventTypeCount()
    {
      return 0;
    }

    public override IList<IInputItem> InputItems
    {
        get { return inputItems; }
    }

    public override IList<IOutputItem> OutputItems
    {
        get { return outputItems; }
    }

    public override void Update(params IOutputItem[] requiredOutputItems)
      {
          throw new NotImplementedException();
      }

	public override void Initialize(IArgument[] arguments)
	{
      Status = LinkableComponentStatus.Initializing;
      double start = Time.ToModifiedJulianDay(new DateTime(2004, 12, 31, 0, 0, 0));

      for (int i = 0; i < 30; i++)
      {
        buffer.AddValues(new Time(start + i, 1), new double[] { i });
      }
      Status = LinkableComponentStatus.Initialized;
    }

      public override string[] Validate()
    {
        return new string[0];
    }

      public override void Finish()
    {
    }
  }
}

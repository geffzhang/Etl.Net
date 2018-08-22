﻿using Microsoft.EntityFrameworkCore;
using Paillave.Etl.Core.StreamNodes;
using Paillave.Etl.Core.Streams;
using Paillave.RxPush.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Paillave.RxPush.Operators;

namespace Paillave.Etl.EntityFrameworkCore.StreamNodes
{
    public class ToEntityFrameworkCoreStreamNode<TIn, TRes> : ToStreamNodeBase<TIn, TRes, ToStreamArgsBase<TRes>>
        where TRes : DbContext
        where TIn : class
    {
        public ToEntityFrameworkCoreStreamNode(IStream<TIn> input, string name, ToStreamArgsBase<TRes> args) : base(input, name, args) { }

        protected override void ProcessValueToOutput(TRes outputResource, TIn value)
        {
            outputResource.Add(value);
        }
        protected override void PostProcessChunk(TRes outputResource, IEnumerable<TIn> values)
        {
            outputResource.SaveChanges();
        }
    }
}
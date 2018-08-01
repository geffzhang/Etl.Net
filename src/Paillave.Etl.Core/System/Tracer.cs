﻿using Paillave.Etl.Core.System.TraceContents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Paillave.Etl.Core.System
{
    public class Tracer : ITracer
    {
        private readonly IExecutionContext _executionContext;
        private readonly INodeContext _nodeContext;

        public Tracer(IExecutionContext executionContext, INodeContext nodeContext)
        {
            this._executionContext = executionContext;
            this._nodeContext = nodeContext;
        }

        public void Trace(ITraceContent content)
        {
            this._executionContext.Trace(new TraceEvent(_executionContext.JobName, _executionContext.ExecutionId, _nodeContext.TypeName, _nodeContext.NodeNamePath, content));
        }
    }
}
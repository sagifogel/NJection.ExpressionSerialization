﻿using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace NJection.ExpressionSerialization
{
    internal class BranchingRegistry : IBranchingRegistry
    {
        private static readonly object _syncLock = new object();
        private static readonly string _returnStatementName = "ReturnStatement";
        private ConcurrentDictionary<string, LabelTarget> _branchingDictionary = null;

        public BranchingRegistry() {
            lock (_syncLock) {
                _branchingDictionary = new ConcurrentDictionary<string, LabelTarget>();
            }
        }

        public bool HasReturnLabel { get; private set; }

        public LabelTarget RegisterLabel(Type type, string name) {
            return _branchingDictionary.GetOrAdd(name, new Lazy<LabelTarget>(() => Expression.Label(type, name)).Value);
        }

        public LabelTarget RegisterReturnStatementLabel(Type type) {
            HasReturnLabel = true;

            return RegisterLabel(type, _returnStatementName);
        }

        public LabelTarget ResolveLabel(string name) {
            LabelTarget label;

            _branchingDictionary.TryGetValue(name, out label);

            return label;
        }

        public LabelTarget ResolveReturnStatementLabel() {
            return ResolveLabel(_returnStatementName);
        }
    }
}
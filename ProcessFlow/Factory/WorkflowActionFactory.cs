﻿using ProcessFlow.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessFlow.Factory
{
    public class WorkflowActionFactory<T> where T : class
    {
        private List<IProcessor<T>> _processors;
        private List<ISingleStepSelector<T>> _stepSelectors;

        public WorkflowActionFactory(List<IProcessor<T>> processors = null, List<ISingleStepSelector<T>> stepSelectors = null)
        {
            _processors = processors;
            _stepSelectors = stepSelectors;
        }

        public IProcessor<T> GetProcessor<V>() where V : IProcessor<T>
        {
            return _processors.Where(processor => processor.GetType() == typeof(V)).FirstOrDefault();
        }

        public IProcessor<T> GetProcessor(Type type)
        {
            return _processors.Where(processor => processor.GetType() == type).FirstOrDefault();
        }

        public ISingleStepSelector<T> GetStepSelector<V>()
        {
            return _stepSelectors.Where(stepSelector => stepSelector.GetType() == typeof(V)).FirstOrDefault();
        }

        public ISingleStepSelector<T> GetStepSelector(Type type)
        {
            return _stepSelectors.Where(stepSelector => stepSelector.GetType() == type).FirstOrDefault();
        }
    }
}

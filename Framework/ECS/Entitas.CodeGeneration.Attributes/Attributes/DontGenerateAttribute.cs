﻿using System;

namespace QFramework.CodeGeneration.Attributes
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct)]
    public class DontGenerateAttribute : Attribute
    {
        public readonly bool generateIndex;

        public DontGenerateAttribute(bool generateIndex = true)
        {
            this.generateIndex = generateIndex;
        }
    }
}
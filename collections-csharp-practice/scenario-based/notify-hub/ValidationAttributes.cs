using System;

[AttributeUsage(AttributeTargets.Property)]
public class RequiredAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
public class MaxLengthAttribute : Attribute
{
    public int Length { get; }

    public MaxLengthAttribute(int length) => Length = length;
}

[AttributeUsage(AttributeTargets.Property)]
public class PriorityAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }

    public PriorityAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class EmailFormatAttribute : Attribute { }

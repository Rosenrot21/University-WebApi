﻿using System.Reflection;

namespace University.Core.Common;

public abstract class ValueObject : IEquatable<ValueObject>
{
    private List<PropertyInfo>? _properties;
    private List<FieldInfo>? _fields;

    public static bool operator ==(ValueObject? obj1, ValueObject? obj2)
    {
        return obj1?.Equals(obj2) ?? Equals(obj2, null);
    }

    public static bool operator !=(ValueObject obj1, ValueObject obj2)
    {
        return !(obj1 == obj2);
    }

    public bool Equals(ValueObject? obj)
    {
        return Equals(obj as object);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;

        return GetProperties().All(p => PropertiesAreEqual(obj, p))
               && GetFields().All(f => FieldsAreEqual(obj, f));
    }

    private bool PropertiesAreEqual(object obj, PropertyInfo p)
    {
        return Equals(p.GetValue(this, null), p.GetValue(obj, null));
    }

    private bool FieldsAreEqual(object obj, FieldInfo f)
    {
        return Equals(f.GetValue(this), f.GetValue(obj));
    }

    private IEnumerable<PropertyInfo> GetProperties()
    {
        if (_properties != null) return _properties;

        _properties = GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
            .ToList();

        // Not available in Core
        // !Attribute.IsDefined(p, typeof(IgnoreMemberAttribute))).ToList();

        return _properties;
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        if (_fields != null) return _fields;

        _fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
            .ToList();

        return _fields;
    }

    public override int GetHashCode()
    {
        unchecked //allow overflow
        {
            var hash = 17;
            foreach (var prop in GetProperties())
            {
                var value = prop.GetValue(this, null);
                hash = HashValue(hash, value);
            }

            foreach (var field in GetFields())
            {
                var value = field.GetValue(this);
                hash = HashValue(hash, value);
            }

            return hash;
        }
    }

    private static int HashValue(int seed, object? value)
    {
        var currentHash = value?.GetHashCode() ?? 0;

        return seed * 23 + currentHash;
    }

    // protected static void CheckRule(IBusinessRule rule)
    // {
    //     if (rule.IsBroken())
    //     {
    //         throw new BusinessRuleValidationException(rule);
    //     }
    // }
}

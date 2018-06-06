﻿using System;
using Importers.Converters;
using Newtonsoft.Json.Serialization;
using UnityEditor.Importers;
using UnityEditor.ShaderGraph;
using UnityEngine;

namespace UnityEngine.ShaderGraph
{
    public class ContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            var jsonContract = base.CreateContract(objectType);

            if (objectType == typeof(Vector2))
                jsonContract.Converter = new Vector2Converter();
            else if (objectType == typeof(Vector3))
                jsonContract.Converter = new Vector3Converter();
            else if (objectType == typeof(Vector4))
                jsonContract.Converter = new Vector4Converter();
            else if (Attribute.IsDefined(objectType, typeof(JsonVersionedAttribute), true))
                jsonContract.Converter = new UpgradeConverter(objectType);

            return jsonContract;
        }
    }
}
